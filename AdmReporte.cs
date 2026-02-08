using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controlador
{
    public class AdmReporte
    {
        DatosReporte datosRep = new DatosReporte();
        public void CrearReporte(List<Servicio> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "ReporteServicios.pdf";
            sfd.Filter = "PDF Files|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    datosRep.GenerarReporteServicios(lista, sfd.FileName);
                    MessageBox.Show("Reporte generado exitosamente.");

                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message);
                }
            }
        }
    }
}
