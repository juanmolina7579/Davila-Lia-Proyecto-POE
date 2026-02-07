using System;
using System.Windows.Forms;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class FrmRegistrarServicios : Form
    {
        AdmServicio admServ = new AdmServicio();
        public FrmRegistrarServicios()
        {
            InitializeComponent();
            admServ.LlenarComboTipo(cmbTipo);
            admServ.LlenarComboUnidad(cmbUnidad);
            cmbTipo.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipo.SelectedItem?.ToString();
            string unidad = cmbUnidad.SelectedItem?.ToString();
            string precioTexto = txtPrecio.Text;
            string observacion = txtObservacion.Text;

            int cantidad = (int)txtCantidad.Value;
            if (!admServ.EsVacio(tipo, txtPrecio.Text, unidad))
            {
                double precio = double.Parse(precioTexto);
                string contenido = admServ.Registrar(tipo, precio, cantidad, unidad, observacion);
                txtContenido.Text = contenido;
                LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            cmbTipo.SelectedIndex = -1;
            txtPrecio.Clear();
            txtCantidad.Value = 1;
            txtObservacion.Clear();
            cmbUnidad.SelectedIndex = -1;
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
                && e.KeyChar != ',' 
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
