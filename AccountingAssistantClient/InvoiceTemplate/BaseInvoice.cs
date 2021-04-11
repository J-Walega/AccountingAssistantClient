using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace AccountingAssistantClient.InvoiceTemplate
{
    public class BaseInvoice
    {
        BaseInvoice()
        {
            CreateTestPdf();
        }

        private void CreateTestPdf()
        {
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("/myfiles/hello.pdf", FileMode.Create, FileAccess.Write)));
            Document document = new Document(pdfDocument);

            String line = "Hello! Welcome to iTextPdf";
            document.Add(new Paragraph(line));
            document.Close();
        }
    }
}
