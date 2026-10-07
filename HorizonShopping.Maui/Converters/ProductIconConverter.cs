using System.Globalization;
using HorizonShopping.Maui.Services;

namespace HorizonShopping.Maui.Converters;

public class ProductIconConverter : IValueConverter
{
    //CONVERSIÓN
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string nombre = value?.ToString() ?? "";

        return ProductoIconService.ObtenerIcono(nombre);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}