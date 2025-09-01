using SistemaRestaurante.BLL;
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
        private RegistroPedidoBLL _registroBLL = new RegistroPedidoBLL();

        public RegistroPedidoUI()
        {
            InitializeComponent();
            // Registrar handlers en el constructor para evitar duplicados en el diseñador
            if (btnReporteCliente != null) btnReporteCliente.Click += BtnReporteCliente_Click;
            if (btnReporteCocina != null) btnReporteCocina.Click += BtnReporteCocina_Click;
            // registrar también los botones alternativos (btnRepCliente/btnRepCocina)
            if (btnRepCliente != null) btnRepCliente.Click += BtnReporteCliente_Click;
            if (btnRepCocina != null) btnRepCocina.Click += BtnReporteCocina_Click;

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
            // Construir y mostrar preview del ticket para cliente usando el contenido de dgvDetallePedido
            var sb = new StringBuilder();
            sb.AppendLine("*** TICKET CLIENTE ***");
            sb.AppendLine("Restaurante El Festín");
            sb.AppendLine($"Fecha: {DateTime.Now:g}");
            sb.AppendLine(new string('-', 40));
            sb.AppendLine(string.Format("{0,-30}{1,6}{2,12}", "Plato", "Cant", "Subtotal"));

            decimal total = 0m;
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                if (row.IsNewRow) continue;
                var nombre = row.Cells["NombrePlato"].Value?.ToString() ?? string.Empty;
                var cant = Convert.ToInt32(row.Cells["Cantidad"].Value);
                var sub = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                sb.AppendLine(string.Format("{0,-30}{1,6}{2,12}", Truncate(nombre, 30), cant, sub.ToString("0.00")));
                total += sub;
            }
            sb.AppendLine(new string('-', 40));
            sb.AppendLine(string.Format("{0,38}", "TOTAL: " + total.ToString("0.00")));
            sb.AppendLine("-------------------------------");
            sb.AppendLine("Gracias por su compra");

            MessageBox.Show(sb.ToString(), "Preview - Ticket Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnReporteCocina_Click(object sender, EventArgs e)
        {
            // Construir y mostrar preview del ticket para cocina (simplificado)
            var sb = new StringBuilder();
            sb.AppendLine("*** TICKET COCINA ***");
            sb.AppendLine($"Fecha: {DateTime.Now:g}");
            sb.AppendLine(new string('-', 30));

            int mesa = -1;
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                if (row.IsNewRow) continue;
                var nombre = row.Cells["NombrePlato"].Value?.ToString() ?? string.Empty;
                var cant = Convert.ToInt32(row.Cells["Cantidad"].Value);
                if (int.TryParse(row.Cells["NumMesa"].Value?.ToString(), out int m)) mesa = m;
                sb.AppendLine($"{cant} x {Truncate(nombre, 30)}");
            }

            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"Mesa: {(mesa>0? mesa.ToString(): "-")}");
            sb.AppendLine("-------------------------------");

            MessageBox.Show(sb.ToString(), "Preview - Ticket Cocina", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }

        private void btnAgregarPlato_Click(object sender, EventArgs e)
        {
            // 1. Obtener datos del formulario
            var platoSeleccionado = (Plato)cbxPlato.SelectedItem; // Asegúrate de tener el objeto Plato en el ComboBox
            int cantidad = (int)nudCantidad.Value;

            // Validar número de mesa antes de parsear
            if (string.IsNullOrWhiteSpace(txtMesa.Text) || !int.TryParse(txtMesa.Text.Trim(), out int numMesa))
            {
                MessageBox.Show("Ingrese un número de mesa válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMesa.Focus();
                return;
            }

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
            //columanasDgv();
        }

        private void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones que haya algun dato en el datagridview
                if (dgvDetallePedido.Rows.Count == 0)
                {
                    MessageBox.Show("Agregue al menos un plato al pedido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Construir lista de detalles desde el DataGridView
                var detalles = new List<Detalle_Pedido>();
                foreach (DataGridViewRow row in dgvDetallePedido.Rows)
                {
                    if (row.IsNewRow) continue;

                    detalles.Add(new Detalle_Pedido
                    {
                        id_plato = Convert.ToInt32(row.Cells["IdPlato"].Value),
                        cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        num_mesa = Convert.ToInt32(row.Cells["NumMesa"].Value),
                        subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                    });
                }

                // Construir objeto Pedido
                var pedido = new Pedido
                {
                    fecha_pedido = DateTime.Now,
                    estado = Estado.PENDIENTE,
                    id_usuario = 1 // TODO: reemplazar por id real del usuario autenticado
                };

                // El BLL ahora devuelve el num_orden generado
                string numOrden = _registroBLL.RegistrarPedido(pedido, detalles);

                MessageBox.Show($"Pedido registrado correctamente. N° orden: {numOrden}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mostrar el num_orden en el TextBox si existe
                try
                {
                    if (this.Controls.ContainsKey("txtNumOrden"))
                        ((TextBox)this.Controls["txtNumOrden"]).Text = numOrden;
                }
                catch { }

                // Limpiar formulario
                dgvDetallePedido.Rows.Clear();
                txtTotal.Text = "0.00";
                txtMesa.Text = string.Empty;
                nudCantidad.Value = 1;
                if (cbxPlato.Items.Count > 0) cbxPlato.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQuitarPlato_Click(object sender, EventArgs e) 
        {
            if (dgvDetallePedido.SelectedRows.Count > 0)
            {
                dgvDetallePedido.Rows.RemoveAt(dgvDetallePedido.SelectedRows[0].Index);

                // Actualizar el total después de quitar la fila
                decimal total = 0;
                foreach (DataGridViewRow row in dgvDetallePedido.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
                txtTotal.Text = total.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Seleccione una fila para quitar.");
            }
        }
 
        private void dgvDetallePedido_SelectionChanged(object sender, EventArgs e)
        {
        
        }

        // Métodos que el diseñador espera - reenvían a los handlers principales
        private void btnReporteCliente_Click(object sender, EventArgs e)
        {
            BtnReporteCliente_Click(sender, e);
        }

        private void btnReporteCocina_Click(object sender, EventArgs e)
        {
            BtnReporteCocina_Click(sender, e);
        }

        private void btnRepCliente_Click(object sender, EventArgs e)
        {
            // Si este botón debe hacer lo mismo que reporte cliente
            BtnReporteCliente_Click(sender, e);
        }
    }
}
