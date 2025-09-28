namespace SistemaRestaurante.UI.Formularios
{
    partial class ReportesUI
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
            if (disposing)
            {
                // Limpiar recursos personalizados
                _syncService?.Dispose();
                
                // Limpiar componentes del formulario
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrupoContenedor = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvdpedido = new System.Windows.Forms.DataGridView();
            this.btnconsulta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblTexto = new System.Windows.Forms.Label();
            this.labelFiltrar = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.GrupoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdpedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // GrupoContenedor
            // 
            this.GrupoContenedor.Controls.Add(this.button1);
            this.GrupoContenedor.Controls.Add(this.label2);
            this.GrupoContenedor.Controls.Add(this.lblTotal);
            this.GrupoContenedor.Controls.Add(this.dgvdpedido);
            this.GrupoContenedor.Controls.Add(this.btnconsulta);
            this.GrupoContenedor.Controls.Add(this.label1);
            this.GrupoContenedor.Controls.Add(this.dtFecha2);
            this.GrupoContenedor.Controls.Add(this.dgvDetalles);
            this.GrupoContenedor.Controls.Add(this.lblTexto);
            this.GrupoContenedor.Controls.Add(this.labelFiltrar);
            this.GrupoContenedor.Controls.Add(this.dtFecha);
            this.GrupoContenedor.Font = new System.Drawing.Font("Niagara Solid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrupoContenedor.Location = new System.Drawing.Point(12, 12);
            this.GrupoContenedor.Name = "GrupoContenedor";
            this.GrupoContenedor.Size = new System.Drawing.Size(725, 580);
            this.GrupoContenedor.TabIndex = 1;
            this.GrupoContenedor.TabStop = false;
            this.GrupoContenedor.Text = "Control De Ventas ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(499, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 33);
            this.button1.TabIndex = 26;
            this.button1.Text = "Sincronizar con Supabase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(18, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Selecciona una de las filas para ver mas detalles del pedido";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(116, 417);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(83, 23);
            this.lblTotal.TabIndex = 24;
            this.lblTotal.Text = "0.00 Bs";
            this.lblTotal.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvdpedido
            // 
            this.dgvdpedido.AllowUserToAddRows = false;
            this.dgvdpedido.AllowUserToDeleteRows = false;
            this.dgvdpedido.BackgroundColor = System.Drawing.SystemColors.InfoText;
            this.dgvdpedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Niagara Solid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdpedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdpedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdpedido.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvdpedido.Location = new System.Drawing.Point(367, 133);
            this.dgvdpedido.Margin = new System.Windows.Forms.Padding(2);
            this.dgvdpedido.MultiSelect = false;
            this.dgvdpedido.Name = "dgvdpedido";
            this.dgvdpedido.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Niagara Solid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdpedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdpedido.RowHeadersWidth = 82;
            this.dgvdpedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdpedido.Size = new System.Drawing.Size(363, 266);
            this.dgvdpedido.TabIndex = 23;
            // 
            // btnconsulta
            // 
            this.btnconsulta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconsulta.Location = new System.Drawing.Point(288, 66);
            this.btnconsulta.Name = "btnconsulta";
            this.btnconsulta.Size = new System.Drawing.Size(94, 33);
            this.btnconsulta.TabIndex = 22;
            this.btnconsulta.Text = "Buscar";
            this.btnconsulta.UseVisualStyleBackColor = true;
            this.btnconsulta.Click += new System.EventHandler(this.btnconsulta_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(212, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Hasta:";
            // 
            // dtFecha2
            // 
            this.dtFecha2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(259, 31);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.Size = new System.Drawing.Size(123, 29);
            this.dtFecha2.TabIndex = 20;
            this.dtFecha2.Value = new System.DateTime(2025, 8, 26, 22, 30, 18, 0);
            this.dtFecha2.ValueChanged += new System.EventHandler(this.dtFecha2_ValueChanged);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.SystemColors.InfoText;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Niagara Solid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDetalles.Location = new System.Drawing.Point(0, 133);
            this.dgvDetalles.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Niagara Solid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalles.RowHeadersWidth = 82;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(363, 266);
            this.dgvDetalles.TabIndex = 19;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
            // 
            // lblTexto
            // 
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTexto.Location = new System.Drawing.Point(0, 421);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(109, 23);
            this.lblTexto.TabIndex = 7;
            this.lblTexto.Text = "Ingresos totales: ";
            this.lblTexto.Click += new System.EventHandler(this.lblTexto_Click);
            // 
            // labelFiltrar
            // 
            this.labelFiltrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFiltrar.Location = new System.Drawing.Point(18, 40);
            this.labelFiltrar.Name = "labelFiltrar";
            this.labelFiltrar.Size = new System.Drawing.Size(51, 23);
            this.labelFiltrar.TabIndex = 11;
            this.labelFiltrar.Text = "Desde:";
            this.labelFiltrar.Click += new System.EventHandler(this.labelFiltrar_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFecha.Location = new System.Drawing.Point(71, 33);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(124, 29);
            this.dtFecha.TabIndex = 10;
            this.dtFecha.Value = new System.DateTime(2025, 8, 26, 22, 30, 18, 0);
            this.dtFecha.ValueChanged += new System.EventHandler(this.dtFecha_ValueChanged);
            // 
            // ReportesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 604);
            this.Controls.Add(this.GrupoContenedor);
            this.Name = "ReportesUI";
            this.Text = "ReportesUI";
            this.GrupoContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdpedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrupoContenedor;
        private System.Windows.Forms.DataGridView dgvdpedido;
        private System.Windows.Forms.Button btnconsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFecha2;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label labelFiltrar;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}