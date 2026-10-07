using System.Text.Json.Serialization;

namespace HorizonShopping.Core.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Seccion
    {
        Todo,
        Supermercado,
        Mercado,
        Farmacia,
        Drogueria,
        Erik,
        Piso
    }
    
}
