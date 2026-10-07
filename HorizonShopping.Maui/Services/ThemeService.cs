using HorizonShopping.Maui.Themes;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;

namespace HorizonShopping.Maui.Services
{
    public class ThemeService
    {
        private const string ClaveTema = "TemaColor";

        public Color ColorPrincipal { get; private set; } = Color.FromArgb("#512BD4");

        public string LogoActual { get; private set; } = "logohorizonshopping_lila.png";

        public void AplicarTema(TemaColor tema)
        {
            switch (tema)
            {
                case TemaColor.Lila:
                    ColorPrincipal = Color.FromArgb("#512BD4");
                    LogoActual = "logohorizonshopping_lila.png";
                    break;

                case TemaColor.Rojo:
                    ColorPrincipal = Color.FromArgb("#E57373");
                    LogoActual = "logohorizonshopping_rojo.png";
                    break;

                case TemaColor.Verde:
                    ColorPrincipal = Color.FromArgb("#66BB6A");
                    LogoActual = "logohorizonshopping_verde.png";
                    break;

                case TemaColor.Rosa:
                    ColorPrincipal = Color.FromArgb("#EC77B5");
                    LogoActual = "logohorizonshopping_rosa.png";
                    break;

                case TemaColor.Amarillo:
                    ColorPrincipal = Color.FromArgb("#FBC02D");
                    LogoActual = "logohorizonshopping_amarillo.png";
                    break;
            }

            Preferences.Set(ClaveTema, tema.ToString());

            ActualizarRecursos();
        }

        public void CargarTemaGuardado()
        {
            string temaGuardado = Preferences.Get(ClaveTema, TemaColor.Lila.ToString());

            if (Enum.TryParse(temaGuardado, out TemaColor tema))
            {
                AplicarTema(tema);
            }
            else
            {
                AplicarTema(TemaColor.Lila);
            }
        }

        private void ActualizarRecursos()
        {
            if (Application.Current is null)
                return;

            Application.Current.Resources["ColorPrincipal"] = ColorPrincipal;
            Application.Current.Resources["ColorTextoBoton"] = Colors.White;
            Application.Current.Resources["LogoHorizonShopping"] = LogoActual;
        }
    }
}