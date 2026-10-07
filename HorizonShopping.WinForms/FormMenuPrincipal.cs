using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Enums;
using HorizonShopping.Core.Models;
using Microsoft.VisualBasic;

namespace HorizonShopping.WinForms
{
    public partial class FormMenuPrincipal : Form
    {
        private readonly ShoppingController _controller;        
        private readonly ConfigurationController _configController;
        private Configuracion _config;


        Seccion _seccionActual;

        public FormMenuPrincipal(ShoppingController controller, ConfigurationController configurationController)
        {
            InitializeComponent();
            _controller = controller;
            _configController = configurationController;    

            _config = _configController.ObtenerConfiguracion();
        }        


        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            InicializarBotonesSeccion();
            _seccionActual = _config.InicioPantalla;
            MostrarProductos(_seccionActual);
            ActualizarBotones();            
        }

        //*****Funciones del formulario*****              
        private void MostrarProductos(Seccion seccion)
        {
            List<Producto> productos = _controller.ObtenerProductos(seccion);

            lsbCompra.Items.Clear();

            if (productos.Count == 0)
            {
                MessageBox.Show("La lista está vacía.");
                return;
            }            
            
            foreach(Producto producto in productos)
            {
                lsbCompra.Items.Add(producto);
            }            

        }

        private void ActualizarBotones() //bloquear los botones que no se pueda usar
        {
            List<Producto> productos = _controller.ObtenerProductos(_seccionActual);

            if (productos.Count == 0)
            {
                btnDeleteSelected.Enabled = false;
                btnEditar.Enabled = false;
                btnDeleteAll.Enabled = false;
            }

            else
            {
                btnDeleteSelected.Enabled = true;
                btnEditar.Enabled = true;
                btnDeleteAll.Enabled = true;
            }
        }

        private void InicializarBotonesSeccion() //asignación de los Tag
        {
            btnSuperMercado.Tag = Seccion.Supermercado;
            btnMercado.Tag = Seccion.Mercado;
            btnFarmacia.Tag = Seccion.Farmacia;
            btnDrogueria.Tag = Seccion.Drogueria;
            btnErik.Tag = Seccion.Erik;
            btnPiso.Tag = Seccion.Piso;
            btnVerTodo.Tag = Seccion.Todo;
        }

        private void BotonSeccion_Click(object sender, EventArgs e) //todos los buttons de las secciones en uno solo
        {
            Button boton = (Button)sender;
            if(boton.Tag is not Seccion seccion)            
                return;            
           
            _seccionActual = seccion;
            MostrarProductos(_seccionActual);
            ActualizarBotones();
        }
        //--------------------------------------------------------------------------------------------------------------------


        //*****BUTTONS FORMULARIO*****
        private void btnAnyadir_Click(object sender, EventArgs e)
        {
            FormAnyadir formAnyadir = new FormAnyadir(_controller);
            formAnyadir.ShowDialog();

            MostrarProductos(_seccionActual);
            ActualizarBotones();
        }


        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbCompra.SelectedItem is null)
                {
                    MessageBox.Show("Selecciona un producto de la lista antes de continuar.");
                    return;
                }

                var productoSeleccionado = (Producto)lsbCompra.SelectedItem;
                _controller.BorrarProducto(productoSeleccionado);

                MostrarProductos(_seccionActual);
                ActualizarBotones();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lsbCompra.SelectedItem is null)
            {
                MessageBox.Show("Por favor seleccione un producto para editar.");
                return;
            }

            Producto productoSeleccionado = (Producto)lsbCompra.SelectedItem;

            FormAnyadir formAnyadir = new FormAnyadir(productoSeleccionado, _controller);
            formAnyadir.ShowDialog();

            MostrarProductos(_seccionActual);
            ActualizarBotones();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                bool puedeBorrar = true;

                if (_config.ConfirmacionFinalizar)
                {
                    if (MessageBox.Show("¿Estás seguro de finalizar la compra?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show("Compra finalizada");
                    }

                    else
                    {
                        puedeBorrar = false;
                    }
                }

                if (puedeBorrar)
                {
                    _controller.BorrarTodo(_seccionActual);
                    MostrarProductos(_seccionActual);
                    ActualizarBotones();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreBusqueda = Interaction.InputBox("Introduzca el nombre del producto: ");

                Producto? productoEncontrado = _controller.BuscarProducto(nombreBusqueda);
                if (productoEncontrado is null)
                {
                    MessageBox.Show("El producto no existe.");
                    return;
                }

                if (_seccionActual != Seccion.Todo)
                {
                    _seccionActual = Seccion.Todo;
                    MostrarProductos(_seccionActual);
                }

                lsbCompra.SelectedItem = productoEncontrado;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------


        //CIERRE
        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.Guardar();
        }


        //CONFIGURACIÓN
        private void btnOptions_Click(object sender, EventArgs e)
        {
            FormOpciones formOpciones = new FormOpciones(_configController);
            formOpciones.ShowDialog();
        }
    }
}
