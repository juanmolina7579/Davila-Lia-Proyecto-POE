using Controlador;
using System;
using System.Windows.Forms;

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

        private void FrmListarServicio_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
