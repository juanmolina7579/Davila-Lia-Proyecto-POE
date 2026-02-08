using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class AdmAutor
    {
        Conexion cn = new Conexion();
        DatosAutor datAutor = new DatosAutor();
        public List<Autor> ObtenerDatosAutor()
        {
            List<Autor> lista = new List<Autor>();
            string msj = cn.Conectar();

            if (msj[0] == '1')
            {
                lista = datAutor.ConsultarAutor(cn.Cn);
                cn.Cerrar();
            }
            return lista;
        }
    }
}