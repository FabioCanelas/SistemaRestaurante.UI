using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRestaurante.BLL;

namespace SistemaRestaurante.UI.Formularios
{
    public partial class ReportesUI : Form
    {
        private ReportesBLL detalleBLL = new ReportesBLL();
        public ReportesUI()
        {
            InitializeComponent();
            Cargardetalles();
            dgvDetalles.CellClick += dgvDetalles_SelectionChanged;
        }
        private void dgvDetalles_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView grid = (DataGridView)sender;
                DataGridViewRow row = grid.Rows[e.RowIndex];

                if (row.Cells["id_pedido"].Value != null)
                {
                    int idPedido = Convert.ToInt32(row.Cells["id_pedido"].Value);
                    List<DetallePedidoCompleto> Bporid = detalleBLL.ObtenerDetalleCompletoPorId(idPedido);
                    dgvdpedido.DataSource = null;
                    dgvdpedido.DataSource = Bporid;

                    // Mostrar nombres en lugar de ids: ocultar columnas de ids y ajustar encabezados
                    if (dgvdpedido.Columns.Contains("id_detalle")) dgvdpedido.Columns["id_detalle"].Visible = false;
                    if (dgvdpedido.Columns.Contains("id_pedido")) dgvdpedido.Columns["id_pedido"].Visible = false;
                    if (dgvdpedido.Columns.Contains("id_plato")) dgvdpedido.Columns["id_plato"].Visible = false;

                    if (dgvdpedido.Columns.Contains("nombre_plato")) dgvdpedido.Columns["nombre_plato"].HeaderText = "Plato";
                    if (dgvdpedido.Columns.Contains("cantidad")) dgvdpedido.Columns["cantidad"].HeaderText = "Cantidad";
                    if (dgvdpedido.Columns.Contains("subtotal"))
                    {
                        dgvdpedido.Columns["subtotal"].HeaderText = "Subtotal";
                        dgvdpedido.Columns["subtotal"].DefaultCellStyle.Format = "N2";
                        dgvdpedido.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Ajustes de tamaño para dgvdpedido: usar Fill con pesos y altura de fila
                    try
                    {
                        dgvdpedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvdpedido.RowTemplate.Height = 26;
                        dgvdpedido.RowHeadersWidth = 30;
                        dgvdpedido.ColumnHeadersHeight = 30;

                        if (dgvdpedido.Columns.Contains("nombre_plato"))
                        {
                            dgvdpedido.Columns["nombre_plato"].FillWeight = 60;
                            dgvdpedido.Columns["nombre_plato"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        }
                        if (dgvdpedido.Columns.Contains("cantidad"))
                        {
                            dgvdpedido.Columns["cantidad"].FillWeight = 20;
                            dgvdpedido.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        if (dgvdpedido.Columns.Contains("subtotal"))
                        {
                            dgvdpedido.Columns["subtotal"].FillWeight = 20;
                            dgvdpedido.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }

                        // Aplicar fuente un poco más legible
                        dgvdpedido.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                        dgvdpedido.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    }
                    catch { }
                }

            }
        }

        private void Cargardetalles()
        {
            // Obtener pedidos del día (usa BLL existente)
            var detalles = detalleBLL.ObtenerDetallesPedido();
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = detalles;

            // Calcular total del día
            decimal total = 0m;
            if (detalles != null && detalles.Count > 0)
                total = detalles.Sum(p => p.total);

            lblTotal.Text = total.ToString("0.00") + " Bs";

            // Ajustes de columnas: ocultar columnas innecesarias si aparecen
            if (dgvDetalles.Columns.Contains("id_usuario")) dgvDetalles.Columns["id_usuario"].Visible = false;
            if (dgvDetalles.Columns.Contains("num_orden")) dgvDetalles.Columns["num_orden"].HeaderText = "Orden";
            if (dgvDetalles.Columns.Contains("id_pedido")) dgvDetalles.Columns["id_pedido"].HeaderText = "ID";
            if (dgvDetalles.Columns.Contains("fecha_pedido")) dgvDetalles.Columns["fecha_pedido"].HeaderText = "Fecha";
            if (dgvDetalles.Columns.Contains("total"))
            {
                dgvDetalles.Columns["total"].HeaderText = "Total";
                dgvDetalles.Columns["total"].DefaultCellStyle.Format = "N2";
                dgvDetalles.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Asegurar que las columnas no se redimensionen automáticamente
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Tamaño de las columnas (seguro: comprobar existencia)
            try
            {
                // tamaño del encabezado de fila (columna antes de la primera)
                dgvDetalles.RowHeadersWidth = 30;

                if (dgvDetalles.Columns.Contains("id_detalle")) dgvDetalles.Columns["id_detalle"].Width = 50;
                if (dgvDetalles.Columns.Contains("id_pedido")) dgvDetalles.Columns["id_pedido"].Width = 60;
                if (dgvDetalles.Columns.Contains("fecha_pedido")) dgvDetalles.Columns["fecha_pedido"].Width = 160;
                if (dgvDetalles.Columns.Contains("total")) dgvDetalles.Columns["total"].Width = 100;
                if (dgvDetalles.Columns.Contains("num_orden")) dgvDetalles.Columns["num_orden"].Width = 90;
                if (dgvDetalles.Columns.Contains("id_plato")) dgvDetalles.Columns["id_plato"].Width = 80;

                // Mejora visual
                dgvDetalles.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
            catch { }
        }

        private void btnconsulta_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaSeleccionada1 = dtFecha.Value.Date;
                DateTime fechaSeleccionada2 = dtFecha2.Value.Date;

                var datePedido = detalleBLL.DatePedido(fechaSeleccionada1, fechaSeleccionada2);

                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = datePedido;

                // Calcular total del rango
                decimal total = 0m;
                if (datePedido != null && datePedido.Count > 0)
                    total = datePedido.Sum(p => p.total);

                lblTotal.Text = total.ToString("0.00") + " Bs";

                // Ajustar columnas como en la carga inicial
                if (dgvDetalles.Columns.Contains("id_usuario")) dgvDetalles.Columns["id_usuario"].Visible = false;
                if (dgvDetalles.Columns.Contains("num_orden")) dgvDetalles.Columns["num_orden"].HeaderText = "Orden";
                if (dgvDetalles.Columns.Contains("id_pedido")) dgvDetalles.Columns["id_pedido"].HeaderText = "ID";
                if (dgvDetalles.Columns.Contains("fecha_pedido")) dgvDetalles.Columns["fecha_pedido"].HeaderText = "Fecha";
                if (dgvDetalles.Columns.Contains("total"))
                {
                    dgvDetalles.Columns["total"].HeaderText = "Total";
                    dgvDetalles.Columns["total"].DefaultCellStyle.Format = "N2";
                    dgvDetalles.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Asegurar modo fijo de ancho y ajustar tamaños
                dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                try
                {
                    dgvDetalles.RowHeadersWidth = 30;
                    if (dgvDetalles.Columns.Contains("id_detalle")) dgvDetalles.Columns["id_detalle"].Width = 50;
                    if (dgvDetalles.Columns.Contains("id_pedido")) dgvDetalles.Columns["id_pedido"].Width = 60;
                    if (dgvDetalles.Columns.Contains("fecha_pedido")) dgvDetalles.Columns["fecha_pedido"].Width = 160;
                    if (dgvDetalles.Columns.Contains("total")) dgvDetalles.Columns["total"].Width = 100;
                    if (dgvDetalles.Columns.Contains("num_orden")) dgvDetalles.Columns["num_orden"].Width = 90;
                    if (dgvDetalles.Columns.Contains("id_plato")) dgvDetalles.Columns["id_plato"].Width = 80;
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtFecha2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTexto_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
