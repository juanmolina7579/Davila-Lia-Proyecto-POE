using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["MiConexionAlejandra"].ConnectionString;
        public SqlConnection Cn { get; set; }
        public string Conectar()
        {
            try
            {
                Cn = new SqlConnection();
                Cn.ConnectionString = cadena;
                Cn.Open();
                return "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "0" + ex.Message;
            }
        }
        public string Cerrar()
        {
            try
            {
                Cn.Close();
                return "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "0" + ex.Message;
            }
        }
    }
}
