using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class DatosReporte
    {
        public void GenerarReporteServicios(List<Servicio> listaServicios, string rutaDestino)
        {
            Document documento = new Document(PageSize.A4);
            try
            {
                PdfWriter.GetInstance(documento, new FileStream(rutaDestino, FileMode.Create));
                documento.Open();
                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Paragraph titulo = new Paragraph("Reporte de Servicios", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);
                documento.Add(new Paragraph(" "));
                PdfPTable tabla = new PdfPTable(5);
                tabla.WidthPercentage = 100;
                tabla.AddCell(new PdfPCell(new Phrase("Tipo Servicio", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                tabla.AddCell(new PdfPCell(new Phrase("Precio", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                tabla.AddCell(new PdfPCell(new Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                tabla.AddCell(new PdfPCell(new Phrase("Unidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                tabla.AddCell(new PdfPCell(new Phrase("Observación", FontFactory.GetFont(FontFactory.HELVETICA_BOLD))));
                foreach (Servicio serv in listaServicios)
                {
                    tabla.AddCell(serv.TipoServicio);
                    tabla.AddCell(serv.Precio.ToString("C"));
                    tabla.AddCell(serv.Cantidad.ToString());
                    tabla.AddCell(serv.Unidad);
                    tabla.AddCell(serv.Observacion);
                }

                documento.Add(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (documento.IsOpen())
                {
                    documento.Close();
                }
            }
        }
    }
}
