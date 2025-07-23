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

        private void personalizar()
        {
            this.CenterToScreen();
            this.Opacity = 0.0;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(33, 33, 33); // Dark grey
            this.StartPosition = FormStartPosition.CenterScreen;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.ForeColor = Color.FromArgb(3, 169, 244); // Material Blue
            progressBar1.BackColor = Color.FromArgb(189, 189, 189); // Grey
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
            this.Opacity -= .02;
            if (this.Opacity <= 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private async void Cargando_Load(object sender, EventArgs e)
        {
            await FadeInAsync();
            CargaUsuario.CargarDatosUsuario(LblUsuario, LblPoss);

            await SimularCargaAsync();

            await FadeOutAsync();
            this.Close();
        }
        private async Task FadeInAsync()
        {
            while (this.Opacity < 1)
            {
                this.Opacity += 0.05;
                await Task.Delay(20);
            }
        }

        private async Task FadeOutAsync()
        {
            while (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
                await Task.Delay(20);
            }
        }
        private async Task SimularCargaAsync()
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                LblEstado.Text = $"Cargando{new string('.', (i / 10) % 4)} {i}%"; // Animación puntos
                await Task.Delay(40); // velocidad de carga simulada
            }
        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
