using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.Empleados.Clientes
{
    partial class FClientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            LListaClientes = new Label();
            PAgregarCliente = new Panel();
            LNombre = new Label();
            TBNombre = new TextBox();
            LApellido = new Label();
            TBApellido = new TextBox();
            LDni = new Label();
            TBDni = new TextBox();
            LDireccion = new Label();
            TBDireccion = new TextBox();
            LCorreo = new Label();
            TBCorreo = new TextBox();
            LTelefono = new Label();
            TBTelefono = new TextBox();
            BAgregarCliente = new Button();
            LAgregarCliente = new Label();
            PListaClientes = new Panel();
            LBuscarC = new Label();
            label1 = new Label();
            CBFiltroC = new ComboBox();
            TBBuscarC = new TextBox();
            DGListaClientes = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
            colAccion = new DataGridViewButtonColumn();
            PAgregarCliente.SuspendLayout();
            PListaClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaClientes).BeginInit();
            SuspendLayout();
            //
            // LListaClientes
            //
            LListaClientes.AutoSize = true;
            LListaClientes.BackColor = Color.Transparent;
            LListaClientes.Font = new Font("Century Gothic", 20.25F);
            LListaClientes.ForeColor = Color.LightGray;
            LListaClientes.Location = new Point(720, 40);
            LListaClientes.Name = "LListaClientes";
            LListaClientes.Size = new Size(228, 33);
            LListaClientes.TabIndex = 3;
            LListaClientes.Text = "Lista de Clientes";
            //
            // PAgregarCliente
            //
            PAgregarCliente.BackColor = Color.FromArgb(64, 64, 64);
            PAgregarCliente.Controls.Add(LNombre);
            PAgregarCliente.Controls.Add(TBNombre);
            PAgregarCliente.Controls.Add(LApellido);
            PAgregarCliente.Controls.Add(TBApellido);
            PAgregarCliente.Controls.Add(LDni);
            PAgregarCliente.Controls.Add(TBDni);
            PAgregarCliente.Controls.Add(LDireccion);
            PAgregarCliente.Controls.Add(TBDireccion);
            PAgregarCliente.Controls.Add(LCorreo);
            PAgregarCliente.Controls.Add(TBCorreo);
            PAgregarCliente.Controls.Add(LTelefono);
            PAgregarCliente.Controls.Add(TBTelefono);
            PAgregarCliente.Controls.Add(BAgregarCliente);
            PAgregarCliente.Location = new Point(64, 146);
            PAgregarCliente.Name = "PAgregarCliente";
            PAgregarCliente.Size = new Size(280, 457);
            PAgregarCliente.TabIndex = 1;
            //
            // LNombre
            //
            LNombre.Font = new Font("Century Gothic", 14.25F);
            LNombre.ForeColor = Color.LightGray;
            LNombre.Location = new Point(15, 22);
            LNombre.Name = "LNombre";
            LNombre.Size = new Size(100, 23);
            LNombre.TabIndex = 0;
            LNombre.Text = "Nombre";
            //
            // TBNombre
            //
            TBNombre.BackColor = Color.Gainsboro;
            TBNombre.Cursor = Cursors.IBeam;
            TBNombre.Font = new Font("Century Gothic", 12F);
            TBNombre.Location = new Point(15, 48);
            TBNombre.Name = "TBNombre";
            TBNombre.Size = new Size(250, 27);
            TBNombre.TabIndex = 1;
            //
            // LApellido
            //
            LApellido.Font = new Font("Century Gothic", 14.25F);
            LApellido.ForeColor = Color.LightGray;
            LApellido.Location = new Point(15, 82);
            LApellido.Name = "LApellido";
            LApellido.Size = new Size(100, 23);
            LApellido.TabIndex = 2;
            LApellido.Text = "Apellido";
            //
            // TBApellido
            //
            TBApellido.BackColor = Color.Gainsboro;
            TBApellido.Cursor = Cursors.IBeam;
            TBApellido.Font = new Font("Century Gothic", 12F);
            TBApellido.Location = new Point(15, 108);
            TBApellido.Name = "TBApellido";
            TBApellido.Size = new Size(250, 27);
            TBApellido.TabIndex = 3;
            //
            // LDni
            //
            LDni.Font = new Font("Century Gothic", 14.25F);
            LDni.ForeColor = Color.LightGray;
            LDni.Location = new Point(15, 142);
            LDni.Name = "LDni";
            LDni.Size = new Size(100, 23);
            LDni.TabIndex = 4;
            LDni.Text = "DNI";
            //
            // TBDni
            //
            TBDni.BackColor = Color.Gainsboro;
            TBDni.Cursor = Cursors.IBeam;
            TBDni.Font = new Font("Century Gothic", 12F);
            TBDni.Location = new Point(15, 168);
            TBDni.Name = "TBDni";
            TBDni.Size = new Size(250, 27);
            TBDni.TabIndex = 5;
            TBDni.KeyPress += TBNumerico_KeyPress;
            //
            // LDireccion
            //
            LDireccion.Font = new Font("Century Gothic", 14.25F);
            LDireccion.ForeColor = Color.LightGray;
            LDireccion.Location = new Point(15, 203);
            LDireccion.Name = "LDireccion";
            LDireccion.Size = new Size(100, 23);
            LDireccion.TabIndex = 6;
            LDireccion.Text = "Dirección";
            //
            // TBDireccion
            //
            TBDireccion.BackColor = Color.Gainsboro;
            TBDireccion.Cursor = Cursors.IBeam;
            TBDireccion.Font = new Font("Century Gothic", 12F);
            TBDireccion.Location = new Point(15, 229);
            TBDireccion.Name = "TBDireccion";
            TBDireccion.Size = new Size(250, 27);
            TBDireccion.TabIndex = 7;
            //
            // LCorreo
            //
            LCorreo.Font = new Font("Century Gothic", 14.25F);
            LCorreo.ForeColor = Color.LightGray;
            LCorreo.Location = new Point(15, 263);
            LCorreo.Name = "LCorreo";
            LCorreo.Size = new Size(100, 23);
            LCorreo.TabIndex = 8;
            LCorreo.Text = "Correo";
            //
            // TBCorreo
            //
            TBCorreo.BackColor = Color.Gainsboro;
            TBCorreo.Cursor = Cursors.IBeam;
            TBCorreo.Font = new Font("Century Gothic", 12F);
            TBCorreo.Location = new Point(15, 289);
            TBCorreo.Name = "TBCorreo";
            TBCorreo.Size = new Size(250, 27);
            TBCorreo.TabIndex = 9;
            //
            // LTelefono
            //
            LTelefono.Font = new Font("Century Gothic", 14.25F);
            LTelefono.ForeColor = Color.LightGray;
            LTelefono.Location = new Point(15, 323);
            LTelefono.Name = "LTelefono";
            LTelefono.Size = new Size(100, 23);
            LTelefono.TabIndex = 10;
            LTelefono.Text = "Teléfono";
            //
            // TBTelefono
            //
            TBTelefono.BackColor = Color.Gainsboro;
            TBTelefono.Cursor = Cursors.IBeam;
            TBTelefono.Font = new Font("Century Gothic", 12F);
            TBTelefono.Location = new Point(15, 349);
            TBTelefono.Name = "TBTelefono";
            TBTelefono.Size = new Size(250, 27);
            TBTelefono.TabIndex = 11;
            TBTelefono.KeyPress += TBNumerico_KeyPress;
            //
            // BAgregarCliente
            //
            BAgregarCliente.BackColor = Color.YellowGreen;
            BAgregarCliente.Cursor = Cursors.Hand;
            BAgregarCliente.FlatStyle = FlatStyle.Popup;
            BAgregarCliente.Font = new Font("Century Gothic", 14.25F);
            BAgregarCliente.ForeColor = Color.Black;
            BAgregarCliente.Location = new Point(10, 401);
            BAgregarCliente.Name = "BAgregarCliente";
            BAgregarCliente.Size = new Size(255, 33);
            BAgregarCliente.TabIndex = 12;
            BAgregarCliente.Text = "Agregar Cliente";
            BAgregarCliente.UseVisualStyleBackColor = false;
            BAgregarCliente.Click += BAgregarCliente_Click;
            //
            // LAgregarCliente
            //
            LAgregarCliente.AutoSize = true;
            LAgregarCliente.BackColor = Color.Transparent;
            LAgregarCliente.Font = new Font("Century Gothic", 20.25F);
            LAgregarCliente.ForeColor = Color.LightGray;
            LAgregarCliente.Location = new Point(98, 89);
            LAgregarCliente.Name = "LAgregarCliente";
            LAgregarCliente.Size = new Size(225, 33);
            LAgregarCliente.TabIndex = 0;
            LAgregarCliente.Text = "Agregar Cliente";
            //
            // PListaClientes
            //
            PListaClientes.BackColor = Color.Transparent;
            PListaClientes.Controls.Add(LBuscarC);
            PListaClientes.Controls.Add(label1);
            PListaClientes.Controls.Add(CBFiltroC);
            PListaClientes.Controls.Add(TBBuscarC);
            PListaClientes.Controls.Add(DGListaClientes);
            PListaClientes.Location = new Point(384, 100);
            PListaClientes.Name = "PListaClientes";
            PListaClientes.Size = new Size(883, 503);
            PListaClientes.TabIndex = 2;
            //
            // LBuscarC
            //
            LBuscarC.AutoSize = true;
            LBuscarC.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBuscarC.ForeColor = Color.LightGray;
            LBuscarC.Location = new Point(18, 14);
            LBuscarC.Name = "LBuscarC";
            LBuscarC.Size = new Size(81, 22);
            LBuscarC.TabIndex = 7;
            LBuscarC.Text = "Buscar: ";
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.25F);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(637, 12);
            label1.Name = "label1";
            label1.Size = new Size(62, 22);
            label1.TabIndex = 6;
            label1.Text = "Filtrar:";
            //
            // CBFiltroC
            //
            CBFiltroC.BackColor = Color.LightGray;
            CBFiltroC.Cursor = Cursors.Hand;
            CBFiltroC.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFiltroC.Font = new Font("Century Gothic", 12F);
            CBFiltroC.FormattingEnabled = true;
            CBFiltroC.Location = new Point(714, 10);
            CBFiltroC.Name = "CBFiltroC";
            CBFiltroC.Size = new Size(168, 29);
            CBFiltroC.TabIndex = 5;
            //
            // TBBuscarC
            //
            TBBuscarC.BackColor = Color.FromArgb(64, 64, 64);
            TBBuscarC.BorderStyle = BorderStyle.FixedSingle;
            TBBuscarC.Cursor = Cursors.IBeam;
            TBBuscarC.Font = new Font("Century Gothic", 12F);
            TBBuscarC.ForeColor = Color.LightGray;
            TBBuscarC.Location = new Point(105, 11);
            TBBuscarC.Name = "TBBuscarC";
            TBBuscarC.PlaceholderText = "  Cliente...";
            TBBuscarC.Size = new Size(213, 27);
            TBBuscarC.TabIndex = 4;
            //
            // DGListaClientes
            //
            DGListaClientes.AllowUserToAddRows = false;
            DGListaClientes.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGListaClientes.BorderStyle = BorderStyle.None;
            DGListaClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            DGListaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGListaClientes.ColumnHeadersHeight = 25;
            DGListaClientes.Columns.AddRange(new DataGridViewColumn[] { colNombre, colApellido, colDni, colDireccion, colCorreo, colTelefono, colEstado, colEditar, colAccion });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 11F);
            dataGridViewCellStyle3.ForeColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DGListaClientes.DefaultCellStyle = dataGridViewCellStyle3;
            DGListaClientes.EnableHeadersVisualStyles = false;
            DGListaClientes.GridColor = Color.Black;
            DGListaClientes.Location = new Point(0, 57);
            DGListaClientes.Name = "DGListaClientes";
            DGListaClientes.RowHeadersVisible = false;
            DGListaClientes.RowTemplate.Height = 40;
            DGListaClientes.Size = new Size(883, 446);
            DGListaClientes.TabIndex = 0;
            //
            // colNombre
            //
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Width = 107;
            //
            // colApellido
            //
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.Width = 107;
            //
            // colDni
            //
            colDni.HeaderText = "DNI";
            colDni.Name = "colDni";
            colDni.Width = 107;
            //
            // colDireccion
            //
            colDireccion.HeaderText = "Dirección";
            colDireccion.Name = "colDireccion";
            colDireccion.Width = 107;
            //
            // colCorreo
            //
            colCorreo.HeaderText = "Correo";
            colCorreo.Name = "colCorreo";
            colCorreo.Width = 107;
            //
            // colTelefono
            //
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.Width = 107;
            //
            // colEstado
            //
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            //
            // colEditar
            //
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightGreen;
            dataGridViewCellStyle2.ForeColor = Color.Black;
            colEditar.DefaultCellStyle = dataGridViewCellStyle2;
            colEditar.FlatStyle = FlatStyle.Flat;
            colEditar.HeaderText = "E";
            colEditar.Name = "colEditar";
            colEditar.Text = "Editar";
            colEditar.UseColumnTextForButtonValue = true;
            colEditar.Width = 65;
            //
            // colAccion
            //
            colAccion.FlatStyle = FlatStyle.Flat;
            colAccion.HeaderText = "Acción";
            colAccion.Name = "colAccion";
            colAccion.Width = 75;
            //
            // FClientes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1334, 659);
            Controls.Add(LAgregarCliente);
            Controls.Add(PAgregarCliente);
            Controls.Add(PListaClientes);
            Controls.Add(LListaClientes);
            Name = "FClientes";
            Text = "Lista de Clientes";
            PAgregarCliente.ResumeLayout(false);
            PAgregarCliente.PerformLayout();
            PListaClientes.ResumeLayout(false);
            PListaClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label LListaClientes;
        private Panel PAgregarCliente;
        private Label LAgregarCliente;
        private Panel PListaClientes;
        private TextBox TBNombre, TBApellido, TBDni, TBDireccion, TBCorreo, TBTelefono;
        private Label LNombre, LApellido, LDni, LDireccion, LCorreo, LTelefono;
        private Button BAgregarCliente;
        private DataGridView DGListaClientes;
        private DataGridViewTextBoxColumn colNombre, colApellido, colDni, colDireccion, colCorreo, colTelefono, colEstado;
        private DataGridViewButtonColumn colEditar, colAccion;
        private TextBox TBBuscarC;
        private Label label1;
        private ComboBox CBFiltroC;
        private Label LBuscarC;
    }
}