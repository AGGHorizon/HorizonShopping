namespace HorizonShopping.WinForms
{
    partial class FormOpciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpciones));
            label3 = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            label1 = new Label();
            cmbSeccion = new ComboBox();
            chkConfirmacionCompra = new CheckBox();
            label4 = new Label();
            rbClaro = new RadioButton();
            rbOscuro = new RadioButton();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(48, 39);
            label3.Name = "label3";
            label3.Size = new Size(344, 33);
            label3.TabIndex = 14;
            label3.Text = "Inicio pantalla al abrir aplicación: ";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(264, 364);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(109, 48);
            btnAceptar.TabIndex = 13;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightCoral;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(95, 364);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(109, 48);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(68, 174);
            label2.Name = "label2";
            label2.Size = new Size(333, 33);
            label2.TabIndex = 11;
            label2.Text = "Confirmación al finalizar compra";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(77, 61);
            label1.Name = "label1";
            label1.Size = new Size(0, 33);
            label1.TabIndex = 9;
            // 
            // cmbSeccion
            // 
            cmbSeccion.FormattingEnabled = true;
            cmbSeccion.Location = new Point(148, 87);
            cmbSeccion.Name = "cmbSeccion";
            cmbSeccion.Size = new Size(145, 23);
            cmbSeccion.TabIndex = 8;
            // 
            // chkConfirmacionCompra
            // 
            chkConfirmacionCompra.AutoSize = true;
            chkConfirmacionCompra.BackColor = Color.Transparent;
            chkConfirmacionCompra.Location = new Point(47, 187);
            chkConfirmacionCompra.Name = "chkConfirmacionCompra";
            chkConfirmacionCompra.Size = new Size(15, 14);
            chkConfirmacionCompra.TabIndex = 15;
            chkConfirmacionCompra.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(113, 251);
            label4.Name = "label4";
            label4.Size = new Size(74, 33);
            label4.TabIndex = 16;
            label4.Text = "Tema:";
            // 
            // rbClaro
            // 
            rbClaro.AutoSize = true;
            rbClaro.BackColor = Color.Transparent;
            rbClaro.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold);
            rbClaro.ForeColor = Color.White;
            rbClaro.Location = new Point(193, 251);
            rbClaro.Name = "rbClaro";
            rbClaro.Size = new Size(83, 37);
            rbClaro.TabIndex = 20;
            rbClaro.TabStop = true;
            rbClaro.Text = "Claro";
            rbClaro.UseVisualStyleBackColor = false;
            // 
            // rbOscuro
            // 
            rbOscuro.AutoSize = true;
            rbOscuro.BackColor = Color.Transparent;
            rbOscuro.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold);
            rbOscuro.ForeColor = Color.White;
            rbOscuro.Location = new Point(193, 283);
            rbOscuro.Name = "rbOscuro";
            rbOscuro.Size = new Size(99, 37);
            rbOscuro.TabIndex = 21;
            rbOscuro.TabStop = true;
            rbOscuro.Text = "Oscuro";
            rbOscuro.UseVisualStyleBackColor = false;
            // 
            // FormOpciones
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnCancelar;
            ClientSize = new Size(451, 459);
            Controls.Add(rbOscuro);
            Controls.Add(rbClaro);
            Controls.Add(label4);
            Controls.Add(chkConfirmacionCompra);
            Controls.Add(label3);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbSeccion);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOpciones";
            Text = "FormOpciones";
            Load += FormOpciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label2;
        private Label label1;
        private ComboBox cmbSeccion;
        private CheckBox chkConfirmacionCompra;
        private Label label4;
        private RadioButton rbClaro;
        private RadioButton rbOscuro;
    }
}