using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;

namespace HorizonShopping.Maui;

public partial class EditSectionPage : ContentPage, IQueryAttributable
{
    private readonly SeccionController _controller;

    private SeccionModel? _seccion;

    public EditSectionPage(SeccionController controller)
    {
        InitializeComponent();

        _controller = controller;
    }

    //RECEPCIÓN DE LA SECCIÓN
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Seccion", out object? valor) && valor is SeccionModel seccion)
        {
            _seccion = seccion;

            txtNombre.Text = seccion.Nombre;
        }
    }

    //GUARDADO DE CAMBIOS
    private async void OnGuardarCambiosClicked(object sender, EventArgs e)
    {
        try
        {
            if (_seccion is null)
                return;

            string nuevoNombre = txtNombre.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                await DisplayAlert(
                    "Sección",
                    "El nombre no puede estar vacío.",
                    "Aceptar");

                return;
            }

      
            _controller.ModificarSeccion(_seccion, nuevoNombre);

            _controller.Guardar();

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}