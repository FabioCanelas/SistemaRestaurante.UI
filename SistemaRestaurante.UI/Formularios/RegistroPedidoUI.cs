using SistemaRestaurante.DAL;
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

namespace SistemaRestaurante.UI.Formularios
{
    public partial class RegistroPedidoUI : Form
    {
        public RegistroPedidoUI()
        {
            InitializeComponent();
            //btnReporteCliente.Click += BtnReporteCliente_Click;
            //btnReporteCocina.Click += BtnReporteCocina_Click;

            columanasDgv();
            cargarPlatos();
            
        }
        private void cargarPlatos()
        {
            //Al combobox
            var platoDal = new PlatoDAL();
            var platos = platoDal.ObtenerPlatos();

            cbxPlato.DataSource = platos;
            cbxPlato.DisplayMember = "nombre";
            cbxPlato.ValueMember = "id_plato";
        }
        private void columanasDgv()
        {
            // Nombre de las columnas
            dgvDetallePedido.Columns.Add("IdPlato", "ID Plato");
            dgvDetallePedido.Columns.Add("NombrePlato", "Nombre Plato");
            dgvDetallePedido.Columns.Add("Cantidad", "Cantidad");
            dgvDetallePedido.Columns.Add("NumMesa", "N° Mesa");
            dgvDetallePedido.Columns.Add("Subtotal", "Subtotal");
            // Tamaño de las columnas
            dgvDetallePedido.Columns["IdPlato"].Width = 50;
            dgvDetallePedido.Columns["NombrePlato"].Width = 200;
            dgvDetallePedido.Columns["Cantidad"].Width = 100;
            dgvDetallePedido.Columns["NumMesa"].Width = 100;
            dgvDetallePedido.Columns["Subtotal"].Width = 100;
            // Configuaraiones extra
            dgvDetallePedido.RowHeadersWidth = 30; // tamaño del encabezado de fila
            dgvDetallePedido.AllowUserToAddRows = false; // Evitar que el usuario agregue filas manualmente
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            dgvDetallePedido.Size = new Size(580, 200);
        }
        private void BtnReporteCliente_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar el reporte de detalle de venta para el cliente
            // Ejemplo: Mostrar un MessageBox o abrir un formulario de reporte
            MessageBox.Show("Mostrar reporte de venta para el cliente.");
        }

        private void BtnReporteCocina_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar el reporte de detalle de venta para cocina
            // Ejemplo: Mostrar un MessageBox o abrir un formulario de reporte
            MessageBox.Show("Mostrar reporte de venta para cocina.");
        }

        private void btnAgregarPlato_Click(object sender, EventArgs e)
        {
            // 1. Obtener datos del formulario
            var platoSeleccionado = (Plato)cbxPlato.SelectedItem; // Asegúrate de tener el objeto Plato en el ComboBox
            int cantidad = (int)nudCantidad.Value;
            int numMesa = int.Parse(txtMesa.Text);

            // 2. Calcular subtotal
            decimal subtotal = cantidad * platoSeleccionado.precio;

            // 3. Agregar al DataGridView
            dgvDetallePedido.Rows.Add(
                platoSeleccionado.id_plato,
                platoSeleccionado.nombre,
                cantidad,
                numMesa,
                subtotal
            );

            // 4. Actualizar el total
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            txtTotal.Text = total.ToString("0.00");
        }

        private void btnGuardarPedido_Click(object sender, EventArgs e) 
        {

        }
        private void btnQuitarPlato_Click(object sender, EventArgs e) 
        {
        
        }
        private void dgvDetallePedido_SelectionChanged(object sender, EventArgs e) 
        {
        
        }
        private void btnReporteCliente_Click(object sender, EventArgs e) 
        {
        
        }
        private void btnReporteCocina_Click(object sender, EventArgs e) 
        { 
        
        }
    }
}
