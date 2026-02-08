using System;
using System.Windows.Forms;
using Controlador;

namespace Vista
{
    public partial class FrmMenu : Form
    {
        AdmServicio admServ = new AdmServicio();
        public FrmMenu()
        {
            InitializeComponent();

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarServicios frmRegServ = new FrmRegistrarServicios();
            frmRegServ.ShowDialog();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admServ.CargarServicios();
            if (admServ.GetCantidadLista() > 0)
            {
                FrmListarServicio frmLisServ = new FrmListarServicio();
                frmLisServ.ShowDialog();
            } 

            else {
                MessageBox.Show("No existen servicios registrados");
            }

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe frmAcerca = new FrmAcercaDe();
            frmAcerca.ShowDialog();

        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admServ.Conectar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admServ.CargarServicios();
            if (admServ.GetCantidadLista() > 0)
            {
                FrmEliminarServicio frmEliServ = new FrmEliminarServicio();
                frmEliServ.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen servicios registrados para eliminar.");
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admServ.CargarServicios();
            if (admServ.GetCantidadLista() > 0)
            {
                FrmEditarServicios frmEditServ = new FrmEditarServicios();
                frmEditServ.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen servicios registrados para editar.");
            }
        }
    }
}
