namespace HorizonShopping.Maui;

public partial class ConfiguracionPage : ContentPage
{
    public ConfiguracionPage()
    {
        InitializeComponent();
    }

    private async void OnAparienciaClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("AparienciaPage");
    }

    private async void OnAcercaDeClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("AcercaDePage");
    }

    private async void OnSincronizacionClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("SincronizacionPage");
    }
}