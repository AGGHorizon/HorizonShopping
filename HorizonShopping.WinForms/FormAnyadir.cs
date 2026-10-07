using HorizonShopping.Core.Controllers;
using HorizonShopping.Core.Enums;
using HorizonShopping.Core.Models;

namespace HorizonShopping.WinForms
{
    public partial class FormAnyadir : Form
    {        
        private Producto? producto;
        private ShoppingController _controller;

        public FormAnyadir(ShoppingController controlador)
        {
            InitializeComponent();
            _controller = controlador;
        }

        public FormAnyadir(Producto producto, ShoppingController controlador)
        {
            InitializeComponent();
            this.producto = producto;
            _controller = controlador;
        }        
        

        //Funciones del formulario
        private void CargarSecciones()
        {
            FuncionesInterfaz.RellenarComboBoxSecciones(cmbSeccion);
            cmbSeccion.SelectedIndex = 0;
        }       

        private void LeerDatos(out string nombre, out int cantidad, out Seccion seccion)
        {
            //Nombre
            nombre = txtProducto.Text;

            //Cantidad                    
            if (!int.TryParse(txtCantidad.Text, out cantidad))
                throw new Exception("La cantidad debe ser un número.");

            //Sección                    
            seccion = (Seccion)cmbSeccion.SelectedItem;
        }


        //Load
        private void FormAnyadir_Load(object sender, EventArgs e)
        {
            CargarSecciones();
            txtProducto.Focus();

            if (producto != null)
            {
                Text = "Editar producto";
                btnAceptar.Text = "Modificar";
                txtProducto.Text = producto.Nombre;
                txtCantidad.Text = producto.Cantidad?.ToString() ?? "";
                cmbSeccion.SelectedItem = producto.Seccion;
            }            
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                LeerDatos(out string nombre, out int cantidad, out Seccion seccion);

                //Edición producto
                if (producto != null)
                {                    
                    _controller.ModificarProducto(producto, nombre, cantidad, seccion);
                }
              

                //Creación producto
                else
                {                   
                    var productoEncontrado = _controller.BuscarProducto(nombre);
                    if (productoEncontrado != null)
                    {
                        if (MessageBox.Show($"El producto {nombre} ya existe en la lista, ¿deseas modificarlo?", "Cambiar", MessageBoxButtons.YesNo) ==
                             DialogResult.Yes)
                        {
                            txtCantidad.SelectAll();
                            _controller.ModificarProducto(productoEncontrado, nombre, cantidad, seccion);
                        }                        
                    }

                    else
                    {
                        _controller.CrearProducto(nombre, cantidad, seccion);
                    }                    

                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
