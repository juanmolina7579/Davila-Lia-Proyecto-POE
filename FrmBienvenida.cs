using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmBienvenida : Form
    {
        string nombre = "";
        public FrmBienvenida(string nombre)
        {
            InitializeComponent();
            this.Text += " "+nombre;
            lblIngreso.Text = "Hola "+nombre;
        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu=new FrmMenu();
            this.Visible = false;
            frmMenu.ShowDialog();
        }
    }
}
