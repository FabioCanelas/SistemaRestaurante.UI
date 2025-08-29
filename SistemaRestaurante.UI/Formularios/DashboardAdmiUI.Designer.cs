namespace SistemaRestaurante.UI.Formularios
{
    partial class DashboardAdmiUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.btnRegisPedido = new System.Windows.Forms.Button();
            this.btnRegisPlato = new System.Windows.Forms.Button();
            this.btnRegisUsuario = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Silver;
            this.panelMenu.Controls.Add(this.imgLogo);
            this.panelMenu.Controls.Add(this.btnRegisPedido);
            this.panelMenu.Controls.Add(this.btnRegisPlato);
            this.panelMenu.Controls.Add(this.btnRegisUsuario);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(176, 312);
            this.panelMenu.TabIndex = 0;
            // 
            // imgLogo
            // 
            this.imgLogo.Location = new System.Drawing.Point(12, 12);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(164, 87);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogo.TabIndex = 9;
            this.imgLogo.TabStop = false;
            this.imgLogo.Click += new System.EventHandler(this.imgLogo_Click_1);
            // 
            // btnRegisPedido
            // 
            this.btnRegisPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisPedido.Location = new System.Drawing.Point(0, 201);
            this.btnRegisPedido.Name = "btnRegisPedido";
            this.btnRegisPedido.Size = new System.Drawing.Size(176, 53);
            this.btnRegisPedido.TabIndex = 8;
            this.btnRegisPedido.Text = "Registrar Pedidos";
            this.btnRegisPedido.UseVisualStyleBackColor = true;
            this.btnRegisPedido.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRegisPlato
            // 
            this.btnRegisPlato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisPlato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisPlato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisPlato.Location = new System.Drawing.Point(0, 151);
            this.btnRegisPlato.Name = "btnRegisPlato";
            this.btnRegisPlato.Size = new System.Drawing.Size(176, 53);
            this.btnRegisPlato.TabIndex = 7;
            this.btnRegisPlato.Text = "Registrar Platos";
            this.btnRegisPlato.UseVisualStyleBackColor = true;
            this.btnRegisPlato.Click += new System.EventHandler(this.btnRegisPlato_Click);
            // 
            // btnRegisUsuario
            // 
            this.btnRegisUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisUsuario.Location = new System.Drawing.Point(0, 100);
            this.btnRegisUsuario.Name = "btnRegisUsuario";
            this.btnRegisUsuario.Size = new System.Drawing.Size(176, 53);
            this.btnRegisUsuario.TabIndex = 6;
            this.btnRegisUsuario.Text = "Registrar Usuario";
            this.btnRegisUsuario.UseVisualStyleBackColor = true;
            this.btnRegisUsuario.Click += new System.EventHandler(this.btnRegisUsuario_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(176, 0);
            this.panelContenido.Margin = new System.Windows.Forms.Padding(2);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(324, 312);
            this.panelContenido.TabIndex = 1;
            // 
            // DashboardAdmiUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 312);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DashboardAdmiUI";
            this.Text = "Dashboard Administrador";
            this.Load += new System.EventHandler(this.DashboardAdmiUI_Load);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Button btnRegisUsuario;
        private System.Windows.Forms.Button btnRegisPedido;
        private System.Windows.Forms.Button btnRegisPlato;
        private System.Windows.Forms.PictureBox imgLogo;
    }
}