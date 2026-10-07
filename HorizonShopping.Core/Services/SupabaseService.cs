using HorizonShopping.Core.Models.Supabase;
using Supabase;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;
using Supabase.Postgrest;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HorizonShopping.Core.Services
{
    public class SupabaseService
    {
        private readonly Supabase.Client _client;

        private bool _inicializado;

        public SupabaseService(IGotrueSessionPersistence<Session> sessionPersistence)
        {
            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = false,
                SessionHandler = sessionPersistence
            };

            _client = new Supabase.Client("https://duvppjdztbvrtqjtvvus.supabase.co/", "sb_publishable_FqM6VXdJGvjB4sDDeljjlA_Eosi4TZV", options);
        }

        //CLIENTE
        public Supabase.Client Cliente => _client;


        //INICIALIZACIÓN
        public async Task InicializarAsync()
        {
            if (_inicializado)
                return;

            await InicializarInternamenteAsync();

            _inicializado = true;
        }

        //VINCULACIÓN
        public async Task<(string codigo, DateTime expiraAt)> GenerarCodigoVinculacionAsync()
        {
            await InicializarAsync();

            var respuesta = await _client.Rpc("generar_codigo_vinculacion", null);

            if (respuesta is null || string.IsNullOrWhiteSpace(respuesta.Content))
            {
                throw new InvalidOperationException("Supabase no devolvió ningún código de vinculación.");
            }

            using var documento = System.Text.Json.JsonDocument.Parse(respuesta.Content);

            System.Text.Json.JsonElement elemento = documento.RootElement;


            if (elemento.ValueKind == System.Text.Json.JsonValueKind.Array)
            {
                if (elemento.GetArrayLength() == 0)
                {
                    throw new InvalidOperationException("Supabase no devolvió ningún código de vinculación.");
                }

                elemento = elemento[0];
            }

            if (elemento.ValueKind != System.Text.Json.JsonValueKind.Object)
            {
                throw new InvalidOperationException("Supabase devolvió un formato de código de vinculación no válido.");
            }

            if (!elemento.TryGetProperty("codigo", out System.Text.Json.JsonElement codigoElemento))
            {
                throw new InvalidOperationException("Supabase no devolvió el código de vinculación.");
            }

            if (!elemento.TryGetProperty("expira_at", out System.Text.Json.JsonElement expiraElemento))
            {
                throw new InvalidOperationException("Supabase no devolvió la fecha de expiración del código.");
            }

            string codigo = codigoElemento.GetString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new InvalidOperationException("Supabase devolvió un código de vinculación vacío.");
            }

            DateTime expiraAt;

            if (!expiraElemento.TryGetDateTime(out expiraAt))
            {
                if (!DateTime.TryParse(expiraElemento.GetString(), out expiraAt))
                {
                    throw new InvalidOperationException("Supabase devolvió una fecha de expiración no válida.");
                }
            }

            return (codigo, expiraAt);
        }

        public async Task<Guid> VincularDispositivoPorCodigoAsync(string codigo)
        {
            await InicializarAsync();

            var parametros = new Dictionary<string, object>
                {
                    ["p_codigo"] = codigo
                };

            var respuesta = await _client.Rpc("vincular_dispositivo_por_codigo", parametros);

            if (respuesta is null || string.IsNullOrWhiteSpace(respuesta.Content))
            {
                throw new InvalidOperationException("Supabase no devolvió la lista vinculada.");
            }

            Guid listaId = System.Text.Json.JsonSerializer.Deserialize<Guid>(respuesta.Content);

            return listaId;
        }

        public async Task DesvincularDispositivoAsync()
        {
            await InicializarAsync();

            await _client.Rpc("desvincular_dispositivo", null);
        }

        public async Task<int> ObtenerNumeroDispositivosVinculadosAsync()
        {
            Debug.WriteLine("========== ENTRA ESTADO VINCULACION ==========");

            await InicializarAsync();

            Debug.WriteLine("USUARIO ACTUAL SUPABASE → " + ObtenerUsuarioId());

            try
            {
                var respuesta = await _client.Rpc("obtener_estado_vinculacion", null);

                string contenido = respuesta?.Content ?? string.Empty;

                System.Diagnostics.Debug.WriteLine("========== ESTADO VINCULACION ==========");

                System.Diagnostics.Debug.WriteLine("RPC RESPUESTA: " + contenido);

                if (string.IsNullOrWhiteSpace(contenido))
                {
                    System.Diagnostics.Debug.WriteLine("RPC RESPUESTA VACÍA");

                    return 0;
                }

                contenido = contenido.Trim();

      
                if (int.TryParse(contenido.Trim('"'), out int cantidadDirecta))
                {
                    System.Diagnostics.Debug.WriteLine("DISPOSITIVOS VINCULADOS: " + cantidadDirecta);

                    System.Diagnostics.Debug.WriteLine("========================================");

                    return cantidadDirecta;
                }

                using var documento = System.Text.Json.JsonDocument.Parse(contenido);

                System.Text.Json.JsonElement elemento = documento.RootElement;

                if (elemento.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    if (elemento.GetArrayLength() == 0)
                        return 0;

                    elemento = elemento[0];
                }

                if (elemento.ValueKind == System.Text.Json.JsonValueKind.Number && elemento.TryGetInt32(out int cantidadNumero))
                {
                    System.Diagnostics.Debug.WriteLine("DISPOSITIVOS VINCULADOS: " + cantidadNumero);

                    System.Diagnostics.Debug.WriteLine("========================================");

                    return cantidadNumero;
                }

 
                if (elemento.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    foreach (System.Text.Json.JsonProperty propiedad in elemento.EnumerateObject())
                    {
                        if (propiedad.Value.ValueKind == System.Text.Json.JsonValueKind.Number && propiedad.Value.TryGetInt32(out int cantidadObjeto))
                        {
                            System.Diagnostics.Debug.WriteLine("PROPIEDAD RPC: " + propiedad.Name);

                            System.Diagnostics.Debug.WriteLine("DISPOSITIVOS VINCULADOS: " + cantidadObjeto);

                            System.Diagnostics.Debug.WriteLine("========================================");

                            return cantidadObjeto;
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("NO SE PUDO INTERPRETAR LA RESPUESTA RPC.");

                System.Diagnostics.Debug.WriteLine("========================================");

                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("========== ERROR ESTADO VINCULACION ==========");

                System.Diagnostics.Debug.WriteLine(ex.ToString());

                System.Diagnostics.Debug.WriteLine("==============================================");

                throw;
            }
        }

        //LISTA DEL DISPOSITIVO
        public async Task<ListaSupabase?> ObtenerListaDispositivoAsync()
        {
            await InicializarAsync();

            string usuarioIdTexto = ObtenerUsuarioId();

            if (!Guid.TryParse(usuarioIdTexto, out Guid usuarioId))
            {
                throw new InvalidOperationException("El identificador del usuario de Supabase no es válido.");
            }

            var resultado = await _client.From<DispositivoSupabase>().Where(d => d.Id == usuarioId).Get();

            DispositivoSupabase? dispositivo = resultado.Models.FirstOrDefault();

            if (dispositivo?.ListaId is null)
                return null;

            var listaResultado = await _client.From<ListaSupabase>().Where(l => l.Id == dispositivo.ListaId.Value).Get();

            return listaResultado.Models.FirstOrDefault();
        }

        //ÚLTIMO ACCESO
        public async Task RegistrarUltimoAccesoAsync()
        {
            await InicializarAsync();

            var respuesta = await _client.Rpc("registrar_ultimo_acceso", null);

            if (respuesta is null || string.IsNullOrWhiteSpace(respuesta.Content))
            {
                return;
            }

            _ = DateTime.TryParse(respuesta.Content.Trim('"'), out _);
        }

       
        // CONFIRMAR ELIMINACIÓN       
        public async Task ConfirmarEliminacionAsync(Guid listaId, string tipo, Guid elementoId)
        {
            await InicializarAsync();

            if (tipo != "producto" && tipo != "seccion")
            {
                throw new ArgumentException("El tipo de eliminación no es válido.", nameof(tipo));
            }

            var parametros = new Dictionary<string, object>
                {
                    ["p_lista_id"] = listaId,
                    ["p_tipo"] = tipo,
                    ["p_elemento_id"] = elementoId
                };

            await _client.Rpc("confirmar_eliminacion", parametros);
        }

        
        // INICIALIZACIÓN INTERNA        
        private async Task InicializarInternamenteAsync()
        {
            await _client.InitializeAsync();

            _client.Auth.LoadSession();

            await _client.Auth.RetrieveSessionAsync();

            if (_client.Auth.CurrentSession is not null && _client.Auth.CurrentUser?.IsAnonymous != true)
            {
                await _client.Auth.SignOut();
            }

            if (_client.Auth.CurrentSession is null)
            {
                Session? sesion = await _client.Auth.SignInAnonymously();

                if (sesion is null)
                {
                    throw new InvalidOperationException("Supabase no pudo crear el dispositivo anónimo.");
                }

                await _client.Auth.SetSession(sesion.AccessToken, sesion.RefreshToken);
            }

            await RegistrarDispositivoAsync();
        }

       
        // REGISTRAR DISPOSITIVO   
        private async Task RegistrarDispositivoAsync()
        {
            string usuarioIdTexto = ObtenerUsuarioId();

            if (!Guid.TryParse(usuarioIdTexto, out Guid usuarioId))
            {
                throw new InvalidOperationException("El identificador del usuario de Supabase no es válido.");
            }

            var resultado = await _client.From<DispositivoSupabase>().Where(d => d.Id == usuarioId).Get();

            DispositivoSupabase? dispositivo = resultado.Models.FirstOrDefault();

            if (dispositivo is not null && dispositivo.ListaId is not null)
            {
                return;
            }

            if (dispositivo is null)
            {
                var nuevoDispositivo = new DispositivoSupabase       
                {
                        Id = usuarioId,
                        ListaId = null,
                        CreatedAt = DateTime.UtcNow,
                        UltimoAcceso = DateTime.UtcNow
                };

                await _client.From<DispositivoSupabase>().Insert(nuevoDispositivo);
            }

            await _client.Rpc("crear_lista_para_dispositivo", null);
        }

        
        // OBTENER USUARIO ACTUAL       
        public string ObtenerUsuarioId()
        {
            string? id = _client.Auth.CurrentUser?.Id;

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new InvalidOperationException("No existe un usuario anónimo de Supabase.");
            }

            return id;
        }

        
        // MODELOS INTERNOS        
        private class ResultadoCodigoVinculacion
        {
            public string codigo { get; set; } = string.Empty;

            public DateTime expira_at { get; set; }
        }

        private class EstadoVinculacion
        {
            public int dispositivos_vinculados { get; set; }
        }
    }
}