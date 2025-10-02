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
    public partial class ModificarNumeroForm : UserControl
    {
        public string NuevoNumero { get; private set; }
        private TextBox txtNumero;
        private Button btnAceptar;

        // Evento para notificar cuando se guarda el número
        public event EventHandler NumeroGuardado;

        public ModificarNumeroForm(string numeroActual)
        {
            Text = "Modificar Teléfono";
            Size = new Size(300, 150);

            var lbl = new Label { Text = "Nuevo número:", Location = new Point(10, 20), AutoSize = true };
            txtNumero = new TextBox { Text = numeroActual, Location = new Point(110, 18), Width = 150 };
            btnAceptar = new Button { Text = "Guardar", Location = new Point(110, 60), Width = 80 };

            btnAceptar.Click += (s, e) =>
            {
                NuevoNumero = txtNumero.Text;
                NumeroGuardado?.Invoke(this, EventArgs.Empty);
            };

            Controls.Add(lbl);
            Controls.Add(txtNumero);
            Controls.Add(btnAceptar);
        }
    }
}
