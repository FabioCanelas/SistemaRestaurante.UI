using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRestaurante.ENT;

namespace SistemaRestaurante.UI.Formularios
{
    // Clase corregida para el dashboard de recepcionista
    public partial class DashboardRecepcionistaUI : Form
    {
        // Propiedad para recibir el usuario autenticado desde el login
        public Usuario UsuarioActual { get; set; }

        public DashboardRecepcionistaUI()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            ColorearBotonesPanel();
            CargarImagenes();
        }

        private void ColorearBotonesPanel()
        {
            // PANEL
            if (panelMenu != null) panelMenu.BackColor = Color.FromArgb(107, 46, 40);

            // Colorear los botones dentro del panel para evitar referencias por nombre
            if (panelMenu != null)
            {
                foreach (Control c in panelMenu.Controls)
                {
                    var b = c as Button;
                    if (b == null) continue;
                    b.BackColor = Color.FromArgb(243, 228, 210);
                    b.ForeColor = Color.FromArgb(88, 73, 59);
                    b.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private void CargarImagenes()
        {
            try
            {
                string ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos", "Logoo.png");
                if (System.IO.File.Exists(ruta))
                {
                    imgLogo.Image = Image.FromFile(ruta);
                }
                else
                {
                    MessageBox.Show($"No se encontró la imagen en: {ruta}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEnPanel(Form formHijo)
        {
            panelContenido.Controls.Clear();
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnRegUsuario_Click(object sender, EventArgs e)
        {
            //UsuarioUI usuarioUI = new UsuarioUI();
            //usuarioUI.ShowDialog();
            MostrarEnPanel(new UsuarioUI());
        }

        private void btnRegPlatos_Click(object sender, EventArgs e)
        {
            //PlatosUI platosUI = new PlatosUI();
            //platosui.ShowDialog();
            MostrarEnPanel(new PlatosUI());
        }

        private void btnRegisPedido_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new RegistroPedidoUI());
        }

        private void DashboardRecepcionistaUI_Load(object sender, EventArgs e)
        {
            if (UsuarioActual != null)
            {
                this.Text = $"Dashboard - {UsuarioActual.nombre}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new RegistroPedidoUI());
        }

        private void btnRegisUsuario_Click(object sender, EventArgs e)
        {
            //UsuarioUI usuarioUI = new UsuarioUI();
            //usuarioUI.ShowDialog();
            MostrarEnPanel(new RegistroPedidoUI());
        }

        private void btnRegisPlato_Click(object sender, EventArgs e)
        {
            //PlatosUI platosUI = new PlatosUI();
            //platosui.ShowDialog();
            MostrarEnPanel(new PlatosUI());
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {

        }

        private void imgLogo_Click_1(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("¿Desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            // Limpiar estado de sesión (si tienes variables globales / singleton)
            UsuarioActual = null;

            // Abrir el formulario de login y cerrar el dashboard actual
            var login = new LoginUI();
            login.Show();

            this.Close();
        }
    }
}
