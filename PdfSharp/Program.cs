using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var textFormater = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
                var font = new PdfSharp.Drawing.XFont("Arial", 14, PdfSharp.Drawing.XFontStyle.BoldItalic);

                // Acrescentando Textos.
                textFormater.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                textFormater.DrawString("Testando PdfSharp", font, PdfSharp.Drawing.XBrushes.Red, new PdfSharp.Drawing.XRect(0, 50, page.Width, page.Height));

                // Desenhando figuras geometricas.
                graphics.DrawLine(PdfSharp.Drawing.XPens.Blue, 150, 150, 200, 200);
                graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Green, PdfSharp.Drawing.XBrushes.LightBlue, 100, 300, 100, 50, 10, 10);

                // Inserindo uma imagen
                graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(@"C:\Users\DELL 3470\Google Drive\Mc Molas\Material Grafico - MC Molas\favicon-96x96.PNG"), 250, 300);

                //Gerando o arquivo PDF
                doc.Save("NovoPdf3.pdf");

                //Abrindo o arquivo gerado, com o leitor escolhio por default do sistema.
                System.Diagnostics.Process.Start("NovoPdf3.pdf");


            }
        }
    }
}
