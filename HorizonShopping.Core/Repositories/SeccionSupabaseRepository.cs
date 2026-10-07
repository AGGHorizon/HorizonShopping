using HorizonShopping.Core.Models;
using HorizonShopping.Core.Models.Supabase;
using HorizonShopping.Core.Services;

namespace HorizonShopping.Core.Repositories
{
    public class SeccionSupabaseRepository
    {
        private readonly SupabaseService _supabaseService;

        public SeccionSupabaseRepository(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        //CONSULTAS

        public async Task<List<SeccionSupabase>>ObtenerSeccionesAsync(Guid listaId)
        {
            var resultado = await _supabaseService.Cliente.From<SeccionSupabase>().Where(x => x.ListaId == listaId).Get();

            return resultado.Models;
        }

        //GUARDADO
        public async Task<SeccionSupabase>GuardarSeccionAsync(Guid listaId, SeccionModel seccion)
        {
            SeccionSupabase seccionSupabase = new SeccionSupabase
                {
                    Id = seccion.Id,
                    ListaId = listaId,
                    Nombre = seccion.Nombre,
                    Predeterminada =
                    seccion.EsPredeterminada,
                    UpdatedAt = seccion.UpdatedAt,
                    DeletedAt = seccion.DeletedAt
                };

            var resultado = await _supabaseService.Cliente.From<SeccionSupabase>().Where(x => x.Id == seccion.Id).Get();

            if (resultado.Models.Count == 0)
            {
                await _supabaseService.Cliente.From<SeccionSupabase>().Insert(seccionSupabase);
            }
            else
            {
                await _supabaseService.Cliente.From<SeccionSupabase>().Where(x => x.Id == seccion.Id).Update(seccionSupabase);
            }

            return seccionSupabase;
        }

        public async Task<SeccionSupabase>CrearSeccionAsync(Guid listaId, SeccionModel seccion)
        {
            return await GuardarSeccionAsync(listaId, seccion);
        }

        public async Task ActualizarSeccionAsync(SeccionModel seccion)
        {
            ListaSupabase? lista = await ObtenerListaDelDispositivoAsync();

            if (lista is null)
                throw new InvalidOperationException("El dispositivo no tiene ninguna lista asociada.");

            await GuardarSeccionAsync(lista.Id, seccion);
        }

        //ELIMINACIÓN
        public async Task EliminarSeccionAsync(Guid seccionId)
        {
            var resultado = await _supabaseService.Cliente.From<SeccionSupabase>().Where(x => x.Id == seccionId).Get();

            SeccionSupabase? seccion = resultado.Models.FirstOrDefault();

            if (seccion is null)
                return;

            seccion.DeletedAt = DateTime.UtcNow;
            seccion.UpdatedAt = DateTime.UtcNow;

            await _supabaseService.Cliente.From<SeccionSupabase>().Where(x => x.Id == seccionId).Update(seccion);
        }

        
        // CONVERSIÓN SUPABASE -> LOCAL
        

        public SeccionModel ConvertirASeccion(SeccionSupabase seccionSupabase)
        {
            if (seccionSupabase is null)
                throw new ArgumentNullException(nameof(seccionSupabase));

            SeccionModel seccion = new SeccionModel(seccionSupabase.Nombre, seccionSupabase.Predeterminada);

            seccion.Id = seccionSupabase.Id;

            seccion.UpdatedAt = seccionSupabase.UpdatedAt;

            seccion.DeletedAt = seccionSupabase.DeletedAt;

            return seccion;
        }

        
        // OBTENER LISTA DEL DISPOSITIVO
      

        private async Task<ListaSupabase?> ObtenerListaDelDispositivoAsync()
        {
            string? usuarioIdTexto = _supabaseService.ObtenerUsuarioId();

            if (string.IsNullOrWhiteSpace(usuarioIdTexto))
            {
                return null;
            }

            Guid usuarioId = Guid.Parse(usuarioIdTexto);

            var dispositivoResultado = await _supabaseService.Cliente.From<DispositivoSupabase>().Where(x => x.Id == usuarioId).Get();

            DispositivoSupabase? dispositivo = dispositivoResultado.Models.FirstOrDefault();

            if (dispositivo?.ListaId is null)
                return null;

            var listaResultado = await _supabaseService.Cliente.From<ListaSupabase>().Where(x => x.Id == dispositivo.ListaId.Value).Get();

            return listaResultado.Models.FirstOrDefault();
        }
    }
}