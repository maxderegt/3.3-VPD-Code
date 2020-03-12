using System;
using System.Collections.Generic;

namespace PDFGenerator
{
    class Program
    {
        //hij staat bij de .sln file
        public const String DEST = "../../../../generatedPDF.pdf";

        public static void Main(String[] args)
        {
            List<string> list = new List<string>() {"actie1", "actie2","actie3", "actie4", "actie5"};

            //edit this path for the test image
            string imgPath = "C:\\Users\\berni\\Downloads\\virtueel PD.jpg";

            Doc doc = new Doc(DEST);
            doc.addStringList(list);
            doc.addPicture(imgPath);
            doc.close();
        }
    }
}
