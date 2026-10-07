namespace HorizonShopping.WinForms
{
    partial class FormAnyadir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadir));
            cmbSeccion = new ComboBox();
            label1 = new Label();
            txtProducto = new TextBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            label3 = new Label();
            txtCantidad = new TextBox();
            SuspendLayout();
            // 
            // cmbSeccion
            // 
            cmbSeccion.FormattingEnabled = true;
            cmbSeccion.Location = new Point(171, 282);
            cmbSeccion.Name = "cmbSeccion";
            cmbSeccion.Size = new Size(145, 23);
            cmbSeccion.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 55);
            label1.Name = "label1";
            label1.Size = new Size(118, 33);
            label1.TabIndex = 1;
            label1.Text = "Producto: ";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(167, 55);
            txtProducto.Multiline = true;
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(217, 44);
            txtProducto.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(197, 236);
            label2.Name = "label2";
            label2.Size = new Size(100, 33);
            label2.TabIndex = 3;
            label2.Text = "Sección: ";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightCoral;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(104, 351);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(109, 48);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(273, 351);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(109, 48);
            btnAceptar.TabIndex = 5;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(42, 143);
            label3.Name = "label3";
            label3.Size = new Size(109, 33);
            label3.TabIndex = 6;
            label3.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(167, 144);
            txtCantidad.Multiline = true;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(44, 32);
            txtCantidad.TabIndex = 7;
            // 
            // FormAnyadir
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnCancelar;
            ClientSize = new Size(498, 468);
            Controls.Add(txtCantidad);
            Controls.Add(label3);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(txtProducto);
            Controls.Add(label1);
            Controls.Add(cmbSeccion);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAnyadir";
            Text = "Añadir a la lista";
            Load += FormAnyadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSeccion;
        private Label label1;
        private TextBox txtProducto;
        private Label label2;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label3;
        private TextBox txtCantidad;
    }
}