using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;
using HorizonShopping.Maui.Services;

namespace HorizonShopping.Maui;

public partial class AddProductPage : ContentPage
{
    private readonly ShoppingController _controller;
    private readonly SeccionController _seccionController;
    private readonly List<EntradaProducto> _entradas = new();
    private readonly ThemeService _themeService;

    public AddProductPage(ShoppingController controller, SeccionController seccionController, ThemeService themeService)
    {
        InitializeComponent();

        _controller = controller;
        _seccionController = seccionController;
        _themeService = themeService;

        _themeService.CargarTemaGuardado();

        CargarSecciones();

        AñadirEntradaProducto();
    }

    //SECCIONES
    private void CargarSecciones()
    {
        cmbSeccion.ItemsSource = _seccionController.ObtenerTodas();
    }

    //GESTIÓN DE ENTRADAS
    private void OnAñadirOtroProductoClicked(object sender, EventArgs e)
    {
        AñadirEntradaProducto();
    }

    private void AñadirEntradaProducto()
    {
        Entry txtNombre = new Entry
        {
            Placeholder = "Nombre del producto",
            FontSize = 16
        };

        Entry txtCantidad = new Entry
        {
            Text = "1",
            Keyboard = Keyboard.Numeric,
            WidthRequest = 75,
            FontSize = 16
        };

        Button btnEliminar = new Button
        {
            Text = "×",
            WidthRequest = 40,
            HeightRequest = 40,
            Padding = 0,
            FontSize = 18,
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black
        };

        Grid fila = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition
                {
                    Width = GridLength.Star
                },
                new ColumnDefinition
                {
                    Width = 75
                },
                new ColumnDefinition
                {
                    Width = 40
                }
            },
            ColumnSpacing = 8
        };

        fila.Add(txtNombre);
        Grid.SetColumn(txtNombre, 0);

        fila.Add(txtCantidad);
        Grid.SetColumn(txtCantidad, 1);

        fila.Add(btnEliminar);
        Grid.SetColumn(btnEliminar, 2);

        EntradaProducto entrada = new EntradaProducto
        {
            Nombre = txtNombre,
            Cantidad = txtCantidad,
            Fila = fila
        };

        _entradas.Add(entrada);

        btnEliminar.Clicked += (s, e) =>
        {
            listaEntradas.Children.Remove(fila);
            _entradas.Remove(entrada);
        };

        listaEntradas.Children.Add(fila);
    }

    //GUARDADO DE PRODUCTOS
    private async void OnAñadirProductosClicked(object sender, EventArgs e)
    {
        try
        {
            if (cmbSeccion.SelectedItem is not SeccionModel seccion)
            {
                await DisplayAlert("Sección", 
                    "Selecciona una sección antes de añadir los productos.", 
                    "Aceptar");

                return;
            }

            if (_entradas.Count == 0)
            {
                await DisplayAlert(
                    "Productos",
                    "Añade al menos un producto.",
                    "Aceptar");

                return;
            }

            int productosAñadidos = 0;

            foreach (EntradaProducto entrada in _entradas)
            {
                string nombre = entrada.Nombre.Text?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(nombre))
                    continue;

                int? cantidad = null;

                if (!string.IsNullOrWhiteSpace(entrada.Cantidad.Text))
                {
                    if (int.TryParse(entrada.Cantidad.Text, out int cantidadNumerica))
                    {
                        cantidad = cantidadNumerica;
                    }
                    else
                    {
                        await DisplayAlert(
                            "Cantidad incorrecta",
                            $"La cantidad de \"{nombre}\" no es válida.",
                            "Aceptar");

                        return;
                    }
                }

                _controller.CrearProducto(nombre, cantidad, seccion.Id);

                productosAñadidos++;
            }

            if (productosAñadidos == 0)
            {
                await DisplayAlert(
                    "Productos",
                    "Introduce al menos un producto.",
                    "Aceptar");

                return;
            }
                  
            _controller.Guardar();

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }

    //MODELO INTERNO
    private class EntradaProducto
    {
        public Entry Nombre { get; set; } = null!;
        public Entry Cantidad { get; set; } = null!;
        public Grid Fila { get; set; } = null!;
    }
}