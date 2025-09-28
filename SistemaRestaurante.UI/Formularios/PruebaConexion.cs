using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRestaurante.DAL;
using System.Data.SQLite;

namespace SistemaRestaurante.UI.Formularios
{
    public partial class PruebaConexion : Form
    {
        public PruebaConexion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "Probando conexión...";
            lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;

            try
            {
                var conexion = new ConexionDB();
                using (var cn = conexion.GetConnection())
                {
                    cn.Open(); // Si no lanza excepción, la conexión es válida
                }
                lblResultado.Text = "Conexión SQLite exitosa";
                lblResultado.ForeColor = System.Drawing.Color.ForestGreen;
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Firebrick;
            }
        }
    }
}
