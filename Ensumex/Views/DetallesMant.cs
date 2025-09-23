using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Controllers; // Asegúrate de tener el using correcto

namespace Ensumex.Views
{
    public partial class DetallesMant : UserControl
    {
        public DetallesMant(int mantenimientoId)
        {
            InitializeComponent();
            CargarDetalles(mantenimientoId);
        }

        private void CargarDetalles(int mantenimientoId)
        {
            var dt = SqlServerRepository.GetDetallesMantenimiento(mantenimientoId);
            GridMantenimientos.DataSource = dt;
            GridMantenimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridMantenimientos.ReadOnly = true;
        }
    }

    public class DetallesMantForm : Form
    {
        public DetallesMantForm(int mantenimientoId)
        {
            this.Text = "Detalles del Mantenimiento";
            this.Size = new Size(700, 400);

            var detallesControl = new DetallesMant(mantenimientoId)
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(detallesControl);
        }
    }
}
