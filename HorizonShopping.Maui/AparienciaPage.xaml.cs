using HorizonShopping.Maui.Services;
using HorizonShopping.Maui.Themes;
using Microsoft.Maui.Storage;

namespace HorizonShopping.Maui;

public partial class AparienciaPage : ContentPage
{
    private readonly ThemeService _themeService;

    public AparienciaPage(ThemeService themeService)
    {
        InitializeComponent();

        _themeService = themeService;

        ActualizarSeleccion();
    }

    private void OnLilaClicked(object sender, TappedEventArgs e)
    {
        _themeService.AplicarTema(TemaColor.Lila);
        ActualizarSeleccion();
    }

    private void OnRojoClicked(object sender, TappedEventArgs e)
    {
        _themeService.AplicarTema(TemaColor.Rojo);
        ActualizarSeleccion();
    }

    private void OnVerdeClicked(object sender, TappedEventArgs e)
    {
        _themeService.AplicarTema(TemaColor.Verde);
        ActualizarSeleccion();
    }

    private void OnRosaClicked(object sender, TappedEventArgs e)
    {
        _themeService.AplicarTema(TemaColor.Rosa);
        ActualizarSeleccion();
    }

    private void OnAmarilloClicked(object sender, TappedEventArgs e)
    {
        _themeService.AplicarTema(TemaColor.Amarillo);
        ActualizarSeleccion();
    }

    private void ActualizarSeleccion()
    {
        tickLila.IsVisible = false;
        tickRojo.IsVisible = false;
        tickVerde.IsVisible = false;
        tickRosa.IsVisible = false;
        tickAmarillo.IsVisible = false;

        string temaActual = Preferences.Get("TemaColor", TemaColor.Lila.ToString());

        switch (temaActual)
        {
            case nameof(TemaColor.Lila):
                tickLila.IsVisible = true;
                break;

            case nameof(TemaColor.Rojo):
                tickRojo.IsVisible = true;
                break;

            case nameof(TemaColor.Verde):
                tickVerde.IsVisible = true;
                break;

            case nameof(TemaColor.Rosa):
                tickRosa.IsVisible = true;
                break;

            case nameof(TemaColor.Amarillo):
                tickAmarillo.IsVisible = true;
                break;
        }
    }
}