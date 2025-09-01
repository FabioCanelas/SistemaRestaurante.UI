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

            // Inicializar combobox de roles (si existe en el diseñador)
            if (cbxRol != null)
            {
                cbxRol.Items.Clear();
                foreach (var name in Enum.GetNames(typeof(Rol)))
                    cbxRol.Items.Add(name);
                cbxRol.SelectedIndex = 0; // Seleccionar 'Seleccionar' por defecto
            }

            // Hacer que Enter active el login
            this.AcceptButton = btnLogin;
            // Asegurar estado inicial de la contraseña (oculta)
            if (txtPassword != null) txtPassword.UseSystemPasswordChar = true;
            if (chkShow != null) chkShow.Checked = false;

            // Enlazar eventos (por si el diseñador no lo hizo)
            if (btnLogin != null) btnLogin.Click += btnLogin_Click;
            if (btnCancel != null) btnCancel.Click += btnCancel_Click;
            if (btnClose != null) btnClose.Click += BtnClose_Click;
            if (chkShow != null) chkShow.CheckedChanged += ChkShow_CheckedChanged;
        }

        private void ChkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword == null) return;
            int sel = txtPassword.SelectionStart;
            txtPassword.UseSystemPasswordChar = !chkShow.Checked;
            txtPassword.SelectionStart = sel;
        }

        private void ShowError(string mensaje)
        {
            if (lblError == null) return;
            lblError.Text = mensaje;
            lblError.Visible = true;
            lblError.BringToFront();
        }

        private void limpiarEspacios()
        {
            if (lblError != null) lblError.Visible = false;
            if (txtUsuario != null) txtUsuario.Text = string.Empty;
            if (txtPassword != null) txtPassword.Text = string.Empty;
            if (cbxRol != null) cbxRol.SelectedIndex = 0;
            if (txtUsuario != null) txtUsuario.Focus();
        }

        private void DiseñoLogin()
        {
            if (lblLogo != null) lblLogo.BackColor = System.Drawing.Color.FromArgb(236, 213, 188);
            if (btnLogin != null) btnLogin.BackColor = System.Drawing.Color.FromArgb(136, 52, 44);
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {

        }

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (lblError != null) lblError.Visible = false;

            var username = txtUsuario.Text?.Trim();
            var password = txtPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Ingrese usuario y contraseña.");
                return;
            }

            // Validar que el usuario haya seleccionado un rol (no "Seleccionar")
            if (cbxRol != null)
            {
                if (cbxRol.SelectedItem == null || string.Equals(cbxRol.SelectedItem.ToString(), Rol.Seleccionar.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ShowError("Debe seleccionar un rol.");
                    return;
                }
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

                // Verificar que la selección coincide con el rol en BD
                if (cbxRol != null && cbxRol.SelectedItem != null)
                {
                    var sel = cbxRol.SelectedItem.ToString();
                    if (Enum.TryParse<Rol>(sel, true, out var parsed))
                    {
                        if (parsed != user.rol)
                        {
                            ShowError("El rol seleccionado no coincide con el rol del usuario.");
                            return;
                        }
                    }
                }

                // Usar rol de la BD para decidir dashboard
                var rolBD = user.rol;

                if (rolBD == Rol.ADMIN)
                {
                    this.Hide();
                    var dash = new DashboardAdmiUI();
                    dash.UsuarioActual = UsuarioAutenticado;
                    // Cuando el dashboard se cierre, mostramos nuevamente el login (en vez de cerrarlo)
                    limpiarEspacios();
                    dash.FormClosed += (s, args) => this.Show();
                    dash.Show();
                    return;
                }

                if (rolBD == Rol.RECEPCIONISTA)
                {
                    this.Hide();
                    var dash = new DashboardRecepcionistaUI();
                    dash.UsuarioActual = UsuarioAutenticado;
                    // Cuando el dashboard se cierre, mostramos nuevamente el login (en vez de cerrarlo)
                    limpiarEspacios();
                    dash.FormClosed += (s, args) => this.Show();
                    dash.Show();
                    return;
                }

                // Rol no reconocido
                ShowError("Rol de usuario no autorizado.");     
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
    
        }
    }
}