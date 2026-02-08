using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Modelo;

namespace Controlador
{
    public class AdmServicio
    {
        string[] tiposServicio = { "Spa", "Cine", "Piscina", "Limpieza", "Desayuno" };
        string[] unidades = { "Personas", "Boletos", "Servicio a la habitacion", "Platos" };
        static List<Servicio> lista = new List<Servicio>();
        Servicio servicio = null;
        Conexion Cn=null;
        DatosServicio datosServ = null;
        public void CargarServicios()
        {
            ConsultarServiciosBDD();
        }
        public int GetCantidadLista() 
        { 
            return lista.Count; 
        }
        public void ConsultarServiciosBDD()
        {
            Cn = new Conexion();
            datosServ = new DatosServicio();
            List<Servicio> tmp = null;
            string msj = Cn.Conectar();
            if (msj[0] == '1')
            {
                tmp= datosServ.ConsultarServicios(Cn.Cn);
                lista.Clear();
                if(tmp != null && tmp.Count > 0)
                {
                    lista.AddRange(tmp);
                }
                else
                {
                    MessageBox.Show("No hay servicios registrados en la base de datos.");
                }
                Cn.Cerrar();
            }
            else if (msj[0] == '0')
            {
                MessageBox.Show(msj);
            }
        }
        public void LlenarComboTipo(ComboBox cmbTipo)
        {
            cmbTipo.Items.Clear();
            foreach (string s in tiposServicio)
            {
                cmbTipo.Items.Add(s);
            }
        }
        public void LlenarComboUnidad(ComboBox cmbUni)
        {
            cmbUni.Items.Clear();
            foreach(string u in unidades)
            {
                cmbUni.Items.Add(u);
            }
        }
        public void LlenarTabla(DataGridView dgvServicios)
        {
            int indice = 0;
            dgvServicios.Rows.Clear();
            if (lista.Count > 0)
            {
                foreach (Servicio s in lista)
                {
                    indice = dgvServicios.Rows.Add();
                    dgvServicios.Rows[indice].Cells["colNro"].Value = indice+1;
                    dgvServicios.Rows[indice].Cells["colTipo"].Value = s.TipoServicio;
                    dgvServicios.Rows[indice].Cells["colPrecio"].Value = s.Precio.ToString("0.00");
                    dgvServicios.Rows[indice].Cells["colCantidad"].Value = s.Cantidad;
                    dgvServicios.Rows[indice].Cells["colUnidad"].Value = s.Unidad;
                    dgvServicios.Rows[indice].Cells["colObsv"].Value = s.Observacion;
                    dgvServicios.Rows[indice].Cells["colTotal"].Value = s.CalcularCosto(s.Cantidad).ToString("0.00");
                }
            }
        }
        public bool EsVacio(string tipo, string precioTexto, string unidad)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(tipo) || 
                string.IsNullOrWhiteSpace(precioTexto) || 
                string.IsNullOrEmpty(unidad))
            {
                flag = true;
                MessageBox.Show("Error: Se necesitan todos los campos llenos");
            }
            return flag;
        }

        public void FiltrarXPrecio(double precioMin, double precioMax, DataGridView dgvServicios)
        {
            int indice = 0;
            dgvServicios.Rows.Clear();
            if (lista.Count > 0)
            {
                foreach (Servicio s in lista)
                {
                    if (s.Precio >= precioMin && s.Precio <= precioMax)
                    {
                        indice = dgvServicios.Rows.Add();
                        dgvServicios.Rows[indice].Cells["colNro"].Value = indice + 1;
                        dgvServicios.Rows[indice].Cells["colTipo"].Value = s.TipoServicio;
                        dgvServicios.Rows[indice].Cells["colPrecio"].Value = s.Precio.ToString("0.00");
                        dgvServicios.Rows[indice].Cells["colCantidad"].Value = s.Cantidad;
                        dgvServicios.Rows[indice].Cells["colUnidad"].Value = s.Unidad;
                        dgvServicios.Rows[indice].Cells["colObsv"].Value = s.Observacion;
                        dgvServicios.Rows[indice].Cells["colTotal"].Value = s.CalcularCosto(s.Cantidad).ToString("0.00");
                    }
                }
            }
        }

        public void FiltrarXCantidad(int cantidadMin, int cantidadMax, DataGridView dgvServicios)
        {
            int indice = 0;
            dgvServicios.Rows.Clear();
            if (lista.Count > 0)
            {
                foreach (Servicio s in lista)
                {
                    if (s.Cantidad >= cantidadMin && s.Cantidad <= cantidadMax)
                    {
                        indice = dgvServicios.Rows.Add();
                        dgvServicios.Rows[indice].Cells["colNro"].Value = indice + 1;
                        dgvServicios.Rows[indice].Cells["colTipo"].Value = s.TipoServicio;
                        dgvServicios.Rows[indice].Cells["colPrecio"].Value = s.Precio.ToString("0.00");
                        dgvServicios.Rows[indice].Cells["colCantidad"].Value = s.Cantidad;
                        dgvServicios.Rows[indice].Cells["colUnidad"].Value = s.Unidad;
                        dgvServicios.Rows[indice].Cells["colObsv"].Value = s.Observacion;
                        dgvServicios.Rows[indice].Cells["colTotal"].Value = s.CalcularCosto(s.Cantidad).ToString("0.00");
                    }
                }
            }
        }

        public string Registrar(string tipo, double precio, int cantidad, string unidad, string observacion)
        {
            servicio = new Servicio(tipo, precio, cantidad, unidad, observacion);
            lista.Add(servicio);
            RegistrarServicioBDD(servicio);
            return servicio.ToString();
        }
        private void RegistrarServicioBDD(Servicio servicio)
        {
            Cn = new Conexion();
            datosServ = new DatosServicio();
            string msj = Cn.Conectar();
            string resp = "";
            if (msj[0] == '1')
            {
                resp = datosServ.RegistrarServicio(servicio, Cn.Cn);
                if (resp[0] == '1')
                {
                    MessageBox.Show("Datos de servicios guardados en BDD");
                }
                else if (resp[0] == '0')
                {
                    MessageBox.Show(resp);
                }
                Cn.Cerrar();
            }
            else if (msj[0] == '0')
            {
                MessageBox.Show(msj);
            }
        }
        public void EliminarServicio(string tipoB )
        {
            int posicionServ = lista.FindIndex(x => x.TipoServicio == tipoB);
            long idServ = lista[posicionServ].idServ;
            lista.RemoveAll(s => s.TipoServicio == tipoB);
            EliminarServicioBDD(idServ, tipoB);
        }
        private void EliminarServicioBDD(long idServ, string tipoB)
        {
            Cn = new Conexion();
            datosServ = new DatosServicio();
            string msj = Cn.Conectar();
            string resp = "";
            if (msj[0] == '1')
            {
                resp = datosServ.EliminarServicio(idServ, Cn.Cn);
                if (resp[0] == '1')
                {
                    MessageBox.Show("Servicio " + tipoB + " eliminado en BDD");
                }
                else if (resp[0] == '0')
                {
                    MessageBox.Show(resp);
                }
                Cn.Cerrar();
            }
            else if (msj[0] == '0')
            {
                MessageBox.Show(msj);
            }
        }
        public void BuscarServicioXTipo(string tipo, DataGridView dgvServicios)
        {
            Servicio s = lista.Find(x => x.TipoServicio == tipo);
            int i = 0;
            if(s != null)
            {
                i=lista.IndexOf(s);
                dgvServicios.Rows.Clear();
                int indice = dgvServicios.Rows.Add();
                dgvServicios.Rows[indice].Cells["colNro"].Value = i + 1;
                dgvServicios.Rows[indice].Cells["colTipo"].Value = s.TipoServicio;
                dgvServicios.Rows[indice].Cells["colPrecio"].Value = s.Precio.ToString("0.00");
                dgvServicios.Rows[indice].Cells["colCantidad"].Value = s.Cantidad;
                dgvServicios.Rows[indice].Cells["colUnidad"].Value = s.Unidad;
                dgvServicios.Rows[indice].Cells["colObsv"].Value = s.Observacion;
                dgvServicios.Rows[indice].Cells["colTotal"].Value = s.CalcularCosto(s.Cantidad).ToString("0.00");
            }
            else
            {
                MessageBox.Show("Servicio no encontrado: " + tipo);
            }

        }
        public void Conectar()
        {
            Cn = new Conexion();
            string res = Cn.Conectar();
            if (res[0] == '1')
            {
                MessageBox.Show("Conexión exitosa a la base de datos.");
                Cn.Cerrar();
            }
            else if (res[0] == '0')
            {
                MessageBox.Show(res);
            }
        }
        public List<Servicio> GetListaServicios()
        {
            if (lista.Count == 0)
            {
                ConsultarServiciosBDD();
            }
            return lista;
        }

        public void EditarServicio(string tipo, double precio, int cantidad, string unidad, string observacion)
        {
            int posicionServ = lista.FindIndex(x => x.TipoServicio == tipo);
            if (posicionServ != -1)
            {
                long idServ = lista[posicionServ].idServ;
                lista[posicionServ].Precio = precio;
                lista[posicionServ].Cantidad = cantidad;
                lista[posicionServ].Unidad = unidad;
                lista[posicionServ].Observacion = observacion;
                EditarServicioBDD(idServ, tipo, precio, cantidad, unidad, observacion);
            }
            else
            {
                MessageBox.Show("Servicio no encontrado: " + tipo);
            }
        }
        public void EditarServicioBDD(long idServ, string tipo, double precio, int cantidad, string unidad, string observacion)
        {
            Cn = new Conexion();
            datosServ = new DatosServicio();
            string msj = Cn.Conectar();
            string resp = "";
            if (msj[0] == '1')
            {
                resp = datosServ.EditarServicio(new Servicio(tipo, precio, cantidad, unidad, observacion) { idServ = idServ }, Cn.Cn);
                if (resp[0] == '1')
                {
                    MessageBox.Show("Datos de servicio " + tipo + " modificados en BDD");
                }
                else if (resp[0] == '0')
                {
                    MessageBox.Show(resp);
                }
                Cn.Cerrar();
            }
            else if (msj[0] == '0')
            {
                MessageBox.Show(msj);
            }

        }
    }
}
