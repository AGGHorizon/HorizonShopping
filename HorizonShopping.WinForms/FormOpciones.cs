using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Enums;
using HorizonShopping.Core.Models;
using System.Configuration;

namespace HorizonShopping.WinForms
{
    public partial class FormOpciones : Form
    {
        ConfigurationController _configController;
        Configuracion _config;

        public FormOpciones(ConfigurationController configuracionControlador)
        {
            InitializeComponent();
            _configController = configuracionControlador;

            _config = _configController.ObtenerConfiguracion();
        }

        private void FormOpciones_Load(object sender, EventArgs e)
        {
            //Inicio pantalla
            FuncionesInterfaz.RellenarComboBoxSecciones(cmbSeccion);
            cmbSeccion.SelectedItem = _config.InicioPantalla;

            //Confirmación compra
            chkConfirmacionCompra.Checked = _config.ConfirmacionFinalizar;

            //Tema
            rbOscuro.Checked = _config.Tema;
            rbClaro.Checked = !_config.Tema;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seccion pantallaSeleccionada = (Seccion)cmbSeccion.SelectedItem;

            if (cmbSeccion.SelectedItem is not null)
                    pantallaSeleccionada = _config.InicioPantalla;

            
            if (chkConfirmacionCompra.Checked)
            {
                _config.ConfirmacionFinalizar = true;
            }
            else
            {
                _config.ConfirmacionFinalizar = false;
            }

            if (rbOscuro.Checked)
            {
                _config.Tema = true;
            }

            else
            {
                _config.Tema = false;
            }

            _configController.GuardarConfiguracion();
            Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
