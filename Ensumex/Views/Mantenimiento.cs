using Ensumex.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Mantenimiento : UserControl
    {
        public Mantenimiento()
        {

            InitializeComponent();
            var datos = FirebirdRepository.GetCalentadoresParaMantenimiento();
            dgvMantenimiento.DataSource = datos;

            foreach (DataGridViewRow row in dgvMantenimiento.Rows)
            {   
                row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }
    }
    
}
