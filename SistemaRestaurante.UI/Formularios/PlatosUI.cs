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
    public partial class PlatosUI : Form
    {
        private PlatoBLL platoBLL = new PlatoBLL();
        private int? platoSeleccionadoId = null;
        public PlatosUI()
        {
            InitializeComponent();
            CargarPlatos();
            tamanioDgv();
        }

        private void CargarPlatos()
        {
            var platos = platoBLL.ObtenerPlatos();
            dgvPlatos.DataSource = null;
           
            dgvPlatos.AutoGenerateColumns = true;
            dgvPlatos.DataSource = platos;
            LimpiarCampos();

            // Cambiar los nombres de los encabezados de columna solo si existen
            if (dgvPlatos.Columns.Contains("id_plato")) dgvPlatos.Columns["id_plato"].HeaderText = "ID";
            if (dgvPlatos.Columns.Contains("nombre")) dgvPlatos.Columns["nombre"].HeaderText = "Nombre del Plato";
            if (dgvPlatos.Columns.Contains("descripcion")) dgvPlatos.Columns["descripcion"].HeaderText = "Descripción";
            if (dgvPlatos.Columns.Contains("precio")) dgvPlatos.Columns["precio"].HeaderText = "Precio (Bs)";

            // Ajustar anchos si las columnas existen
            if (dgvPlatos.Columns.Contains("id_plato")) dgvPlatos.Columns["id_plato"].Width = 40;
            if (dgvPlatos.Columns.Contains("nombre")) dgvPlatos.Columns["nombre"].Width = 150;
            if (dgvPlatos.Columns.Contains("descripcion")) dgvPlatos.Columns["descripcion"].Width = 300;
            if (dgvPlatos.Columns.Contains("precio")) dgvPlatos.Columns["precio"].Width = 80;
        }

        private void tamanioDgv()
        {
            // No agregar columnas manualmente cuando se usa DataSource
            // Solo configurar propiedades visuales
            dgvPlatos.RowHeadersWidth = 30; // Tamaño del encabezado de fila
            dgvPlatos.AllowUserToAddRows = false; // Evitar que el usuario agregue filas manualmente
            dgvPlatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            dgvPlatos.Size = new Size(570, 200);
            dgvPlatos.ReadOnly = true;
            dgvPlatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPlatos.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvPlatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Plato platoNuevo = new Plato
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text,
                    precio = nudPrecio.Value
                };
                platoBLL.AgregarPlato(platoNuevo);
                CargarPlatos();
                LimpiarCampos();
                MessageBox.Show("Plato agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tamanioDgv();
        }

        private void LimpiarCampos()
        {
            platoSeleccionadoId = null;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            nudPrecio.Value = 0m;
            tamanioDgv();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (platoSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un plato para eliminar.");
                return;
            }
            try
            {
                platoBLL.eliminarPlato(platoSeleccionadoId.Value);
                CargarPlatos();
                LimpiarCampos();
                MessageBox.Show("Plato eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tamanioDgv();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (platoSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un plato para editar.");
                return;
            }
            try
            {
                Plato platoActualizado = new Plato
                {
                    id_plato = platoSeleccionadoId.Value,
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text,
                    precio = nudPrecio.Value
                };
                platoBLL.ActualizarPlato(platoActualizado);
                CargarPlatos();
                LimpiarCampos();
                MessageBox.Show("Plato actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tamanioDgv();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    
        private void dgvPlatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlatos.SelectedRows.Count > 0 && dgvPlatos.Focused) //dgvUsuarios.Focused evita que se marque un linea al cargar los datos
            {
                var row = dgvPlatos.SelectedRows[0];
                if (dgvPlatos.Columns.Contains("id_plato") && row.Cells["id_plato"].Value != null)
                {
                    platoSeleccionadoId = Convert.ToInt32(row.Cells["id_plato"].Value);
                }
                else
                {
                    platoSeleccionadoId = null;
                }

                txtNombre.Text = dgvPlatos.Columns.Contains("nombre") && row.Cells["nombre"].Value != null ? row.Cells["nombre"].Value.ToString() : string.Empty;
                txtDescripcion.Text = dgvPlatos.Columns.Contains("descripcion") && row.Cells["descripcion"].Value != null ? row.Cells["descripcion"].Value.ToString() : string.Empty;

                if (dgvPlatos.Columns.Contains("precio") && row.Cells["precio"].Value != null)
                {
                    decimal precioVal;
                    if (decimal.TryParse(row.Cells["precio"].Value.ToString(), out precioVal))
                        nudPrecio.Value = precioVal;
                    else
                        nudPrecio.Value = 0m;
                }
                else
                {
                    nudPrecio.Value = 0m;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o eliminarlo si no lo usas
        }
    }
}
