namespace SistemaRestaurante.UI.Formularios
{
    partial class RegistroPedidoUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardarPedido = new System.Windows.Forms.Button();
            this.btnQuitarPlato = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblRecepcionista = new System.Windows.Forms.Label();
            this.txtRecepcionista = new System.Windows.Forms.TextBox();
            this.lblPlato = new System.Windows.Forms.Label();
            this.cbxPlato = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblMesa = new System.Windows.Forms.Label();
            this.txtMesa = new System.Windows.Forms.TextBox();
            this.btnAgregarPlato = new System.Windows.Forms.Button();
            this.btnReporteCliente = new System.Windows.Forms.Button();
            this.btnReporteCocina = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            this.groupBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardarPedido);
            this.groupBox1.Controls.Add(this.btnQuitarPlato);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.dgvDetallePedido);
            this.groupBox1.Controls.Add(this.groupBoxDatos);
            this.groupBox1.Controls.Add(this.btnReporteCliente);
            this.groupBox1.Controls.Add(this.btnReporteCocina);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 460);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Pedidos";
            // 
            // btnGuardarPedido
            // 
            this.btnGuardarPedido.Location = new System.Drawing.Point(457, 404);
            this.btnGuardarPedido.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarPedido.Name = "btnGuardarPedido";
            this.btnGuardarPedido.Size = new System.Drawing.Size(100, 27);
            this.btnGuardarPedido.TabIndex = 25;
            this.btnGuardarPedido.Text = "Guardar Pedido";
            this.btnGuardarPedido.UseVisualStyleBackColor = true;
            this.btnGuardarPedido.Click += new System.EventHandler(this.btnGuardarPedido_Click);
            // 
            // btnQuitarPlato
            // 
            this.btnQuitarPlato.Location = new System.Drawing.Point(79, 378);
            this.btnQuitarPlato.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitarPlato.Name = "btnQuitarPlato";
            this.btnQuitarPlato.Size = new System.Drawing.Size(75, 28);
            this.btnQuitarPlato.TabIndex = 24;
            this.btnQuitarPlato.Text = "Quitar Plato";
            this.btnQuitarPlato.UseVisualStyleBackColor = true;
            this.btnQuitarPlato.Click += new System.EventHandler(this.btnQuitarPlato_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(457, 377);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(102, 20);
            this.txtTotal.TabIndex = 23;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(422, 378);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "Total:";
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.AllowUserToAddRows = false;
            this.dgvDetallePedido.AllowUserToDeleteRows = false;
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Location = new System.Drawing.Point(39, 162);
            this.dgvDetallePedido.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.ReadOnly = true;
            this.dgvDetallePedido.RowHeadersWidth = 62;
            this.dgvDetallePedido.RowTemplate.Height = 28;
            this.dgvDetallePedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallePedido.Size = new System.Drawing.Size(570, 200);
            this.dgvDetallePedido.TabIndex = 21;
            this.dgvDetallePedido.SelectionChanged += new System.EventHandler(this.dgvDetallePedido_SelectionChanged);
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.lblFecha);
            this.groupBoxDatos.Controls.Add(this.txtFecha);
            this.groupBoxDatos.Controls.Add(this.lblRecepcionista);
            this.groupBoxDatos.Controls.Add(this.txtRecepcionista);
            this.groupBoxDatos.Controls.Add(this.lblPlato);
            this.groupBoxDatos.Controls.Add(this.cbxPlato);
            this.groupBoxDatos.Controls.Add(this.lblCantidad);
            this.groupBoxDatos.Controls.Add(this.nudCantidad);
            this.groupBoxDatos.Controls.Add(this.lblMesa);
            this.groupBoxDatos.Controls.Add(this.txtMesa);
            this.groupBoxDatos.Controls.Add(this.btnAgregarPlato);
            this.groupBoxDatos.Location = new System.Drawing.Point(49, 37);
            this.groupBoxDatos.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxDatos.Size = new System.Drawing.Size(550, 121);
            this.groupBoxDatos.TabIndex = 20;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos del Pedido";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(27, 32);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(67, 30);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(116, 20);
            this.txtFecha.TabIndex = 2;
            // 
            // lblRecepcionista
            // 
            this.lblRecepcionista.AutoSize = true;
            this.lblRecepcionista.Location = new System.Drawing.Point(195, 32);
            this.lblRecepcionista.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecepcionista.Name = "lblRecepcionista";
            this.lblRecepcionista.Size = new System.Drawing.Size(78, 13);
            this.lblRecepcionista.TabIndex = 1;
            this.lblRecepcionista.Text = "Recepcionista:";
            // 
            // txtRecepcionista
            // 
            this.txtRecepcionista.Location = new System.Drawing.Point(279, 30);
            this.txtRecepcionista.Margin = new System.Windows.Forms.Padding(2);
            this.txtRecepcionista.Name = "txtRecepcionista";
            this.txtRecepcionista.ReadOnly = true;
            this.txtRecepcionista.Size = new System.Drawing.Size(116, 20);
            this.txtRecepcionista.TabIndex = 3;
            // 
            // lblPlato
            // 
            this.lblPlato.AutoSize = true;
            this.lblPlato.Location = new System.Drawing.Point(27, 71);
            this.lblPlato.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlato.Name = "lblPlato";
            this.lblPlato.Size = new System.Drawing.Size(34, 13);
            this.lblPlato.TabIndex = 4;
            this.lblPlato.Text = "Plato:";
            // 
            // cbxPlato
            // 
            this.cbxPlato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlato.Location = new System.Drawing.Point(67, 70);
            this.cbxPlato.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPlato.Name = "cbxPlato";
            this.cbxPlato.Size = new System.Drawing.Size(116, 21);
            this.cbxPlato.TabIndex = 5;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(194, 71);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(250, 70);
            this.nudCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(40, 20);
            this.nudCantidad.TabIndex = 7;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(308, 71);
            this.lblMesa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(36, 13);
            this.lblMesa.TabIndex = 8;
            this.lblMesa.Text = "Mesa:";
            // 
            // txtMesa
            // 
            this.txtMesa.Location = new System.Drawing.Point(343, 70);
            this.txtMesa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMesa.Name = "txtMesa";
            this.txtMesa.Size = new System.Drawing.Size(52, 20);
            this.txtMesa.TabIndex = 9;
            // 
            // btnAgregarPlato
            // 
            this.btnAgregarPlato.Location = new System.Drawing.Point(435, 67);
            this.btnAgregarPlato.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPlato.Name = "btnAgregarPlato";
            this.btnAgregarPlato.Size = new System.Drawing.Size(75, 25);
            this.btnAgregarPlato.TabIndex = 10;
            this.btnAgregarPlato.Text = "Agregar Plato";
            this.btnAgregarPlato.UseVisualStyleBackColor = true;
            this.btnAgregarPlato.Click += new System.EventHandler(this.btnAgregarPlato_Click);
            // 
            // btnReporteCliente
            // 
            this.btnReporteCliente.Location = new System.Drawing.Point(39, 238);
            this.btnReporteCliente.Name = "btnReporteCliente";
            this.btnReporteCliente.Size = new System.Drawing.Size(130, 23);
            this.btnReporteCliente.TabIndex = 26;
            this.btnReporteCliente.Text = "Reporte para Cliente";
            this.btnReporteCliente.UseVisualStyleBackColor = true;
            this.btnReporteCliente.Click += new System.EventHandler(this.btnReporteCliente_Click);
            // 
            // btnReporteCocina
            // 
            this.btnReporteCocina.Location = new System.Drawing.Point(179, 238);
            this.btnReporteCocina.Name = "btnReporteCocina";
            this.btnReporteCocina.Size = new System.Drawing.Size(130, 23);
            this.btnReporteCocina.TabIndex = 27;
            this.btnReporteCocina.Text = "Reporte para Cocina";
            this.btnReporteCocina.UseVisualStyleBackColor = true;
            this.btnReporteCocina.Click += new System.EventHandler(this.btnReporteCocina_Click);
            // 
            // RegistroPedidoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 490);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistroPedidoUI";
            this.Text = "Registro de Pedido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardarPedido;
        private System.Windows.Forms.Button btnQuitarPlato;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblRecepcionista;
        private System.Windows.Forms.TextBox txtRecepcionista;
        private System.Windows.Forms.Label lblPlato;
        private System.Windows.Forms.ComboBox cbxPlato;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.TextBox txtMesa;
        private System.Windows.Forms.Button btnAgregarPlato;
        private System.Windows.Forms.Button btnReporteCliente;
        private System.Windows.Forms.Button btnReporteCocina;
    }
}