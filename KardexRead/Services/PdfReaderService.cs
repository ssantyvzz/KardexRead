using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Text;

namespace KardexRead.Services
{
    public class PdfReaderService
    {
        public string ReadPdf(string filePath)
        {
            StringBuilder text = new StringBuilder();

            using (PdfReader pdfReader = new PdfReader(filePath))
            using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
            {
                int totalPages = pdfDocument.GetNumberOfPages();
                for (int page = 1; page <= totalPages; page++)
                {
                    // USAR LocationTextExtractionStrategy PARA MANTENER EL FORMATO DE TABLAS
                    ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                    string pageContent = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page), strategy);

                    text.AppendLine(pageContent);
                }
            }

            return NormalizeText(text.ToString());
        }

        // NORMALIZAR EL TEXTO PARA ELIMINAR ESPACIOS EXTRA Y CARACTERES INDESEADOS
        private string NormalizeText(string rawText)
        {
            return rawText
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Replace("\t", " ")
                .Replace("\u00A0", " ") 
                .Replace("  ", " ") 
                .Trim();
        }
    }
}