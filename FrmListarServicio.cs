using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class FrmListarServicio : Form
    {
        AdmServicio admServ = new AdmServicio();
        public FrmListarServicio()
        {
            InitializeComponent();
            admServ.CargarServicios();
            admServ.LlenarTabla(dgvServicios);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            List<Servicio> listaParaImprimir = admServ.GetListaServicios();

            AdmReporte admRep = new AdmReporte();
            admRep.CrearReporte(listaParaImprimir);
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            numDesde.Value = 0;
            numHasta.Value = 0;
            admServ.LlenarTabla(dgvServicios);
        }

        private void rbtPrecio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPrecio.Checked)
            {
                numDesde.DecimalPlaces = 2;
                numHasta.DecimalPlaces = 2;

                numDesde.Increment = 0.50M;
                numHasta.Increment = 0.50M;
            }
        }

        private void rbtCantidad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCantidad.Checked)
            {
                numDesde.DecimalPlaces = 0;
                numHasta.DecimalPlaces = 0;

                numDesde.Increment = 1;
                numHasta.Increment = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numDesde.Value > numHasta.Value)
            {
                MessageBox.Show("El valor 'Desde' no puede ser mayor que 'Hasta'.");
                return;
            }
            if (rbtPrecio.Checked)
            {
                double min = (double)numDesde.Value;
                double max = (double)numHasta.Value;

                admServ.FiltrarXPrecio(min, max, dgvServicios);
            }
            else if (rbtCantidad.Checked)
            {
                int min = (int)numDesde.Value;
                int max = (int)numHasta.Value;

                admServ.FiltrarXCantidad(min, max, dgvServicios);
            }
        }
    
    }
}
