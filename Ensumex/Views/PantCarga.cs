using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Models;
using Ensumex.Forms;

namespace Ensumex.Views
{
    public partial class Cargando : Form
    {
        public Cargando()
        {
            InitializeComponent();
            personalizar();
            
        }
        // muestra al ususario que ingreso en el label LblUsuario
        private void personalizar()
        {
            this.CenterToScreen();
            progressBar1.ForeColor = Color.DeepSkyBlue; 
            progressBar1.BackColor = Color.DarkGray;    
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += .05;

            progressBar1.Value += 1;
            LblEstado.Text = $"Cargando... {progressBar1.Value}%";

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= .01;
            if (this.Opacity <= 0)
            {
                timer2.Stop();
                this.Close(); // Solo cierra Cargando
            }
        }

        private void Cargando_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            timer1.Start();
            CargaUsuario.CargarDatosUsuario(LblUsuario, LblPoss);
        }
    }
}
