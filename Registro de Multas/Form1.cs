using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_de_Multas
{
    public partial class frmMultas : Form
    {
        ListViewItem item;
        public frmMultas()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            double velocidad = double.Parse(txtVelocidad.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime hora = DateTime.Parse(lblHora.Text);

            double multa = 0;

            if (velocidad <= 70)
            {
                multa = 0;
            }
            else if (velocidad > 70 && velocidad <= 90)
            {
                multa = 120;
            }
            else if (velocidad > 90 && velocidad <= 100)
            {
                multa = 240;
            }
            else if (velocidad > 100) multa = 350;


            ListViewItem fila = new ListViewItem(placa);

            fila.SubItems.Add(lblFecha.Text);
            fila.SubItems.Add(lblHora.Text);
            fila.SubItems.Add(velocidad.ToString("0.00"));
            fila.SubItems.Add(multa.ToString("C"));

            lvMultas.Items.Add(fila);



        }

        private void frmMultas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(item != null)
            {
                lvMultas.Items.Remove(item);
                MessageBox.Show("Los Registros de Multas se han Borrado Exitosamente");
                btnLimpiar_Click(sender, e);

            }
            else{

                MessageBox.Show("Debe Seleccionar Una Multa de la Lista" );

               
            }


        }

        private void lvMultas_MouseClick(object sender, MouseEventArgs e)
        {
            item = lvMultas.GetItemAt(e.X, e.Y);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtVelocidad.Clear();
            txtPlaca.Focus();
        }
    }
}
