namespace AurenPadelStore.CPresentacion.Administrador
{
    partial class FEstadisticas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMes;

        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label labV;
        private System.Windows.Forms.Label labP;
        private System.Windows.Forms.Label labI;
        private System.Windows.Forms.Label labT;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            dtDesde = new DateTimePicker();
            dtHasta = new DateTimePicker();
            btnActualizar = new Button();
            numTop = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            chartDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTop = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            grpResumen = new GroupBox();
            labV = new Label();
            lblVentas = new Label();
            labP = new Label();
            lblProductos = new Label();
            labI = new Label();
            lblImporte = new Label();
            labT = new Label();
            lblTicket = new Label();
            ((System.ComponentModel.ISupportInitialize)numTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartMes).BeginInit();
            grpResumen.SuspendLayout();
            SuspendLayout();
            // 
            // dtDesde
            // 
            dtDesde.Location = new Point(66, 10);
            dtDesde.Name = "dtDesde";
            dtDesde.Size = new Size(160, 23);
            dtDesde.TabIndex = 1;
            // 
            // dtHasta
            // 
            dtHasta.Location = new Point(295, 10);
            dtHasta.Name = "dtHasta";
            dtHasta.Size = new Size(160, 23);
            dtHasta.TabIndex = 3;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(722, 10);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // numTop
            // 
            numTop.Location = new Point(580, 10);
            numTop.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numTop.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numTop.Name = "numTop";
            numTop.Size = new Size(120, 23);
            numTop.TabIndex = 5;
            numTop.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(48, 23);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.Location = new Point(240, 12);
            label2.Name = "label2";
            label2.Size = new Size(49, 23);
            label2.TabIndex = 2;
            label2.Text = "Hasta:";
            // 
            // label3
            // 
            label3.Location = new Point(470, 12);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Top productos:";
            // 
            // chartDia
            // 
            chartDia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ca1";
            chartDia.ChartAreas.Add(chartArea1);
            legend1.Name = "lg1";
            chartDia.Legends.Add(legend1);
            chartDia.Location = new Point(12, 48);
            chartDia.Name = "chartDia";
            chartDia.Size = new Size(460, 260);
            chartDia.TabIndex = 7;
            // 
            // chartTop
            // 
            chartTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea2.Name = "ca2";
            chartTop.ChartAreas.Add(chartArea2);
            legend2.Name = "lg2";
            chartTop.Legends.Add(legend2);
            chartTop.Location = new Point(490, 48);
            chartTop.Name = "chartTop";
            chartTop.Size = new Size(460, 260);
            chartTop.TabIndex = 8;
            // 
            // chartMes
            // 
            chartMes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea3.Name = "ca3";
            chartMes.ChartAreas.Add(chartArea3);
            legend3.Name = "lg3";
            chartMes.Legends.Add(legend3);
            chartMes.Location = new Point(12, 318);
            chartMes.Name = "chartMes";
            chartMes.Size = new Size(460, 260);
            chartMes.TabIndex = 9;
            // 
            // grpResumen
            // 
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpResumen.Controls.Add(labV);
            grpResumen.Controls.Add(lblVentas);
            grpResumen.Controls.Add(labP);
            grpResumen.Controls.Add(lblProductos);
            grpResumen.Controls.Add(labI);
            grpResumen.Controls.Add(lblImporte);
            grpResumen.Controls.Add(labT);
            grpResumen.Controls.Add(lblTicket);
            grpResumen.Location = new Point(490, 318);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(460, 260);
            grpResumen.TabIndex = 10;
            grpResumen.TabStop = false;
            grpResumen.Text = "Resumen del período";
            // 
            // labV
            // 
            labV.Location = new Point(20, 40);
            labV.Name = "labV";
            labV.Size = new Size(100, 23);
            labV.TabIndex = 0;
            labV.Text = "Ventas:";
            // 
            // lblVentas
            // 
            lblVentas.AutoSize = true;
            lblVentas.Location = new Point(140, 40);
            lblVentas.Name = "lblVentas";
            lblVentas.Size = new Size(0, 15);
            lblVentas.TabIndex = 1;
            // 
            // labP
            // 
            labP.Location = new Point(20, 80);
            labP.Name = "labP";
            labP.Size = new Size(100, 23);
            labP.TabIndex = 2;
            labP.Text = "Productos:";
            // 
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Location = new Point(140, 80);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(0, 15);
            lblProductos.TabIndex = 3;
            // 
            // labI
            // 
            labI.Location = new Point(20, 120);
            labI.Name = "labI";
            labI.Size = new Size(100, 23);
            labI.TabIndex = 4;
            labI.Text = "Importe total:";
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Location = new Point(140, 120);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(0, 15);
            lblImporte.TabIndex = 5;
            // 
            // labT
            // 
            labT.Location = new Point(20, 160);
            labT.Name = "labT";
            labT.Size = new Size(100, 23);
            labT.TabIndex = 6;
            labT.Text = "Ticket promedio:";
            // 
            // lblTicket
            // 
            lblTicket.AutoSize = true;
            lblTicket.Location = new Point(140, 160);
            lblTicket.Name = "lblTicket";
            lblTicket.Size = new Size(0, 15);
            lblTicket.TabIndex = 7;
            // 
            // FEstadisticas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(label1);
            Controls.Add(dtDesde);
            Controls.Add(label2);
            Controls.Add(dtHasta);
            Controls.Add(label3);
            Controls.Add(numTop);
            Controls.Add(btnActualizar);
            Controls.Add(chartDia);
            Controls.Add(chartTop);
            Controls.Add(chartMes);
            Controls.Add(grpResumen);
            MinimumSize = new Size(1000, 650);
            Name = "FEstadisticas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Estadísticas | Auren Padel";
            ((System.ComponentModel.ISupportInitialize)numTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMes).EndInit();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ResumeLayout(false);
        }
    }
}
