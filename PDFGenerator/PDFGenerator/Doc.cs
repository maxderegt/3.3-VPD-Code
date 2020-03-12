using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Kernel.Geom;

namespace PDFGenerator
{
    class Doc
    {
        Document document;
        Paragraph p = new Paragraph();
        public Doc(string destination)
        {
            FileInfo file = new FileInfo(destination);
            file.Directory.Create();

            PdfWriter writer = new PdfWriter(destination);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
           document = new Document(pdf,PageSize.A4);
        }
        
        public void addStringList(List<string> array)
        {
            List list = new List().SetSymbolIndent(10).SetListSymbol("\u2022");
            foreach (string s in array)
            {
                list.Add(s);
            }

            p.Add(list);
        }

        public void addPicture(string imgFile)
        {
            Image img = new Image(ImageDataFactory.Create(imgFile));
            img.SetWidth(document.GetPageEffectiveArea(PageSize.A4).GetWidth());
            p.Add(img);
        }

        public void close()
        {
            document.Add(p);
            document.Close();
        }
    }
}
