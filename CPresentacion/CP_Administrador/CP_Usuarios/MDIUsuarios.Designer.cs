namespace AurenPadelStore.CPresentacion.CP_Administrador.CP_Usuarios
{
    partial class MDIUsuarios
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIUsuarios));
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            printSetupToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editMenu = new ToolStripMenuItem();
            viewMenu = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            panel1 = new Panel();
            PAgregarUs = new Panel();
            LDniUs = new Label();
            TBApellidoUs = new TextBox();
            LApellidoUs = new Label();
            label1 = new Label();
            TBNombreUs = new TextBox();
            LNombreUs = new Label();
            LAgregarUs = new Label();
            TBDniUs = new TextBox();
            LRolUs = new Label();
            CBRolUs = new ComboBox();
            BAgregarUs = new Button();
            panel2 = new Panel();
            TPUsuarios = new TableLayoutPanel();
            LTabDniUs = new Label();
            LTabNombreUs = new Label();
            LTabApellidoUs = new Label();
            LTabRolUs = new Label();
            LTabEliminarUs = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            LTabEditarUs = new Label();
            menuStrip.SuspendLayout();
            panel1.SuspendLayout();
            PAgregarUs.SuspendLayout();
            panel2.SuspendLayout();
            TPUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(812, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator3, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator4, printToolStripMenuItem, printPreviewToolStripMenuItem, printSetupToolStripMenuItem, toolStripSeparator5, exitToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(48, 20);
            fileMenu.Text = "&Inicio";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Black;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(206, 22);
            newToolStripMenuItem.Text = "&Nuevo";
            newToolStripMenuItem.Click += ShowNewForm;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Black;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(206, 22);
            openToolStripMenuItem.Text = "&Abrir";
            openToolStripMenuItem.Click += OpenFile;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(203, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Black;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(206, 22);
            saveToolStripMenuItem.Text = "&Guardar";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(206, 22);
            saveAsToolStripMenuItem.Text = "Guardar &como";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(203, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = Color.Black;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(206, 22);
            printToolStripMenuItem.Text = "&Imprimir";
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.Image = (Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageTransparentColor = Color.Black;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new Size(206, 22);
            printPreviewToolStripMenuItem.Text = "&Vista previa de impresión";
            // 
            // printSetupToolStripMenuItem
            // 
            printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            printSetupToolStripMenuItem.Size = new Size(206, 22);
            printSetupToolStripMenuItem.Text = "Configurar impresión";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(203, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(206, 22);
            exitToolStripMenuItem.Text = "&Salir";
            exitToolStripMenuItem.Click += ExitToolsStripMenuItem_Click;
            // 
            // editMenu
            // 
            editMenu.Name = "editMenu";
            editMenu.Size = new Size(64, 20);
            editMenu.Text = "&Usuarios";
            // 
            // viewMenu
            // 
            viewMenu.Name = "viewMenu";
            viewMenu.Size = new Size(79, 20);
            viewMenu.Text = "&Estadísticas";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(PAgregarUs);
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(812, 421);
            panel1.TabIndex = 4;
            // 
            // PAgregarUs
            // 
            PAgregarUs.BackColor = Color.Transparent;
            PAgregarUs.BorderStyle = BorderStyle.FixedSingle;
            PAgregarUs.Controls.Add(BAgregarUs);
            PAgregarUs.Controls.Add(CBRolUs);
            PAgregarUs.Controls.Add(LRolUs);
            PAgregarUs.Controls.Add(TBDniUs);
            PAgregarUs.Controls.Add(LDniUs);
            PAgregarUs.Controls.Add(TBApellidoUs);
            PAgregarUs.Controls.Add(LApellidoUs);
            PAgregarUs.Controls.Add(label1);
            PAgregarUs.Controls.Add(TBNombreUs);
            PAgregarUs.Controls.Add(LNombreUs);
            PAgregarUs.Controls.Add(LAgregarUs);
            PAgregarUs.Location = new Point(22, 34);
            PAgregarUs.Name = "PAgregarUs";
            PAgregarUs.Size = new Size(260, 345);
            PAgregarUs.TabIndex = 0;
            // 
            // LDniUs
            // 
            LDniUs.AutoSize = true;
            LDniUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LDniUs.ForeColor = Color.LightGray;
            LDniUs.Location = new Point(45, 180);
            LDniUs.Name = "LDniUs";
            LDniUs.Size = new Size(63, 22);
            LDniUs.TabIndex = 1;
            LDniUs.Text = "D.N.I.:";
            // 
            // TBApellidoUs
            // 
            TBApellidoUs.BackColor = Color.LightGray;
            TBApellidoUs.BorderStyle = BorderStyle.FixedSingle;
            TBApellidoUs.Cursor = Cursors.IBeam;
            TBApellidoUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBApellidoUs.Location = new Point(114, 122);
            TBApellidoUs.Name = "TBApellidoUs";
            TBApellidoUs.Size = new Size(126, 31);
            TBApellidoUs.TabIndex = 1;
            // 
            // LApellidoUs
            // 
            LApellidoUs.AutoSize = true;
            LApellidoUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LApellidoUs.ForeColor = Color.LightGray;
            LApellidoUs.Location = new Point(19, 131);
            LApellidoUs.Name = "LApellidoUs";
            LApellidoUs.Size = new Size(89, 22);
            LApellidoUs.TabIndex = 1;
            LApellidoUs.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // TBNombreUs
            // 
            TBNombreUs.BackColor = Color.LightGray;
            TBNombreUs.BorderStyle = BorderStyle.FixedSingle;
            TBNombreUs.Cursor = Cursors.IBeam;
            TBNombreUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBNombreUs.Location = new Point(114, 75);
            TBNombreUs.Name = "TBNombreUs";
            TBNombreUs.Size = new Size(126, 31);
            TBNombreUs.TabIndex = 1;
            // 
            // LNombreUs
            // 
            LNombreUs.AutoSize = true;
            LNombreUs.BackColor = Color.Transparent;
            LNombreUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LNombreUs.ForeColor = Color.LightGray;
            LNombreUs.Location = new Point(19, 84);
            LNombreUs.Name = "LNombreUs";
            LNombreUs.Size = new Size(89, 22);
            LNombreUs.TabIndex = 1;
            LNombreUs.Text = "Nombre:";
            // 
            // LAgregarUs
            // 
            LAgregarUs.AutoSize = true;
            LAgregarUs.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LAgregarUs.ForeColor = Color.LightGray;
            LAgregarUs.Location = new Point(28, 17);
            LAgregarUs.Name = "LAgregarUs";
            LAgregarUs.Size = new Size(201, 28);
            LAgregarUs.TabIndex = 1;
            LAgregarUs.Text = "Agregar Usuario";
            // 
            // TBDniUs
            // 
            TBDniUs.BackColor = Color.LightGray;
            TBDniUs.BorderStyle = BorderStyle.FixedSingle;
            TBDniUs.Cursor = Cursors.IBeam;
            TBDniUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBDniUs.Location = new Point(114, 171);
            TBDniUs.Name = "TBDniUs";
            TBDniUs.Size = new Size(126, 31);
            TBDniUs.TabIndex = 1;
            // 
            // LRolUs
            // 
            LRolUs.AutoSize = true;
            LRolUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LRolUs.ForeColor = Color.LightGray;
            LRolUs.Location = new Point(63, 225);
            LRolUs.Name = "LRolUs";
            LRolUs.Size = new Size(42, 22);
            LRolUs.TabIndex = 1;
            LRolUs.Text = "Rol:";
            // 
            // CBRolUs
            // 
            CBRolUs.Cursor = Cursors.Hand;
            CBRolUs.DropDownStyle = ComboBoxStyle.DropDownList;
            CBRolUs.FlatStyle = FlatStyle.System;
            CBRolUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBRolUs.ForeColor = Color.LightGray;
            CBRolUs.FormattingEnabled = true;
            CBRolUs.Items.AddRange(new object[] { "Administrador", "Gerente", "Empleado" });
            CBRolUs.Location = new Point(114, 217);
            CBRolUs.Name = "CBRolUs";
            CBRolUs.Size = new Size(126, 30);
            CBRolUs.TabIndex = 3;
            // 
            // BAgregarUs
            // 
            BAgregarUs.BackColor = Color.YellowGreen;
            BAgregarUs.FlatStyle = FlatStyle.Popup;
            BAgregarUs.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BAgregarUs.Location = new Point(63, 286);
            BAgregarUs.Name = "BAgregarUs";
            BAgregarUs.Size = new Size(131, 35);
            BAgregarUs.TabIndex = 1;
            BAgregarUs.Text = "AGREGAR";
            BAgregarUs.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(TPUsuarios);
            panel2.Location = new Point(317, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(464, 345);
            panel2.TabIndex = 1;
            // 
            // TPUsuarios
            // 
            TPUsuarios.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TPUsuarios.ColumnCount = 6;
            TPUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.6410255F));
            TPUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.3589745F));
            TPUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            TPUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            TPUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 31F));
            TPUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            TPUsuarios.Controls.Add(LTabDniUs, 0, 0);
            TPUsuarios.Controls.Add(LTabNombreUs, 1, 0);
            TPUsuarios.Controls.Add(LTabApellidoUs, 2, 0);
            TPUsuarios.Controls.Add(LTabRolUs, 3, 0);
            TPUsuarios.Controls.Add(LTabEliminarUs, 4, 0);
            TPUsuarios.Controls.Add(label2, 0, 1);
            TPUsuarios.Controls.Add(label3, 1, 1);
            TPUsuarios.Controls.Add(label4, 2, 1);
            TPUsuarios.Controls.Add(label5, 3, 1);
            TPUsuarios.Controls.Add(pictureBox1, 4, 1);
            TPUsuarios.Controls.Add(pictureBox2, 5, 1);
            TPUsuarios.Controls.Add(LTabEditarUs, 5, 0);
            TPUsuarios.Location = new Point(0, 0);
            TPUsuarios.Name = "TPUsuarios";
            TPUsuarios.RightToLeft = RightToLeft.No;
            TPUsuarios.RowCount = 3;
            TPUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TPUsuarios.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            TPUsuarios.RowStyles.Add(new RowStyle(SizeType.Absolute, 288F));
            TPUsuarios.Size = new Size(463, 344);
            TPUsuarios.TabIndex = 0;
            // 
            // LTabDniUs
            // 
            LTabDniUs.Anchor = AnchorStyles.None;
            LTabDniUs.AutoSize = true;
            LTabDniUs.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            LTabDniUs.ForeColor = Color.LightGray;
            LTabDniUs.Location = new Point(24, 3);
            LTabDniUs.Name = "LTabDniUs";
            LTabDniUs.Size = new Size(48, 19);
            LTabDniUs.TabIndex = 4;
            LTabDniUs.Text = "D.N.I.";
            LTabDniUs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LTabNombreUs
            // 
            LTabNombreUs.Anchor = AnchorStyles.None;
            LTabNombreUs.AutoSize = true;
            LTabNombreUs.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            LTabNombreUs.ForeColor = Color.LightGray;
            LTabNombreUs.Location = new Point(105, 3);
            LTabNombreUs.Name = "LTabNombreUs";
            LTabNombreUs.Size = new Size(73, 19);
            LTabNombreUs.TabIndex = 5;
            LTabNombreUs.Text = "Nombre";
            LTabNombreUs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LTabApellidoUs
            // 
            LTabApellidoUs.Anchor = AnchorStyles.None;
            LTabApellidoUs.AutoSize = true;
            LTabApellidoUs.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            LTabApellidoUs.ForeColor = Color.LightGray;
            LTabApellidoUs.Location = new Point(198, 3);
            LTabApellidoUs.Name = "LTabApellidoUs";
            LTabApellidoUs.Size = new Size(75, 19);
            LTabApellidoUs.TabIndex = 6;
            LTabApellidoUs.Text = "Apellido";
            LTabApellidoUs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LTabRolUs
            // 
            LTabRolUs.Anchor = AnchorStyles.None;
            LTabRolUs.AutoSize = true;
            LTabRolUs.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            LTabRolUs.ForeColor = Color.LightGray;
            LTabRolUs.Location = new Point(325, 3);
            LTabRolUs.Name = "LTabRolUs";
            LTabRolUs.Size = new Size(32, 19);
            LTabRolUs.TabIndex = 7;
            LTabRolUs.Text = "Rol";
            LTabRolUs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LTabEliminarUs
            // 
            LTabEliminarUs.Anchor = AnchorStyles.None;
            LTabEliminarUs.AutoSize = true;
            LTabEliminarUs.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            LTabEliminarUs.ForeColor = Color.LightGray;
            LTabEliminarUs.Location = new Point(404, 3);
            LTabEliminarUs.Name = "LTabEliminarUs";
            LTabEliminarUs.Size = new Size(20, 19);
            LTabEliminarUs.TabIndex = 8;
            LTabEliminarUs.Text = "X";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(7, 29);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 9;
            label2.Text = "40234111";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(117, 29);
            label3.Name = "label3";
            label3.Size = new Size(49, 21);
            label3.TabIndex = 10;
            label3.Text = "Juan";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F);
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(210, 29);
            label4.Name = "label4";
            label4.Size = new Size(51, 21);
            label4.TabIndex = 11;
            label4.Text = "Perez";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(297, 29);
            label5.Name = "label5";
            label5.Size = new Size(88, 21);
            label5.TabIndex = 12;
            label5.Text = "Vendedor";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(402, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 23);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(434, 28);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 23);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // LTabEditarUs
            // 
            LTabEditarUs.Anchor = AnchorStyles.None;
            LTabEditarUs.AutoSize = true;
            LTabEditarUs.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LTabEditarUs.ForeColor = Color.LightGray;
            LTabEditarUs.Location = new Point(438, 3);
            LTabEditarUs.Name = "LTabEditarUs";
            LTabEditarUs.Size = new Size(17, 19);
            LTabEditarUs.TabIndex = 14;
            LTabEditarUs.Text = "E";
            // 
            // MDIUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIUsuarios";
            Text = "Administrador";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panel1.ResumeLayout(false);
            PAgregarUs.ResumeLayout(false);
            PAgregarUs.PerformLayout();
            panel2.ResumeLayout(false);
            TPUsuarios.ResumeLayout(false);
            TPUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private Panel panel1;
        private Panel PAgregarUs;
        private TextBox TBNombreUs;
        private Label LNombreUs;
        private Label LAgregarUs;
        private Label label1;
        private TextBox TBApellidoUs;
        private Label LApellidoUs;
        private Label LDniUs;
        private Label LRolUs;
        private TextBox TBDniUs;
        private Panel panel2;
        private Button BAgregarUs;
        private ComboBox CBRolUs;
        private TableLayoutPanel TPUsuarios;
        private Label LTabDniUs;
        private Label LTabNombreUs;
        private Label LTabApellidoUs;
        private Label LTabRolUs;
        private Label LTabEliminarUs;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label LTabEditarUs;
    }
}



