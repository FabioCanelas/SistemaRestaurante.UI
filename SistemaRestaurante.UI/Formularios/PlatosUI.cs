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
            dgvPlatos.DataSource = platos;
            LimpiarCampos();

            // Cambiar los nombres de los encabezados de columna
            dgvPlatos.Columns["id_plato"].HeaderText = "ID";
            dgvPlatos.Columns["nombre"].HeaderText = "Nombre del Plato";
            dgvPlatos.Columns["descripcion"].HeaderText = "Descripción";
            dgvPlatos.Columns["precio"].HeaderText = "Precio (Bs)";
        }

        private void tamanioDgv()
        {
            // Nombre de las columnas
            dgvPlatos.Columns.Add("id_plato", "ID Plato");
            dgvPlatos.Columns.Add("nombre", "Nombre Plato");
            dgvPlatos.Columns.Add("descripcion", "Descripción");
            dgvPlatos.Columns.Add("precio", "Precio");
            
           
            // dataDridView
            // Configurar las columnas (opcional)
            dgvPlatos.Columns["id_plato"].Width = 40;
            dgvPlatos.Columns["nombre"].Width = 100;
            dgvPlatos.Columns["descripcion"].Width = 300;
            dgvPlatos.Columns["precio"].Width = 100;
            // Configurar otras propiedades del DataGridView (opcional)
            dgvPlatos.RowHeadersWidth = 30; // Tamaño del encabezado de fila
            dgvPlatos.AllowUserToAddRows = false; // Evitar que el usuario agregue filas manualmente
            dgvPlatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            dgvPlatos.Size = new Size(570, 200);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Plato platoNuevo = new Plato
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text,
                    precio = decimal.Parse(nudPrecio.Text)
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
            nudPrecio.Text = "0.0";
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
                    precio = decimal.Parse(nudPrecio.Text)
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
                platoSeleccionadoId = Convert.ToInt32(row.Cells["id_plato"].Value);
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();
                nudPrecio.Text = row.Cells["precio"].Value.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o eliminarlo si no lo usas
        }
    }
}
