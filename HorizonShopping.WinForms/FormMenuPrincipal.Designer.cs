namespace HorizonShopping.WinForms
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            lbltitle = new Label();
            btnSuperMercado = new Button();
            lsbCompra = new ListBox();
            btnFarmacia = new Button();
            btnDrogueria = new Button();
            btnErik = new Button();
            btnPiso = new Button();
            btnDeleteAll = new Button();
            btnDeleteSelected = new Button();
            btnAnyadir = new Button();
            btnVerTodo = new Button();
            btnEditar = new Button();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            btnMercado = new Button();
            btnBuscar = new Button();
            btnClose = new Button();
            btnOptions = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbltitle
            // 
            lbltitle.AutoSize = true;
            lbltitle.BackColor = Color.Transparent;
            lbltitle.Font = new Font("MV Boli", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitle.ForeColor = Color.White;
            lbltitle.Location = new Point(304, 19);
            lbltitle.Name = "lbltitle";
            lbltitle.Size = new Size(357, 39);
            lbltitle.TabIndex = 0;
            lbltitle.Text = "LISTA DE LA COMPRA";
            // 
            // btnSuperMercado
            // 
            btnSuperMercado.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSuperMercado.BackgroundImage = (Image)resources.GetObject("btnSuperMercado.BackgroundImage");
            btnSuperMercado.BackgroundImageLayout = ImageLayout.Stretch;
            btnSuperMercado.FlatStyle = FlatStyle.Popup;
            btnSuperMercado.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSuperMercado.Location = new Point(25, 77);
            btnSuperMercado.Name = "btnSuperMercado";
            btnSuperMercado.Size = new Size(141, 48);
            btnSuperMercado.TabIndex = 2;
            btnSuperMercado.Tag = "";
            btnSuperMercado.UseVisualStyleBackColor = true;
            btnSuperMercado.Click += BotonSeccion_Click;
            // 
            // lsbCompra
            // 
            lsbCompra.BorderStyle = BorderStyle.None;
            lsbCompra.Font = new Font("MV Boli", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lsbCompra.FormattingEnabled = true;
            lsbCompra.ItemHeight = 31;
            lsbCompra.Location = new Point(304, 237);
            lsbCompra.Name = "lsbCompra";
            lsbCompra.Size = new Size(396, 372);
            lsbCompra.TabIndex = 4;
            // 
            // btnFarmacia
            // 
            btnFarmacia.BackgroundImage = (Image)resources.GetObject("btnFarmacia.BackgroundImage");
            btnFarmacia.BackgroundImageLayout = ImageLayout.Stretch;
            btnFarmacia.FlatStyle = FlatStyle.Popup;
            btnFarmacia.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F);
            btnFarmacia.Location = new Point(351, 77);
            btnFarmacia.Name = "btnFarmacia";
            btnFarmacia.Size = new Size(141, 48);
            btnFarmacia.TabIndex = 5;
            btnFarmacia.Tag = "";
            btnFarmacia.UseVisualStyleBackColor = true;
            btnFarmacia.Click += BotonSeccion_Click;
            // 
            // btnDrogueria
            // 
            btnDrogueria.BackgroundImage = (Image)resources.GetObject("btnDrogueria.BackgroundImage");
            btnDrogueria.BackgroundImageLayout = ImageLayout.Stretch;
            btnDrogueria.FlatStyle = FlatStyle.Popup;
            btnDrogueria.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F);
            btnDrogueria.Location = new Point(520, 77);
            btnDrogueria.Name = "btnDrogueria";
            btnDrogueria.Size = new Size(141, 48);
            btnDrogueria.TabIndex = 6;
            btnDrogueria.Tag = "";
            btnDrogueria.UseVisualStyleBackColor = true;
            btnDrogueria.Click += BotonSeccion_Click;
            // 
            // btnErik
            // 
            btnErik.BackgroundImage = (Image)resources.GetObject("btnErik.BackgroundImage");
            btnErik.BackgroundImageLayout = ImageLayout.Stretch;
            btnErik.FlatStyle = FlatStyle.Popup;
            btnErik.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F);
            btnErik.Location = new Point(684, 77);
            btnErik.Name = "btnErik";
            btnErik.Size = new Size(141, 48);
            btnErik.TabIndex = 7;
            btnErik.Tag = "";
            btnErik.UseVisualStyleBackColor = true;
            btnErik.Click += BotonSeccion_Click;
            // 
            // btnPiso
            // 
            btnPiso.BackgroundImage = (Image)resources.GetObject("btnPiso.BackgroundImage");
            btnPiso.BackgroundImageLayout = ImageLayout.Stretch;
            btnPiso.FlatStyle = FlatStyle.Popup;
            btnPiso.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F);
            btnPiso.Location = new Point(848, 77);
            btnPiso.Name = "btnPiso";
            btnPiso.Size = new Size(141, 48);
            btnPiso.TabIndex = 8;
            btnPiso.Tag = "";
            btnPiso.UseVisualStyleBackColor = true;
            btnPiso.Click += BotonSeccion_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.BackColor = Color.FromArgb(255, 192, 192);
            btnDeleteAll.BackgroundImage = (Image)resources.GetObject("btnDeleteAll.BackgroundImage");
            btnDeleteAll.BackgroundImageLayout = ImageLayout.Stretch;
            btnDeleteAll.FlatStyle = FlatStyle.Popup;
            btnDeleteAll.Location = new Point(380, 644);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(255, 72);
            btnDeleteAll.TabIndex = 9;
            btnDeleteAll.UseVisualStyleBackColor = false;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.BackgroundImage = (Image)resources.GetObject("btnDeleteSelected.BackgroundImage");
            btnDeleteSelected.BackgroundImageLayout = ImageLayout.Stretch;
            btnDeleteSelected.FlatStyle = FlatStyle.Popup;
            btnDeleteSelected.Location = new Point(37, 49);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(160, 54);
            btnDeleteSelected.TabIndex = 10;
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackgroundImage = (Image)resources.GetObject("btnAnyadir.BackgroundImage");
            btnAnyadir.BackgroundImageLayout = ImageLayout.Stretch;
            btnAnyadir.FlatStyle = FlatStyle.Popup;
            btnAnyadir.Location = new Point(82, 281);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(179, 138);
            btnAnyadir.TabIndex = 11;
            btnAnyadir.UseVisualStyleBackColor = true;
            btnAnyadir.Click += btnAnyadir_Click;
            // 
            // btnVerTodo
            // 
            btnVerTodo.BackgroundImage = (Image)resources.GetObject("btnVerTodo.BackgroundImage");
            btnVerTodo.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerTodo.FlatStyle = FlatStyle.Popup;
            btnVerTodo.Location = new Point(447, 161);
            btnVerTodo.Name = "btnVerTodo";
            btnVerTodo.Size = new Size(122, 39);
            btnVerTodo.TabIndex = 14;
            btnVerTodo.Tag = "";
            btnVerTodo.UseVisualStyleBackColor = true;
            btnVerTodo.Click += BotonSeccion_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackgroundImage = (Image)resources.GetObject("btnEditar.BackgroundImage");
            btnEditar.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.Location = new Point(37, 133);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(160, 54);
            btnEditar.TabIndex = 15;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnDeleteSelected);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(738, 299);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(231, 213);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccione un producto de la lista";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(834, 597);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // btnMercado
            // 
            btnMercado.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMercado.BackgroundImage = (Image)resources.GetObject("btnMercado.BackgroundImage");
            btnMercado.BackgroundImageLayout = ImageLayout.Stretch;
            btnMercado.FlatStyle = FlatStyle.Popup;
            btnMercado.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F);
            btnMercado.Location = new Point(188, 77);
            btnMercado.Name = "btnMercado";
            btnMercado.Size = new Size(141, 48);
            btnMercado.TabIndex = 12;
            btnMercado.Tag = "";
            btnMercado.UseVisualStyleBackColor = true;
            btnMercado.Click += BotonSeccion_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(82, 463);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(179, 49);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(203, 693);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 18;
            btnClose.Text = "SALIR";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnOptions
            // 
            btnOptions.Location = new Point(12, 713);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(75, 23);
            btnOptions.TabIndex = 19;
            btnOptions.Text = "OPCIONES";
            btnOptions.UseVisualStyleBackColor = true;
            btnOptions.Click += btnOptions_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1028, 757);
            Controls.Add(btnOptions);
            Controls.Add(btnClose);
            Controls.Add(btnBuscar);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Controls.Add(btnVerTodo);
            Controls.Add(btnMercado);
            Controls.Add(btnAnyadir);
            Controls.Add(btnDeleteAll);
            Controls.Add(btnPiso);
            Controls.Add(btnErik);
            Controls.Add(btnDrogueria);
            Controls.Add(btnFarmacia);
            Controls.Add(lsbCompra);
            Controls.Add(btnSuperMercado);
            Controls.Add(lbltitle);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMenuPrincipal";
            Text = "AGG Horizon";
            FormClosing += FormMenuPrincipal_FormClosing;
            Load += FormMenuPrincipal_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltitle;
        private Button btnSuperMercado;
        private ListBox lsbCompra;
        private Button btnFarmacia;
        private Button btnDrogueria;
        private Button btnErik;
        private Button btnPiso;
        private Button btnDeleteAll;
        private Button btnDeleteSelected;
        private Button btnAnyadir;
        private Button btnVerTodo;
        private Button btnEditar;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button btnMercado;
        private Button btnBuscar;
        private Button btnClose;
        private Button btnOptions;
    }
}
