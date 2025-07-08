using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Utils;
using Ensumex.Views;
using FirebirdSql.Data.FirebirdClient;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ensumex.Forms
{
    public partial class ENSUMEX : MaterialForm
    {
        private string connFirebird = "User=SYSDBA;Password=masterkey;Database=localhost:C:\\Users\\PC\\Documents\\SAE\\Nueva carpeta\\SAE90EMPRE01.FDB;DataSource=192.168.1.100;Port=3050;Dialect=3;Charset=NONE;ServerType=0;";
        private string connSqlServer = "Server=localhost;Database=Ensumex;Trusted_Connection=True;";

        [Obsolete]
        public ENSUMEX()
        {
            InitializeComponent();
            Tema.ConfigurarTema(this);
            InicializarFormulario();
            ConfigurarMenu();
            CargarDatosUsuario();
            CargarUserControl(new Cotizaciones());
        }
        private void InicializarFormulario()
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Cursor = Cursors.Hand;
        }
        private void ConfigurarMenu()
        {
            menu_usuario.Renderer = new CustomMenuRenderer();
        }
        private void CargarDatosUsuario()
        {
            CargaUsuario.CargarDatosUsuario(lbl_UsuarioInicio, lbl_posicion);

            // Controlar visibilidad del menú principal según el rol
            if (lbl_posicion.Text.Trim().Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                menu_usuario.Visible = false; // Oculta el menú principal
            }
            else if (lbl_posicion.Text.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                menu_usuario.Visible = true; // Muestra el menú principal
            }
            else
            {
                // Puedes decidir si ocultar o mostrar por defecto para otros roles
                menu_usuario.Visible = false;
            }
        }
        private void lbl_cuenta_Click(object sender, EventArgs e)
        {
        }
        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
            }
        }
        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Color.FromArgb(30, 30, 30);
            public override Color MenuStripGradientEnd => Color.FromArgb(30, 30, 30);
        }
        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesion?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btn_cerrarsesion_MouseEnter(object sender, EventArgs e)
        {
            btn_cerrarsesion.BackColor = Color.FromArgb(25, 239, 22);
        }
        private void btn_cerrarsesion_MouseLeave(object sender, EventArgs e)
        {
            btn_cerrarsesion.BackColor = Color.FromArgb(0, 104, 56);
        }
        [Obsolete]
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Users());
        }
        private void materialButton1_MouseEnter(object sender, EventArgs e)
        {
            btn_inventarioP.BackColor = Color.FromArgb(25, 239, 22);
        }
        private void btn_inventarioP_MouseLeave(object sender, EventArgs e)
        {
            btn_inventarioP.BackColor = Color.FromArgb(0, 104, 56);
        }
        private void btn_inventarioP_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Product());
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Cotiza(lbl_UsuarioInicio.Text));
        }
        private void ENSUMEX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!VentanaHelper.ConfirmarCerrarFormulario())
            {
                e.Cancel = true;
            }
        }
        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.Theme = manager.Theme == MaterialSkinManager.Themes.LIGHT
                ? MaterialSkinManager.Themes.DARK
                : MaterialSkinManager.Themes.LIGHT;
        }
        private void CargarUserControl(UserControl control)
        {
            panelContenedor.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(control);
        }
        private void administrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void materialButton3_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Clients());
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // Evento para el botón de sincronización
        private async void btn_sincronizar_Click(object sender, EventArgs e)
        {
            btn_sincronizar.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;

            try
            {
                await Task.Run(() =>
                {
                    SincronizarProductosYClientes();
                });

                MessageBox.Show("Sincronización completa.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btn_sincronizar.Enabled = true;
                progressBar1.Value = 0;
            }
        }
        // Método para sincronizar productos y clientes desde Firebird a SQL Server
        private void SincronizarProductosYClientes()
        {
            // 1. Traer productos de Firebird
            DataTable productosFB = new DataTable();
            using (FbConnection connFb = new FbConnection(connFirebird))
            {
                connFb.Open();
                string queryP = "SELECT CVE_ART, DESCR, UNI_MED, COSTO_PROM, ULT_COSTO, EXIST FROM INVE01";
                FbCommand cmdP = new FbCommand(queryP, connFb);
                FbDataAdapter adapterP = new FbDataAdapter(cmdP);
                adapterP.Fill(productosFB);
                connFb.Close();
            }
            // 2. Traer clientes de Firebird
            DataTable clientesFB = new DataTable();
            using (FbConnection connFb = new FbConnection(connFirebird))
            {
                connFb.Open();
                string queryC = "SELECT CLAVE, STATUS, NOMBRE, CALLE, COLONIA, MUNICIPIO, EMAILPRED FROM CLIE01";
                FbCommand cmdC = new FbCommand(queryC, connFb);
                FbDataAdapter adapterC = new FbDataAdapter(cmdC);
                adapterC.Fill(clientesFB);
                connFb.Close();
            }
            int totalRegistros = productosFB.Rows.Count + clientesFB.Rows.Count;
            // Configurar progressBar en UI
            this.Invoke((Action)(() =>
            {
                // Actualizar el máximo de la barra de progreso y reiniciar su valor
                progressBar1.Maximum = totalRegistros;
                progressBar1.Value = 0;
            }));
            using (SqlConnection connSql = new SqlConnection(connSqlServer))
            {
                connSql.Open();

                // Limpiar tablas en SQL Server
                using (SqlCommand deleteProductos = new SqlCommand("DELETE FROM INVE01", connSql))
                {
                    deleteProductos.ExecuteNonQuery();
                }
                using (SqlCommand deleteClientes = new SqlCommand("DELETE FROM CLIE01", connSql))
                {
                    deleteClientes.ExecuteNonQuery();
                }
                try
                {
                    int progreso = 0;
                    int total = productosFB.Rows.Count + clientesFB.Rows.Count;
                    progressBar1.Maximum = total;
                    using (SqlTransaction transaction = connSql.BeginTransaction())
                    {
                        try
                        {
                            // Insertar productos
                            foreach (DataRow row in productosFB.Rows)
                            {
                                using (SqlCommand insertP = new SqlCommand(
                                    @"INSERT INTO INVE01 (CVE_ART, DESCR, UNI_MED, COSTO_PROM, ULT_COSTO, EXIST)
                                    VALUES (@CVE_ART, @DESCR, @UNI_MED, @COSTO_PROM, @ULT_COSTO, @EXIST)", connSql, transaction))
                                {
                                    insertP.Parameters.AddWithValue("@CVE_ART", row["CVE_ART"] ?? DBNull.Value);
                                    insertP.Parameters.AddWithValue("@DESCR", row["DESCR"] ?? DBNull.Value);
                                    insertP.Parameters.AddWithValue("@UNI_MED", row["UNI_MED"] ?? DBNull.Value);
                                    insertP.Parameters.AddWithValue("@COSTO_PROM", row["COSTO_PROM"] ?? DBNull.Value);
                                    insertP.Parameters.AddWithValue("@ULT_COSTO", row["ULT_COSTO"] ?? DBNull.Value);
                                    insertP.Parameters.AddWithValue("@EXIST", row["EXIST"] ?? DBNull.Value);
                                    insertP.ExecuteNonQuery();
                                }
                                progreso++;
                                this.Invoke((Action)(() =>
                                {
                                    progressBar1.Value = progreso;
                                }));
                            }
                            // Insertar clientes
                            foreach (DataRow row in clientesFB.Rows)
                            {
                                using (SqlCommand insertC = new SqlCommand(
                                    @"INSERT INTO CLIE01 (CLAVE, STATUS, NOMBRE, CALLE, COLONIA, MUNICIPIO, EMAILPRED)
                                    VALUES (@CLAVE, @STATUS, @NOMBRE, @CALLE, @COLONIA, @MUNICIPIO, @EMAILPRED)", connSql, transaction))
                                {
                                    insertC.Parameters.AddWithValue("@CLAVE", row["CLAVE"] ?? DBNull.Value);
                                    insertC.Parameters.AddWithValue("@STATUS", row["STATUS"] ?? DBNull.Value);
                                    insertC.Parameters.AddWithValue("@NOMBRE", row["NOMBRE"] ?? DBNull.Value);
                                    insertC.Parameters.AddWithValue("@CALLE", row["CALLE"] ?? DBNull.Value);
                                    insertC.Parameters.AddWithValue("@COLONIA", row["COLONIA"] ?? DBNull.Value);
                                    insertC.Parameters.AddWithValue("@MUNICIPIO", row["MUNICIPIO"] ?? DBNull.Value);
                                    insertC.Parameters.AddWithValue("@EMAILPRED", row["EMAILPRED"] ?? DBNull.Value);
                                    insertC.ExecuteNonQuery();
                                }
                                progreso++;
                                this.Invoke((Action)(() =>
                                {
                                    progressBar1.Value = progreso;
                                }));
                            }

                            // Confirmar la transacción si todo salió bien
                            transaction.Commit();
                            MessageBox.Show("Datos importados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exTransaccion)
                        {
                            // Revertir si algo falla
                            transaction.Rollback();
                            MessageBox.Show("Error al insertar datos:\n" + exTransaccion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connSql.Close();
            }
        }
        private void Btn_Inicio_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Cotizaciones());
        }
    }
} 
