using System;
using System.Windows.Forms;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class FrmGestionServicios : Form
    {
        AdmServicio AdmServ = new AdmServicio();
        public FrmGestionServicios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmGestionServicios_Load(object sender, EventArgs e)
        {
            AdmServ.LlenarComboTipo(cmbTipo);
            AdmServ.LlenarComboUnidad(cmbUnidad);

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
            if (!AdmServ.EsVacio(tipo, txtPrecio.Text, unidad))
            {
                double precio = double.Parse(precioTexto);
                string contenido = AdmServ.Registrar(tipo, precio, cantidad, unidad, observacion);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {}

        private void btnEliminar_Click(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {}
        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void label1_Click_1(object sender, EventArgs e)
        {}

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
