using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Models;

namespace HorizonShopping.Maui;

public partial class AddSectionPage : ContentPage
{
    private readonly SeccionController _controller;

    public AddSectionPage(SeccionController controller)
    {
        InitializeComponent();

        _controller = controller;
    }

    private async void OnAñadirSeccionClicked(object sender, EventArgs e)
    {
        try
        {
            string nombre = txtNombre.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                await DisplayAlert(
                    "Sección",
                    "El nombre no puede estar vacío.",
                    "Aceptar");

                return;
            }


            _controller.CrearSeccion(nombre);

            _controller.Guardar();

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }
    }
}