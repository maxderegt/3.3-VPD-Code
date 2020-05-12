using sharpPDF;
using sharpPDF.Enumerators;
using sharpPDF.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class pdf : MonoBehaviour
{
    public List<Results> results;
    string sceneName;
    string date;
    string docname;


    private string ScreenshotPath = "Screenshot";
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createPdf(List<Results> results)
    {
        this.results = results;
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        date = System.DateTime.Now.ToString("dd-MM-yyyy");
        docname = sceneName + "-" + date;
        pdfDocument pdfDocument = new pdfDocument(docname, "TI-2020");
        Titlepage(pdfDocument);
        addResults(pdfDocument);

        DirectoryInfo d = new DirectoryInfo(ScreenshotPath);
        foreach (var file in d.GetFiles())
        {
            InsertImage(ScreenshotPath + "/" + file.Name, pdfDocument);
        }
        if (!Directory.Exists("pdf"))
            Directory.CreateDirectory("pdf");
        pdfDocument.createPDF(@"pdf/" + docname + ".pdf");
    }

    private void Titlepage(pdfDocument doc)
    {
        pdfPage TitlePage = doc.addPage();
        int titlelengt = sceneName.Length;
        int fontSize = 60;
        TitlePage.addText(sceneName, TitlePage.width / 2 - titlelengt * fontSize / 3, TitlePage.height - fontSize * 2, predefinedFont.csHelveticaBold, fontSize);
        TitlePage.addText(date, TitlePage.width / 2 - date.Length * 12 / 3, TitlePage.height - fontSize * 2 - 40, predefinedFont.csHelvetica, 12);
    }

    private void InsertImage(string imagePath, pdfDocument doc)
    {
        pdfPage page = doc.addPage(1080, 1920);
        byte[] vs = File.ReadAllBytes(imagePath);
        int IWidht = page.width;
        int IHeight = IWidht * 9 / 16;

        page.addImage(vs, 0, 0, IHeight, IWidht);
        

    }

    private void InsertImage(string imagePath, pdfDocument doc, int pageWidth, int pageHeight)
    {
        pdfPage page = doc.addPage(pageHeight, pageWidth);
        byte[] vs = File.ReadAllBytes(imagePath);
        int IWidht = page.width;
        int IHeight = IWidht * 9 / 16;

        page.addImage(vs, 0, 0, IHeight, IWidht);
    }

    private void addResults(pdfDocument doc)
    {
        int fontsize = 30;
        pdfColor black = new pdfColor(predefinedColor.csBlack);
        pdfColor white = new pdfColor(predefinedColor.csWhite);
        pdfColor grey = new pdfColor(predefinedColor.csLightGray);
        
        foreach (Results result in results)
        {
            pdfPage page = doc.addPage();
            int height = page.height;

            height -= fontsize +20;
            page.addText(result.Name, 20, height, predefinedFont.csHelvetica, fontsize);

            pdfTable table = new pdfTable();
            table.borderSize = 1;
            table.borderColor = new pdfColor(predefinedColor.csBlack);
            table.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csHelveticaBold, fontsize, black, white);
            table.rowStyle = new pdfTableRowStyle(predefinedFont.csHelvetica, fontsize, black, white);
            table.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csHelvetica, fontsize, black, grey);

            table.tableHeader.addColumn(new pdfTableColumn("required steps", predefinedAlignment.csCenter, 200));
            table.tableHeader.addColumn(new pdfTableColumn("steps taken", predefinedAlignment.csCenter, 200));



            if (result.StepsRequired.Count >= result.StepsTaken.Count)
                for (int i = 0; i < result.StepsRequired.Count; i++)
                {
                    pdfTableRow row = table.createRow();
                    row[0].columnValue = result.StepsRequired[i];
                    try
                    {
                        row[1].columnValue = result.StepsTaken[i];
                    }
                    catch (System.Exception)
                    {
                        row[1].columnValue = "";
                    }

                    table.addRow(row);
                }
            else
                for (int i = 0; i < result.StepsTaken.Count; i++)
                {
                    pdfTableRow row = table.createRow();
                    try
                    {
                        row[0].columnValue = result.StepsRequired[i];
                    }
                    catch (System.Exception)
                    {
                        row[0].columnValue = "";
                    }

                    row[1].columnValue = result.StepsTaken[i];

                    table.addRow(row);
                }
            height -= 20;
            page.addTable(table, 20, height);
        }
    }
}
