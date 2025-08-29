using SistemaRestaurante.BLL;
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
    public partial class UsuarioUI : Form
    {
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private int? usuarioSeleccionadoId = null;

        public UsuarioUI()
        {
            InitializeComponent();
            CargarUsuarios();
            this.ClientSize = new Size(800, 500);
            cbxRol.Items.Clear();
            cbxRol.Items.Add(Rol.ADMIN.ToString());
            cbxRol.Items.Add(Rol.RECEPCIONISTA.ToString());
            tamanioDgv();
        }

        private void CargarUsuarios()
        {
            var usuarios = usuarioBLL.ObtenerUsuarios();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.ClearSelection();
        }
        private void tamanioDgv()
        {
            // dataDridView
            // Configurar las columnas (opcional)
            dgvUsuarios.Columns["id_usuario"].Width = 40;
            dgvUsuarios.Columns["nombre"].Width = 200;
            dgvUsuarios.Columns["username"].Width = 100;
            dgvUsuarios.Columns["password"].Width = 100;
            dgvUsuarios.Columns["rol"].Width = 100;
            // Configurar otras propiedades del DataGridView (opcional)
            dgvUsuarios.RowHeadersWidth = 30; // Tamaño del encabezado de fila
            dgvUsuarios.AllowUserToAddRows = false; // Evitar que el usuario agregue filas manualmente
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            dgvUsuarios.Size = new Size(570, 200);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol válido para el usuario.");
                    return;
                }
                Usuario usuarioNuevo = new Usuario
                {
                    nombre = txtNombre.Text,
                    username = txtNomUser.Text,
                    password = txtContrasenia.Text,
                    rol = (Rol)Enum.Parse(typeof(Rol), cbxRol.SelectedItem.ToString())
                };
                usuarioBLL.AgregarUsuario(usuarioNuevo);
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un usuario para editar.");
                return;
            }
            try
            {
                Usuario usuario = new Usuario
                {
                    id_usuario = usuarioSeleccionadoId.Value,
                    nombre = txtNombre.Text,
                    username = txtNomUser.Text,
                    password = txtContrasenia.Text,
                    rol = (Rol)Enum.Parse(typeof(Rol), cbxRol.SelectedItem.ToString())
                };
                usuarioBLL.ActualizarUsuario(usuario);
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }
            try
            {
                usuarioBLL.EliminarUsuario(usuarioSeleccionadoId.Value);
                CargarUsuarios();
                LimpiarCampos();
                MessageBox.Show("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0 && dgvUsuarios.Focused) //dgvUsuarios.Focused evita que se marque un linea al cargar los datos
            {
                var row = dgvUsuarios.SelectedRows[0];
                usuarioSeleccionadoId = Convert.ToInt32(row.Cells["id_usuario"].Value);
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtNomUser.Text = row.Cells["username"].Value.ToString();
                txtContrasenia.Text = row.Cells["password"].Value.ToString();
                cbxRol.SelectedItem = row.Cells["rol"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            usuarioSeleccionadoId = null;
            txtNombre.Text = "";
            txtNomUser.Text = "";
            txtContrasenia.Text = "";
            cbxRol.SelectedIndex = -1;
            cbxRol.Text = "Seleccionar";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void UsuarioUI_Load(object sender, EventArgs e)
        {

        }
    }
}
