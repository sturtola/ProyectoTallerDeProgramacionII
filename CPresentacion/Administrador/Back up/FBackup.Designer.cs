namespace AurenPadelStore.CPresentacion.Administrador.Backup
{
    partial class FBackup
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(42, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 233);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(67, 20);
            label1.Name = "label1";
            label1.Size = new Size(265, 25);
            label1.TabIndex = 0;
            label1.Text = "Backup de la Aplicación";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(242, 20);
            label2.TabIndex = 1;
            label2.Text = "Carpeta a respaldar / restaurar:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(296, 116);
            button1.Name = "button1";
            button1.Size = new Size(87, 23);
            button1.TabIndex = 3;
            button1.Text = "Examinar...";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.GreenYellow;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(108, 170);
            button2.Name = "button2";
            button2.Size = new Size(163, 31);
            button2.TabIndex = 4;
            button2.Text = "Crear Backup (.zip)";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LightGray;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(325, 260);
            button3.Name = "button3";
            button3.Size = new Size(131, 27);
            button3.TabIndex = 5;
            button3.Text = "Restaurar desde";
            button3.UseVisualStyleBackColor = false;
            // 
            // FBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(468, 299);
            Controls.Add(button3);
            Controls.Add(panel1);
            Name = "FBackup";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button3;
    }
}