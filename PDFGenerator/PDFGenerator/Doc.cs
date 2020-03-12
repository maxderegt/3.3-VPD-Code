using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;

namespace PDFGenerator
{
    class Doc
    {
        Document document;
        public Doc(string destination)
        {
            FileInfo file = new FileInfo(destination);
            file.Directory.Create();

            PdfWriter writer = new PdfWriter(destination);
            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);
            // Initialize document
           document = new Document(pdf);
        }

        public void addStringList(List<string> array)
        {
            List list = new List().SetSymbolIndent(10).SetListSymbol("\u2022");
            foreach (string s in array)
            {
                list.Add(s);
            }

            document.Add(list);
        }

        public void addPicture(string imgFile)
        {
            Image img = new Image(ImageDataFactory.Create(imgFile));
            document.Add(img);
        }

        public void close()
        {
            document.Close();
        }
    }
}
