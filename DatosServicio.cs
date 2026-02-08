using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Datos
{
    public class DatosServicio
    {
        SqlCommand cmd = null;

        public List<Servicio> ConsultarServicios(SqlConnection cn)
        {
            List<Servicio> lista = new List<Servicio>();
            Servicio servicio = null;
            string comando = "SELECT * FROM servicio WHERE estado = 'A'";
            cmd = new SqlCommand();
            SqlDataReader tablaVirtual = null;
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = comando;
                tablaVirtual = cmd.ExecuteReader();
                while (tablaVirtual.Read())
                {
                    servicio = new Servicio("", 0, 0, "", "");
                    servicio.idServ = Convert.ToInt64(tablaVirtual["idServ"]);
                    servicio.TipoServicio = tablaVirtual["TipoServicio"].ToString();
                    servicio.Precio = Convert.ToDouble(tablaVirtual["Precio"]);
                    servicio.Cantidad = Convert.ToInt32(tablaVirtual["Cantidad"]);
                    servicio.Unidad = tablaVirtual["Unidad"].ToString();
                    servicio.Observacion = tablaVirtual["Observacion"].ToString();
                    lista.Add(servicio);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lista;
        }

        public string EditarServicio(Servicio servicio, SqlConnection cn)
        {
            string msj = "";
            string comando = "UPDATE Servicio SET tipoServicio=@Tipo, precio=@Precio, cantidad=@Cant, unidad=@Uni, observacion=@Obs, total=@Total WHERE idServ=@IdServ";
            cmd = new SqlCommand(comando, cn);
            cmd.Parameters.AddWithValue("@IdServ", servicio.idServ);
            cmd.Parameters.AddWithValue("@Tipo", servicio.TipoServicio);
            cmd.Parameters.AddWithValue("@Precio", servicio.Precio);
            cmd.Parameters.AddWithValue("@Cant", servicio.Cantidad);
            cmd.Parameters.AddWithValue("@Uni", servicio.Unidad);
            cmd.Parameters.AddWithValue("@Obs", servicio.Observacion ?? "");
            cmd.Parameters.AddWithValue("@Total", servicio.CalcularCosto(servicio.Cantidad));
            try
            {
                cmd.ExecuteNonQuery();
                msj = "1";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                msj = "0" + ex.Message;

            }
            return msj;

        }
        public string EliminarServicio(long idServ, SqlConnection cn)
        {
            string msj = "";
            string comando = "UPDATE Servicio SET estado=@Estado WHERE idServ=@IdServ";

            cmd = new SqlCommand(comando, cn);
            cmd.Parameters.AddWithValue("@IdServ", idServ);
            cmd.Parameters.AddWithValue("@Estado", 'I');

            try
            {
                cmd.ExecuteNonQuery();
                msj = "1";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                msj = "0" + ex.Message;
            }
            return msj;
        }

        public string RegistrarServicio(Servicio servicio, SqlConnection cn)
        {
            string msj = "";
            string comando = "INSERT INTO Servicio(tipoServicio, precio, cantidad, unidad, observacion, total, estado) " +
                                 "VALUES(@Tipo, @Precio, @Cant, @Uni, @Obs, @Total, @Estado)";

                cmd = new SqlCommand(comando, cn);
                cmd.Parameters.AddWithValue("@Tipo", servicio.TipoServicio);
                cmd.Parameters.AddWithValue("@Precio", servicio.Precio);
                cmd.Parameters.AddWithValue("@Cant", servicio.Cantidad);
                cmd.Parameters.AddWithValue("@Uni", servicio.Unidad);
                cmd.Parameters.AddWithValue("@Obs", servicio.Observacion ?? "");
                cmd.Parameters.AddWithValue("@Total", servicio.CalcularCosto(servicio.Cantidad));
                cmd.Parameters.AddWithValue("@Estado", 'A');

            try { 
                cmd.ExecuteNonQuery();
                msj = "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                msj = "0" + ex.Message;
            }
            return msj;
        }
    }
}
