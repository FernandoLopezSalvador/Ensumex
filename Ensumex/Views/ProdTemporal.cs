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
    public partial class ProdTemporal : UserControl
    {
        public ProdTemporal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_ClaveTemp.Text) ||
                string.IsNullOrWhiteSpace(txb_cantidadTemp.Text) ||
                string.IsNullOrWhiteSpace(txb_PrecioUnitarioTemp.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
