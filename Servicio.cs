using System;

namespace Modelo
{
    public class Servicio
    {
        public long idServ { get; set; }
        public string TipoServicio { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Observacion { get; set; }

        public Servicio(string tipo, double precio, int cantidad, string unidad, string observacion)
        {
            TipoServicio = tipo;
            Precio = precio;
            Cantidad = cantidad;
            Unidad = unidad;
            Observacion = observacion;
        }
        public double CalcularCosto(int cantidad)
        {
            return cantidad * Precio;
        }

        public override string ToString()
        {
            return "Tipo: " + TipoServicio + Environment.NewLine +
                               "Precio: $" + Precio.ToString("0.00") + Environment.NewLine +
                               "Cantidad: " + Cantidad + " " + Unidad + Environment.NewLine +
                               "Observación: " + Observacion + Environment.NewLine +
                               "Costo Total: $" + CalcularCosto(Cantidad).ToString("0.00");
        }
    }
}
