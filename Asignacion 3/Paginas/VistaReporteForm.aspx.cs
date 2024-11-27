using Asignacion_3.Clases;
using iText.Kernel.Pdf;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableIText = iText.Layout.Element.Table;

namespace Asignacion_3.Paginas
{
    public partial class VistaReporteForm : System.Web.UI.Page
    {
        public Persona persona = new Persona();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = new List<Persona>
                {
                    new Persona { ID = 1, Nombre = "Karla Brenes", Edad = 20 },
                    new Persona { ID = 2, Nombre = "Joshua Andrey", Edad = 30 },
                    new Persona { ID = 3, Nombre = "Johel Perez", Edad = 50 }
                };

                gvData.DataSource = data;
                gvData.DataBind();
            }
        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            var data = new List<Persona>
            {
                new Persona { ID = 1, Nombre = "Karla Brenes", Edad = 20 },
                new Persona { ID = 2, Nombre = "Joshua Andrey", Edad = 30 },
                new Persona { ID = 3, Nombre = "Johel Perez", Edad = 50 }
            };

            var listaOrdenada = data.OrderBy(a => a.ID).ToList();

            string filePath = Server.MapPath("~/Reportes/Reporte.pdf");

            using (var escribir = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(escribir))
                {
                    var documento = new Document(pdf);

                    //título
                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    var titulo = new Paragraph("Reporte de Personas")
                        .SetFont(font)
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontColor(ColorConstants.WHITE)
                        .SetBackgroundColor(new DeviceRgb(26, 115, 232))
                        .SetPadding(10);

                    documento.Add(titulo);

                    
                    TableIText table = new TableIText(3).UseAllAvailableWidth(); 

                    //encabezados
                    PdfFont headerFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    table.AddHeaderCell(new Cell().Add(new Paragraph("ID").SetFont(headerFont).SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(new DeviceRgb(0, 121, 107))); 
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre").SetFont(headerFont).SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(new DeviceRgb(0, 121, 107))); 
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Edad").SetFont(headerFont).SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(new DeviceRgb(0, 121, 107))); 

                    // Agregar filas de datoS
                    foreach (var persona in listaOrdenada)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(persona.ID.ToString()).SetFontColor(new DeviceRgb(51, 51, 51))).SetBackgroundColor(new DeviceRgb(241, 241, 241)));
                        table.AddCell(new Cell().Add(new Paragraph(persona.Nombre).SetFontColor(new DeviceRgb(51, 51, 51))).SetBackgroundColor(new DeviceRgb(241, 241, 241))); 
                        table.AddCell(new Cell().Add(new Paragraph(persona.Edad.ToString()).SetFontColor(new DeviceRgb(51, 51, 51))).SetBackgroundColor(new DeviceRgb(241, 241, 241))); 
                    }

                    documento.Add(table);
                }
            }

            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}
