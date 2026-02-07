using System;
using System.Windows.Forms;
using Controlador;

namespace Vista
{
    public partial class FrmEliminarServicio : Form
    {
        AdmServicio admServ = new AdmServicio();
        public FrmEliminarServicio()
        {
            InitializeComponent();
            admServ.LlenarTabla(dgvServicios);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = 0;
            string tipoB = "";
            if (dgvServicios.SelectedRows.Count == 1)
            {
                indice = dgvServicios.SelectedRows[0].Index;
                tipoB = dgvServicios.SelectedRows[0].Cells["colTipo"].Value?.ToString();
                DialogResult result = MessageBox.Show(
                           "Desea Eliminar al Servicio "+ tipoB + "?",
                           "Confirmacion",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    admServ.EliminarServicio(tipoB);
                    dgvServicios.Rows.RemoveAt(indice);

                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }
    }
}