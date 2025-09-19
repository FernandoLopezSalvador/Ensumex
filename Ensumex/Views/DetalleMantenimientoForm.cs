using Ensumex.Controllers;
using Ensumex.Models;
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
    public partial class DetalleMantenimientoForm : Form
    {
        private int _mantenimientoId;

        public DetalleMantenimientoForm(int mantenimientoId)
        {
            InitializeComponent();
            _mantenimientoId = mantenimientoId;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrWhiteSpace(txtRealizadoPor.Text))
            {
                MessageBox.Show("Debe indicar quién realizó el servicio.");
                return;
            }
            SqlServerRepository.InsertarDetalleMantenimiento(
                _mantenimientoId,
                txtRealizadoPor.Text,
                txtObservaciones.Text
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
