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
    public partial class FrmEditarServicios : Form
    {
        AdmServicio admServ = new AdmServicio();
        public FrmEditarServicios()
        {
            InitializeComponent();
            admServ.CargarServicios();
            LlenarCombos();
        }
        private void LlenarCombos()
        {
            admServ.LlenarComboTipo(cmbTipo);
            admServ.LlenarComboUnidad(cmbUnidad);
        }

        private void btnBuscar_Click2(object sender, EventArgs e)
        {
            string tipoB = cmbTipo.Text;
            admServ.BuscarServicioXTipo(tipoB, dgvServicios);
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtPrecio.Text = dgvServicios.Rows[e.RowIndex].Cells["colPrecio"].Value.ToString();
                nudCantidad.Value = Convert.ToDecimal(dgvServicios.Rows[e.RowIndex].Cells["colCantidad"].Value);
                cmbUnidad.SelectedItem = dgvServicios.Rows[e.RowIndex].Cells["colUnidad"].Value.ToString();

                if (dgvServicios.Rows[e.RowIndex].Cells["colObsv"].Value != null)
                {
                    txtObservacion.Text = dgvServicios.Rows[e.RowIndex].Cells["colObsv"].Value.ToString();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               string tipo = cmbTipo.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                int cantidad = (int)nudCantidad.Value;
                string unidad = cmbUnidad.Text;
                string observacion = txtObservacion.Text;

                admServ.EditarServicio(tipo, precio, cantidad, unidad, observacion);

                admServ.BuscarServicioXTipo(tipo, dgvServicios);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos: " + ex.Message);
            }
        }
    }
    }
}
