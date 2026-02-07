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

namespace Vista
{
    public partial class FrmEditarServicios : Form
    {
        AdmServicio admServ = new AdmServicio();
        public FrmEditarServicios()
        {
            InitializeComponent();
            admServ.LlenarComboTipo(cmbTipo);
        }

        private void btnBuscar_Click2(object sender, EventArgs e)
        {
            string tipoB = (string)cmbTipo.SelectedItem;
            if (!string.IsNullOrEmpty(tipoB))
            {
                admServ.BuscarServicioXTipo(tipoB, dgvServicios);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de servicio para buscar.");
            }
        }
    }
}
