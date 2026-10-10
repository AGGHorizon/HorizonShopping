using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;

namespace HorizonShopping.Maui;

public partial class EditProductPage : ContentPage, IQueryAttributable
{
    private readonly ShoppingController _controller;
    private readonly SeccionController _seccionController;

    private Producto? _producto;

    public EditProductPage(ShoppingController controller, SeccionController seccionController)
    {
        InitializeComponent();

        _controller = controller;
        _seccionController = seccionController;

        CargarSecciones();
    }

    //CARGA DE DATOS
    private void CargarSecciones()
    {
        cmbSeccion.ItemsSource = _seccionController.ObtenerTodas();
    }

    private void CargarDatosProducto()
    {
        if (_producto is null)
            return;

        txtNombre.Text = _producto.Nombre;

        if (_producto.Cantidad != null)
        {
            txtCantidad.Text = _producto.Cantidad.ToString();
        }
        else
        {
            txtCantidad.Text = "";
        }

        SeccionModel? seccion = _seccionController.ObtenerTodas().FirstOrDefault(s => s.Id == _producto.SeccionId);

        cmbSeccion.SelectedItem = seccion;
    }

    //RECEPCIÓN DEL PRODUCTO
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Producto", out object? valor) && valor is Producto producto)
        {
            _producto = producto;

            CargarDatosProducto();
        }
    }

    //GUARDADO DE CAMBIOS
    private async void OnGuardarCambiosClicked(object sender, EventArgs e)
    {
        try
        {
            if (_producto is null)
                return;

            string nombre = txtNombre.Text?.Trim() ?? "";

            int? cantidad = null;

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                if (!int.TryParse(txtCantidad.Text, out int cantidadNumerica))
                {
                    await DisplayAlert(
                        "Cantidad incorrecta",
                        "Introduce una cantidad válida.",
                        "Aceptar");

                    return;
                }

                cantidad = cantidadNumerica;
            }

            if (cmbSeccion.SelectedItem is not SeccionModel seccion)
            {
                await DisplayAlert(
                    "Sección",
                    "Selecciona una sección.",
                    "Aceptar");

                return;
            }

            _controller.ModificarProducto(_producto, nombre, cantidad, seccion.Id);

            _controller.Guardar();

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}