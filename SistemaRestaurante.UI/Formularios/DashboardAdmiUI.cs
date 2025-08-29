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
    public partial class DashboardAdmiUI : Form
    {
        public DashboardAdmiUI()
        {
            InitializeComponent();
            this.ClientSize = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            ColorearBotonesPanel();
            CargarImagenes();
        }

        private void ColorearBotonesPanel()
        {
            //PANEL
            panelMenu.BackColor = System.Drawing.Color.FromArgb(107, 46, 40);

            //Botones
            btnRegisUsuario.BackColor = System.Drawing.Color.FromArgb(243, 228, 210);
            btnRegisUsuario.ForeColor = System.Drawing.Color.FromArgb(88, 73, 59);
            btnRegisPlato.BackColor = System.Drawing.Color.FromArgb(243, 228, 210);
            btnRegisPlato.ForeColor = System.Drawing.Color.FromArgb(88, 73, 59);
            btnRegisPedido.BackColor = System.Drawing.Color.FromArgb(243, 228, 210);
            btnRegisPedido.ForeColor = System.Drawing.Color.FromArgb(88, 73, 59);
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

        private void DashboardAdmiUI_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new RegistroPedidoUI());
        }

        private void btnRegisUsuario_Click(object sender, EventArgs e)
        {
            //UsuarioUI usuarioUI = new UsuarioUI();
            //usuarioUI.ShowDialog();
            MostrarEnPanel(new UsuarioUI());
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

        }
    }
}
