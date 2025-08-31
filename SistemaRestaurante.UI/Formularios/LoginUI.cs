using SistemaRestaurante.DAL;
using SistemaRestaurante.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRestaurante.BLL;
using SistemaRestaurante.ENT;

namespace SistemaRestaurante.UI.Formularios
{
    public partial class LoginUI : Form
    {
        private readonly LoginBLL _bll;

        // Usuario autenticado (accesible después de DialogResult.OK)
        public Usuario UsuarioAutenticado { get; private set; }

        // Para permitir arrastrar la ventana sin borde
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public LoginUI()
        {
            InitializeComponent();
            _bll = new LoginBLL();
            DiseñoLogin();
            // Hacer que Enter active el login
            this.AcceptButton = btnLogin;
            // Asegurar estado inicial de la contraseña (oculta)
            if (txtPassword != null) txtPassword.UseSystemPasswordChar = true;
            if (chkShow != null) chkShow.Checked = false;

            // Enlazar el evento de mostrar/ocultar contraseña
            if (chkShow != null) chkShow.CheckedChanged += ChkShow_CheckedChanged;
        }

        private void ChkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword == null) return;

            // Guardar posición del cursor para no romper la experiencia al cambiar el modo
            int sel = txtPassword.SelectionStart;
            txtPassword.UseSystemPasswordChar = !chkShow.Checked;
            txtPassword.SelectionStart = sel;
        }

        private void ShowError(string mensaje)
        {
            if (lblError == null) return; // precaución si el diseñador no ha inicializado el control
            lblError.Text = mensaje;
            lblError.Visible = true;
            lblError.BringToFront();
        }

        private void DiseñoLogin()
        {
            lblLogo.BackColor = System.Drawing.Color.FromArgb(236, 213, 188);

            //Botones
            btnLogin.BackColor = System.Drawing.Color.FromArgb(136, 52, 44);
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {

        }

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            var username = txtUsuario.Text?.Trim();
            var password = txtPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Ingrese usuario y contraseña.");
                return;
            }

            try
            {
                var user = _bll.Autenticar(username, password);
                if (user == null)
                {
                    ShowError("Usuario o contraseña incorrectos.");
                    return;
                }

                // Autenticación exitosa
                UsuarioAutenticado = user;
                this.Hide();
                var dashboard = new DashboardAdmiUI();
                dashboard.FormClosed += (s, args) => this.Close();
                dashboard.Show();
            }
            catch (Exception ex)
            {
                ShowError("Error al iniciar sesión: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
