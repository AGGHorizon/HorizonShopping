namespace HorizonShopping.Maui.Services;

public static class ProductoIconService
{
    private static readonly Dictionary<string, string> Iconos = new()
    {
        // Frutas
        { "manzana", "icon_manzana.svg" },
        { "pera", "icon_pera.svg" },
        { "albaricoque", "icon_albaricoque.svg" },
        { "arándano", "icon_arandanos.svg" },
        { "arándanos", "icon_arandanos.svg" },
        { "cereza", "icon_cereza.svg" },
        { "fresa", "icon_fresa.svg" },
        { "kiwi", "icon_kiwi.svg" },
        { "lima", "icon_lima.svg" },
        { "limón", "icon_limon.svg" },
        { "limon", "icon_limon.svg" },
        { "mango", "icon_mango.svg" },
        { "melón", "icon_melon.svg" },
        { "melon", "icon_melon.svg" },
        { "naranja", "icon_naranja.svg" },
        { "piña", "icon_pinya.svg" },
        { "platano", "icon_platano.svg" },
        { "plátano", "icon_platano.svg" },
        { "sandía", "icon_sandia.svg" },
        { "sandia", "icon_sandia.svg" },
        { "uva", "icon_uva.svg" },

        // Verduras y hortalizas
        { "aguacate", "icon_aguacate.svg" },
        { "brócoli", "icon_broccoli.svg" },
        { "brocoli", "icon_broccoli.svg" },
        { "cebolla", "icon_cebolla.svg" },
        { "champiñón", "icon_champi.svg" },
        { "champinon", "icon_champi.svg" },
        { "champi", "icon_champi.svg" },
        { "lechuga", "icon_lechuga.svg" },
        { "maíz", "icon_maiz.svg" },
        { "maiz", "icon_maiz.svg" },
        { "oliva", "icon_oliva.svg" },
        { "aceituna", "icon_oliva.svg" },
        { "patata", "icon_patata.svg" },
        { "pimiento", "icon_pimiento.svg" },
        { "tomate", "icon_tomate.svg" },
        { "zanahoria", "icon_zanahoria.svg" },
        { "judía", "icon_judia.svg" },
        { "judia", "icon_judia.svg" },

        // Lácteos
        { "leche", "icon_leche.svg" },
        { "yogur", "icon_leche.svg" },
        { "yogurt", "icon_leche.svg" },
        { "queso", "icon_queso.svg" },

        // Panadería y cereales
        { "pan", "icon_pan.svg" },
        { "barra", "icon_pan.svg" },
        { "baguette", "icon_pan.svg" },
        { "tostada", "icon_tostadas.svg" },
        { "tostadas", "icon_tostadas.svg" },
        { "galleta", "icon_galleta.svg" },
        { "galletas", "icon_galleta.svg" },
        { "bollería", "icon_bolleria.svg" },
        { "bolleria", "icon_bolleria.svg" },
        { "donut", "icon_donuts.svg" },
        { "donuts", "icon_donuts.svg" },

        // Pasta y arroz
        { "espagueti", "icon_espagueti_macarrone_pasta.svg" },
        { "espaguetis", "icon_espagueti_macarrone_pasta.svg" },
        { "macarrón", "icon_espagueti_macarrone_pasta.svg" },
        { "macarron", "icon_espagueti_macarrone_pasta.svg" },
        { "macarrones", "icon_espagueti_macarrone_pasta.svg" },        
        { "arroz", "icon_arroz.svg" },

        // Carne
        { "carne", "icon_carne.svg" },
        { "pollo", "icon_pollo.svg" },
        { "ternera", "icon_ternera.svg" },
        { "hamburguesa", "icon_hamburguesa.svg" },
        { "perrito", "icon_perrito.svg" },
        { "salchicha", "icon_perrito.svg" },        

        // Pescado y marisco
        { "pescado", "icon_marisco.svg" },
        { "marisco", "icon_marisco.svg" },
        { "gamba", "icon_gamba.svg" },
        { "gambas", "icon_gamba.svg" },
        { "gambón", "icon_gambon.svg" },
        { "gambon", "icon_gambon.svg" },
        { "cigala", "icon_cigala.svg" },
        { "pulpo", "icon_pulpo.svg" },
        { "almeja", "icon_almeja.svg" },
        { "salmón", "icon_marisco.svg" },
        { "salmon", "icon_marisco.svg" },
        { "atún", "icon_marisco.svg" },
        { "atun", "icon_marisco.svg" },

        // Dulces y snacks
        { "chocolate", "icon_choco.svg" },
        { "choco", "icon_choco.svg" },
        { "chuche", "icon_chuche.svg" },
        { "chuches", "icon_chuche.svg" },
        { "palomita", "icon_palomitas.svg" },
        { "palomitas", "icon_palomitas.svg" },
        { "helado", "icon_helado.svg" },
        { "tarta", "icon_tarta.svg" },
        { "burrito", "icon_burrito.svg" },
        { "empanadilla", "icon_empanadilla.svg" },
        { "pizza", "icon_pizza.svg" },
        { "sushi", "icon_sushi.svg" },
        { "ensalada", "icon_ensalada.svg" },     

        // Bebidas
        { "agua", "icon_agua.svg" },
        { "cerveza", "icon_cerveza.svg" },
        { "fanta", "icon_fanta.svg" },
        { "refresco", "icon_refresco.svg" },
        { "zumo", "icon_zumo.svg" },
        { "vino", "icon_vino.svg" },
        { "champagne", "icon_bebida_fiesta_champagne.svg" },
        { "cava", "icon_bebida_fiesta_champagne.svg" },
        { "café", "icon_bebida.svg" },
        { "cafe", "icon_bebida.svg" },
        { "té", "icon_te.svg" },
        { "te", "icon_te.svg" },
        { "infusión", "icon_infusion.svg" },
        { "infusion", "icon_infusion.svg" },

        // Conservas / alimentos varios
        { "cacahuete", "icon_cacahuete_frutos_secos.svg" },
        { "cacahuetes", "icon_cacahuete_frutos_secos.svg" },
        { "avellana", "icon_avellana.svg" },
        { "avellanas", "icon_avellana.svg" },
        { "frutos secos", "icon_cacahuete_frutos_secos.svg" },
        { "sal", "icon_sal.svg" },
        { "pimienta", "icon_pimienta.svg" },

        // Comida preparada
        { "bacon", "icon_bacon.svg" },
        { "bocadillo", "icon_sandwich.svg" },
        { "sándwich", "icon_sandwich.svg" },
        { "sandwich", "icon_sandwich.svg" },
        { "pincho", "icon_pinchito.svg" },
        { "pinchito", "icon_pinchito.svg" },

        // Cocina y hogar
        { "plato", "icon_plato.svg" },
        { "platos", "icon_platos.svg" },
        { "cubierto", "icon_cubierto.svg" },
        { "cubiertos", "icon_cubierto.svg" },
        { "cuchillo", "icon_cuchillo.svg" },
        { "sartén", "icon_sarten.svg" },
        { "sarten", "icon_sarten.svg" },

        // Farmacia
        { "farmacia", "icon_pharmacy.svg" },
        { "medicina", "icon_pharmacy.svg" },
        { "medicamento", "icon_pharmacy.svg" },
        { "medicamentos", "icon_pharmacy.svg" },

        // Otras cosas
        { "cigarro", "icon_cigarro_tabaco.svg" },
        { "tabaco", "icon_cigarro_tabaco.svg" },
        { "cuchilla", "icon_cuchilla_afeitar_depilar.svg" },
        { "afeitar", "icon_cuchilla_afeitar_depilar.svg" },
        { "depilar", "icon_cuchilla_afeitar_depilar.svg" },
        { "guantes", "icon_guantes.svg" },
        { "pastilla", "icon_pastilla_ibuprofeno_paracetamol_medicacion_medicamento.svg" },
        { "ibuprofeno", "icon_pastilla_ibuprofeno_paracetamol_medicacion_medicamento.svg" },
        { "paracetamol", "icon_pastilla_ibuprofeno_paracetamol_medicacion_medicamento.svg" },
        { "medicacion", "icon_pastilla_ibuprofeno_paracetamol_medicacion_medicamento.svg" },        
        { "medicación", "icon_pastilla_ibuprofeno_paracetamol_medicacion_medicamento.svg" },
        { "suavizante", "icon_suavizante_champu_gel_jabon.svg" },
        { "champu", "icon_suavizante_champu_gel_jabon.svg" },
        { "gel", "icon_suavizante_champu_gel_jabon.svg" },
        { "jabon", "icon_suavizante_champu_gel_jabon.svg" },
        { "papel", "icon_papel.svg" },
        { "tijera", "icon_tijera.svg" },
        { "dientes", "icon_pasta_dientes_cepillo.svg" },
        { "cepillo", "icon_pasta_dientes_cepillo.svg" },

    };

    public static string ObtenerIcono(string nombreProducto)
    {
        if (string.IsNullOrWhiteSpace(nombreProducto))
            return "icon_product.svg";

        string nombre = nombreProducto.Trim().ToLowerInvariant();

        foreach (var icono in Iconos)
        {
            if (nombre.Contains(icono.Key))
                return icono.Value;
        }

        return "icon_product.svg";
    }
}