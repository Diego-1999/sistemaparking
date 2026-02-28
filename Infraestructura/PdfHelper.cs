using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SistemaParking.Entidad;


namespace Infraestructura
{
    public class PdfHelper
    {
        public static void GenerarTiqueteEntradaPDF(ETiqueteEntrada tiquete, string rutaArchivo)
        {
            // Definir tamaño de página: 80mm de ancho x 200mm de alto
            float ancho = Utilities.MillimetersToPoints(80);
            float alto = Utilities.MillimetersToPoints(200);
            Rectangle pageSize = new Rectangle(ancho, alto);

            using (Document doc = new Document(pageSize, 5, 5, 5, 5))
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // Fuentes
                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fuentePequena = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                // Encabezado
                Paragraph titulo = new Paragraph("PARQUEO PLAZA DON PEDRO", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                doc.Add(new Paragraph("HORARIO", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Lunes a Viernes de 7:00 a 4:30", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Tel: 2234-5628", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("San Jose, Zapote, Frente al Registro Público, específicamente frente al edificio donde se entregan las placas.", fuentePequena) { Alignment = Element.ALIGN_CENTER });

                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("**TIQUETE DE ENTRADA**", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));

                // Datos del tiquete (usando la entidad TiqueteEntrada)
                doc.Add(new Paragraph($"Tiquete: {tiquete.Tiquete}", fuenteNormal));
                doc.Add(new Paragraph($"Placa: {tiquete.PlacaVehiculo}", fuenteNormal));
                doc.Add(new Paragraph($"Codigo: {tiquete.Codigo}", fuenteNormal));
             

                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));

                if (tiquete.tipovehiculo == "Particular" || tiquete.tipovehiculo == "Carga Liviana" || tiquete.tipovehiculo == "Placa Temporal")
                {
                    doc.Add(new Paragraph($"Tarifa -- ¢1000 {tiquete.tipovehiculo}", fuenteNormal));
                    doc.Add(new Paragraph($"Fecha: {tiquete.FechaEmision:dd/MM/yyyy}", fuenteNormal));
                    doc.Add(new Paragraph($"Hora Entrada: {tiquete.FechaEmision:HH:mm:ss}", fuenteNormal));
                }
                else
                {
                    doc.Add(new Paragraph($"Tarifa -- ¢700 {tiquete.tipovehiculo}", fuenteNormal));
                    doc.Add(new Paragraph($"Fecha: {tiquete.FechaEmision:dd/MM/yyyy}", fuenteNormal));
                    doc.Add(new Paragraph($"Hora Entrada: {tiquete.FechaEmision:HH:mm:ss}", fuenteNormal));
                }


                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));

                // Mensaje
                Paragraph mensaje = new Paragraph("Conserve este tiquete para el retiro de su vehículo.", fuentePequena);
                mensaje.Alignment = Element.ALIGN_CENTER;
                doc.Add(mensaje);

                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));

                // Pie de página
                Paragraph pie = new Paragraph("¡Gracias por su visita!", fuenteNormal);
                pie.Alignment = Element.ALIGN_CENTER;
                doc.Add(pie);

                doc.Close();
            }
        }

        public static void GenerarTiqueteSalidaPDF(ETiqueteSalida tiquetesalida, string rutaArchivo)
        {
            // Definir tamaño de página: 80mm de ancho x 200mm de alto
            float ancho = Utilities.MillimetersToPoints(80);
            float alto = Utilities.MillimetersToPoints(200);
            Rectangle pageSize = new Rectangle(ancho, alto);

            using (Document doc = new Document(pageSize, 5, 5, 5, 5))
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // Fuentes
                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fuentePequena = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                // Encabezado
                Paragraph titulo = new Paragraph("PARQUEO PLAZA DON PEDRO", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                doc.Add(new Paragraph("HORARIO", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Lunes a Viernes de 7:00 a 4:30", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Tel: 2234-5628", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("San Jose, Zapote, Frente al Registro Público, específicamente frente al edificio donde se entregan las placas.", fuentePequena) { Alignment = Element.ALIGN_CENTER });

                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("**TIQUETE DE SALIDA**", fuentePequena) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));

                // Datos del tiquete (usando la entidad TiqueteEntrada)
                doc.Add(new Paragraph($"Tiquete: {tiquetesalida.Tiquete}", fuenteNormal));
                doc.Add(new Paragraph($"Código: {tiquetesalida.Codigo}", fuenteNormal));
                doc.Add(new Paragraph($"Placa: {tiquetesalida.PlacaVehiculo}", fuenteNormal));

                if (tiquetesalida.MontoCobrado < 1000m)
                {
                    doc.Add(new Paragraph($"Fecha Salida: {tiquetesalida:dd/MM/yyyy}", fuenteNormal));
                    doc.Add(new Paragraph($"Hora Salida: {tiquetesalida.FechaSalida:HH:mm:ss}", fuenteNormal));
                    doc.Add(new Paragraph($"Tarifa Motocicleta --: ¢{tiquetesalida.MontoCobrado}", fuenteNormal));
                }
                else
                {
                    doc.Add(new Paragraph($"Fecha Salida: {tiquetesalida:dd/MM/yyyy}", fuenteNormal));
                    doc.Add(new Paragraph($"Hora Salida: {tiquetesalida.FechaSalida:HH:mm:ss}", fuenteNormal));
                    doc.Add(new Paragraph($"Tarifa Liviano --: ¢{tiquetesalida.MontoCobrado}", fuenteNormal));
                }


                // Pie de página
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("---------------------------------------------------------------------------------", fuentePequena));
                doc.Add(new Paragraph("¡Gracias por su visita!", fuenteNormal) { Alignment = Element.ALIGN_CENTER });

                doc.Close();

            }
        }
    }
}