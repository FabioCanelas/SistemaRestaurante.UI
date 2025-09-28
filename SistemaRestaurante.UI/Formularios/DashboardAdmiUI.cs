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
using SistemaRestaurante.BLL;
using SistemaRestaurante.DAL;

namespace SistemaRestaurante.UI.Formularios
{
    public partial class DashboardAdmiUI : Form
    {
        // Propiedad para recibir el usuario autenticado desde el login
        public Usuario UsuarioActual { get; set; }
        private GananciasBLL _gananciasBLL;
        private Timer _timerActualizacion;

        public DashboardAdmiUI()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            ColorearBotonesPanel();
            CargarImagenes();
            
            // Inicializar BLL de ganancias
            _gananciasBLL = new GananciasBLL();
            
            // Configurar timer para actualizar cada 30 segundos
            _timerActualizacion = new Timer();
            _timerActualizacion.Interval = 30000; // 30 segundos
            _timerActualizacion.Tick += Timer_Tick;
            _timerActualizacion.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Solo actualizar si no hay formularios hijos cargados
            if (panelContenido.Controls.Count == 0 || 
                panelContenido.Controls.OfType<Form>().Count() == 0)
            {
                MostrarPanelGanancias();
            }
        }

        private void ColorearBotonesPanel()
        {
            // PANEL
            if (panelMenu != null) panelMenu.BackColor = Color.FromArgb(107, 46, 40);

            // Colorear los botones dentro del panel para evitar dependencias por nombre
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
                    System.Diagnostics.Debug.WriteLine($"No se encontró la imagen en: {ruta}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar la imagen: {ex.Message}");
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

        private void MostrarPanelGanancias()
        {
            panelContenido.Controls.Clear();
            
            // Panel principal en la parte superior
            var panelPrincipal = new Panel
            {
                Size = new Size(800, 120),
                BackColor = Color.Transparent,
                Location = new Point(20, 20) // Posición fija en la parte superior
            };

            // Crear las 4 tarjetas
            CrearTarjetaGanancia(panelPrincipal, "💰 Ganancia Hoy", 
                _gananciasBLL.FormatearMoneda(_gananciasBLL.ObtenerGananciaDelDia()), 
                Color.FromArgb(76, 175, 80), new Point(0, 0));
                
            CrearTarjetaGanancia(panelPrincipal, "📅 Ganancia del Mes", 
                _gananciasBLL.FormatearMoneda(_gananciasBLL.ObtenerGananciaDelMes()), 
                Color.FromArgb(33, 150, 243), new Point(200, 0));
                
            CrearTarjetaGanancia(panelPrincipal, "🛒 Pedidos Hoy", 
                _gananciasBLL.ObtenerTotalPedidosDelDia().ToString(), 
                Color.FromArgb(255, 87, 34), new Point(400, 0));
                
            CrearTarjetaGanancia(panelPrincipal, "📈 Promedio Diario", 
                _gananciasBLL.FormatearMoneda(_gananciasBLL.ObtenerPromedioDiarioDelMes()), 
                Color.FromArgb(156, 39, 176), new Point(600, 0));

            panelContenido.Controls.Add(panelPrincipal);
        }

        private void CrearTarjetaGanancia(Panel contenedor, string titulo, string valor, Color color, Point ubicacion)
        {
            var tarjeta = new Panel
            {
                Size = new Size(190, 120),
                Location = ubicacion,
                BackColor = color,
                BorderStyle = BorderStyle.None
            };

            var lblTitulo = new Label
            {
                Text = titulo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(5, 20),
                Size = new Size(180, 30),
                BackColor = Color.Transparent
            };

            var lblValor = new Label
            {
                Text = valor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(5, 55),
                Size = new Size(180, 40),
                BackColor = Color.Transparent
            };

            tarjeta.Controls.Add(lblTitulo);
            tarjeta.Controls.Add(lblValor);
            contenedor.Controls.Add(tarjeta);
        }

        private void DashboardAdmiUI_Load(object sender, EventArgs e)
        {
            // ejemplo: usar UsuarioActual para mostrar nombre
            if (UsuarioActual != null)
            {
                this.Text = $"Dashboard Administrador - {UsuarioActual.nombre}";
            }
            
            // Mostrar panel de ganancias por defecto
            MostrarPanelGanancias();
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
            // Cuando hagan clic en el logo, volver al dashboard de ganancias
            MostrarPanelGanancias();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarEnPanel(new ReportesUI());
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
