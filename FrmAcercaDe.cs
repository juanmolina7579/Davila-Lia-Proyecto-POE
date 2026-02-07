using Modelo;
using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmAcercaDe : Form
    {
        AdmAutor admA = new AdmAutor();
        public FrmAcercaDe()
        {
            InitializeComponent();
        }
        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {
            MiFormularioDinamicoAle();
        }
        private void MiFormularioDinamicoAle()
        {
            List<Autor> listaControles = admA.ObtenerDatosAutor();

            foreach (Autor item in listaControles)
            {
                if (item.TipoControl == "Label")
                {
                    Label lblTitulo = new Label();
                    lblTitulo.Text = item.Etiqueta;
                    lblTitulo.Location = new Point(item.PosicionX, item.PosicionY);
                    lblTitulo.AutoSize = true;
                    lblTitulo.Font = new Font("Arial", 10, FontStyle.Bold);
                    this.Controls.Add(lblTitulo);

                    Label lblValor = new Label();
                    lblValor.Text = item.Valor;
                    lblValor.Location = new Point(item.PosicionX + 80, item.PosicionY);
                    lblValor.AutoSize = true;
                    this.Controls.Add(lblValor);
                }
                else if (item.TipoControl == "PictureBox")
                {
                    PictureBox pb = new PictureBox();
                    pb.Location = new Point(item.PosicionX, item.PosicionY);
                    pb.Size = new Size(item.Ancho, item.Alto);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.BorderStyle = BorderStyle.FixedSingle;

                    if (item.Foto != null && item.Foto.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(item.Foto))
                        {
                            Image imagenOriginal = Image.FromStream(ms);

                            pb.Image = FijarMiFoto(imagenOriginal);
                        }
                    }
                    this.Controls.Add(pb);
                }
            }
        }
        private Image FijarMiFoto(Image imagen)
        {
            if (Array.IndexOf(imagen.PropertyIdList, 274) > -1)
            {
                int orientacion = imagen.GetPropertyItem(274).Value[0];
                switch (orientacion)
                {
                    case 1: break;
                    case 2: imagen.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
                    case 3: imagen.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                    case 4: imagen.RotateFlip(RotateFlipType.Rotate180FlipX); break;
                    case 5: imagen.RotateFlip(RotateFlipType.Rotate90FlipX); break;
                    case 6: imagen.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                    case 7: imagen.RotateFlip(RotateFlipType.Rotate270FlipX); break;
                    case 8: imagen.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                }
                imagen.RemovePropertyItem(274);
            }
            return imagen;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
