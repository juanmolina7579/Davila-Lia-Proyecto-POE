using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosAutor
    {
        SqlCommand cmd = null;

        public List<Autor> ConsultarAutor(SqlConnection cn)
        {
            List<Autor> lista = new List<Autor>();
            string consulta = "SELECT Etiqueta, Valor, TipoControl, PosicionX, PosicionY, Ancho, Alto, Foto FROM Autor ORDER BY Orden";

            cmd = new SqlCommand(consulta, cn);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Autor a = new Autor();
                    a.Etiqueta = dr["Etiqueta"].ToString();
                    a.Valor = dr["Valor"].ToString();
                    a.TipoControl = dr["TipoControl"].ToString();
                    a.PosicionX = Convert.ToInt32(dr["PosicionX"]);
                    a.PosicionY = Convert.ToInt32(dr["PosicionY"]);
                    a.Ancho = Convert.ToInt32(dr["Ancho"]);
                    a.Alto = Convert.ToInt32(dr["Alto"]);

                    if (dr["Foto"] != DBNull.Value)
                        a.Foto = (byte[])dr["Foto"];
                    else
                        a.Foto = null;

                    lista.Add(a);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar autor: " + ex.Message);
            }
            return lista;
        }
    }
}