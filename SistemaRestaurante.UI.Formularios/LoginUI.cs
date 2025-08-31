using System;
using System.Runtime.InteropServices;
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

            // Enlazar eventos (por si el Designer no los asignó)
            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;
            chkShow.CheckedChanged += ChkShow_CheckedChanged;
            btnClose.Click += BtnClose_Click;

            // Hacer que Enter active el login
            this.AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError("Error al iniciar sesión: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShow.Checked;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Permitir arrastrar la ventana desde cualquier área con MouseDown si lo deseas
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void ShowError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}