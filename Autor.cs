using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Autor
    {
        public string Etiqueta { get; set; }
        public string Valor { get; set; }
        public string TipoControl { get; set; }
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public byte[] Foto { get; set; }
        public Autor() { }
        public Autor(string etiqueta, string valor, string tipoControl, int x, int y, int w, int h, byte[] foto)
        {
            Etiqueta = etiqueta;
            Valor = valor;
            TipoControl = tipoControl;
            PosicionX = x;
            PosicionY = y;
            Ancho = w;
            Alto = h;
            Foto = foto;
        }
    }
}
