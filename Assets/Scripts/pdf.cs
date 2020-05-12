using sharpPDF;
using sharpPDF.Enumerators;
using sharpPDF.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class pdf : MonoBehaviour
{
    string sceneName;
    string date;
    string docname;
    // Start is called before the first frame update
    void Start()
    {

        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        date = System.DateTime.Now.ToString("dd-MM-yyyy");
        docname = sceneName + "-" + date;
        pdfDocument pdfDocument = new pdfDocument(docname, "TI-2020");
        Titlepage(pdfDocument);
        InsertImage("", pdfDocument);
        pdfDocument.createPDF(@"" + docname + ".pdf");


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Titlepage(pdfDocument doc)
    {
        pdfPage TitlePage = doc.addPage();
        int titlelengt = sceneName.Length;
        int fontSize = 60;
        TitlePage.addText(sceneName, TitlePage.width / 2 - titlelengt * fontSize / 3, TitlePage.height - fontSize * 2, sharpPDF.Enumerators.predefinedFont.csHelveticaBold, fontSize);
        TitlePage.addText(date, TitlePage.width / 2 - date.Length * 12 / 3, TitlePage.height - fontSize * 2 - 40, sharpPDF.Enumerators.predefinedFont.csHelvetica, 12);
    }

    private void InsertImage(string imagePath, pdfDocument doc)
    {
        pdfPage page = doc.addPage(1080, 1920);
        byte[] vs = File.ReadAllBytes("Screenshot VPD - 1-26-35.jpg");
        int IWidht = page.width;
        int IHeight = IWidht * 9 / 16;
       
        page.addImage(vs, 0, 0, IHeight,IWidht);

    }

    private void InsertImage(string imagePath, pdfDocument doc, int pageWidth, int pageHeight)
    {
        pdfPage page = doc.addPage(pageHeight,pageWidth);
        byte[] vs = File.ReadAllBytes("Screenshot VPD - 1-26-35.jpg");
        int IWidht = page.width;
        int IHeight = IWidht * 9 / 16;

        page.addImage(vs,0, 0, IHeight, IWidht);

    }
}
