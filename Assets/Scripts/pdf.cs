using sharpPDF;
using sharpPDF.Enumerators;
using sharpPDF.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class pdf : MonoBehaviour
{
    [Header("dont remove")]
    [TextArea]
    public string description = "this script contains the logic for the creation of a pdf using foto's taken by the player and a list of results";

    [Tooltip("the results to be displayed in the pdf")]
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


    /// <summary>
    /// creates a pdf using:
    ///     #the given results
    ///     #name of active scene
    ///     #images from Screenshot folder
    /// </summary>
    /// <param name="results"> the results to be displayed in the pdf </param>
    public void createPdf(List<Results> results)
    {
        //get name of scene and current date
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        date = System.DateTime.Now.ToString("dd-MM-yyyy_hh.mm");
        docname = sceneName + "-" + date;

        //create document
        pdfDocument pdfDocument = new pdfDocument(docname, "TI-2020");

        //make the first page
        Titlepage(pdfDocument);

        //add the results from the results, 1 page per result
        addResults(results, pdfDocument);

        //add foto's to the document, 1 foto per page
        //get the image files
        DirectoryInfo d = new DirectoryInfo(ScreenshotPath);
        FileInfo[] files = d.GetFiles();

        //sort image files by date
        System.Array.Sort(files, (f1, f2) => f1.CreationTime.CompareTo(f2.CreationTime));

        foreach (var file in files)
        {
            //create new page and add image
            InsertImage(ScreenshotPath + "/" + file.Name, pdfDocument);
        }
        //save the pdf in folder
        if (!Directory.Exists("pdf"))
            Directory.CreateDirectory("pdf");
        pdfDocument.createPDF(@"pdf/" + docname + ".pdf");
    }

    /// <summary>
    ///titlepage with info such as scene name and current date
    /// </summary>
    /// <param name="doc"> the document to which to add the page</param>
    private void Titlepage(pdfDocument doc)
    {
        //create and add page to document
        pdfPage TitlePage = doc.addPage();
        int titlelengt = sceneName.Length;
        int fontSize = 60;
        //add text to middlle document 
        TitlePage.addText(sceneName, TitlePage.width / 2 - titlelengt * fontSize / 3, TitlePage.height - fontSize * 2, predefinedFont.csHelveticaBold, fontSize);
        TitlePage.addText(date, TitlePage.width / 2 - date.Length * 12 / 3, TitlePage.height - fontSize * 2 - 40, predefinedFont.csHelvetica, 12);
    }

    /// <summary>
    /// add create page and add image to page
    /// </summary>
    /// <param name="imagePath"> path to where the image is located </param>
    /// <param name="doc"> the document to add a page to </param>
    private void InsertImage(string imagePath, pdfDocument doc)
    {
        //create page with size of 1080 by 1920 and add to document
        pdfPage page = doc.addPage(1080, 1920);

        //read image file as byte array
        byte[] vs = File.ReadAllBytes(imagePath);

        //calc image height using page size and 16:9 aspect ratio
        int IWidht = page.width;
        int IHeight = IWidht * 9 / 16;

        //add image to page anchor point 0,0 with height and with
        page.addImage(vs, 0, 0, IHeight, IWidht);


    }

    /// <summary>
    /// add create page with special height and width and add image to page
    /// </summary>
    /// <param name="imagePath"> path to where the image is located </param>
    /// <param name="doc"> the document to add a page to </param>
    /// <param name="pageWidth"> the widht of the created page </param>
    /// <param name="pageHeight"> the height of the created page </param>
    private void InsertImage(string imagePath, pdfDocument doc, int pageWidth, int pageHeight)
    {
        //create and add page to document
        pdfPage page = doc.addPage(pageHeight, pageWidth);

        //read image file as byte array
        byte[] vs = File.ReadAllBytes(imagePath);

        //calc image height using page size and 16:9 aspect ratio
        int IWidht = page.width;
        int IHeight = IWidht * 9 / 16;

        //add image to page. position 0,0 with height and with 
        page.addImage(vs, 0, 0, IHeight, IWidht);
    }

    /// <summary>
    /// create page and add result to page for each result
    /// </summary>
    /// <param name="results"> the results to be added to the document</param>
    /// <param name="doc"> the document to be edited </param>
    private void addResults(List<Results> results, pdfDocument doc)
    {
        int fontsize = 12;
        pdfColor black = new pdfColor(predefinedColor.csBlack);
        pdfColor white = new pdfColor(predefinedColor.csWhite);
        pdfColor grey = new pdfColor(predefinedColor.csLightGray);

        foreach (Results result in results)
        {
            //create and add page to document
            pdfPage page = doc.addPage();

            //height variable to keep track of where to place next element
            int height = page.height;

            //calc new height
            height -= fontsize + 20;

            //add result name with x:20 y: height
            page.addText(result.Name, 20, height, predefinedFont.csHelveticaBold, fontsize);

            height -= fontsize + 20;

            string s;

            if (result.StepsRequired.Count != 0)
            {
                s = result.AllRequiredSteps ? "ja" : "nee";
            }else
            {
                s = "is geen bewijsstuk";
            }
            //add if all requred stepps are taken
            page.addText("alle benodigede stappen uitgevoerd: " + s, 20, height, predefinedFont.csHelvetica, fontsize);

            //creating table of required and taken steps
            pdfTable table = new pdfTable();

            //defineing table style
            table.borderSize = 1;
            table.borderColor = new pdfColor(predefinedColor.csBlack);
            table.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csHelveticaBold, fontsize, black, white);
            table.rowStyle = new pdfTableRowStyle(predefinedFont.csHelvetica, fontsize, black, white);
            table.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csHelvetica, fontsize, black, grey);

            // tableColomns use whole page widht
            int tableColomnSize = (page.width - 40) / 2;

            //add colomns to table
            table.tableHeader.addColumn(new pdfTableColumn("required steps", predefinedAlignment.csCenter, tableColomnSize));
            table.tableHeader.addColumn(new pdfTableColumn("steps taken", predefinedAlignment.csCenter, tableColomnSize));

            //check which table is larger steps taken or steps required
            if (result.StepsRequired.Count >= result.StepsTaken.Count)
                for (int i = 0; i < result.StepsRequired.Count; i++)
                {
                    //create new row 
                    pdfTableRow row = table.createRow();
                    //add value to first cell of row
                    row[0].columnValue = result.StepsRequired[i];
                    try
                    {
                        // try to add value to second cell 
                        row[1].columnValue = result.StepsTaken[i];
                    }
                    catch (System.Exception)
                    {
                        // on a indexOutOfBounds add empty
                        row[1].columnValue = "";
                    }
                    //add row to table
                    table.addRow(row);
                }
            else
                for (int i = 0; i < result.StepsTaken.Count; i++)
                {
                    //create table row
                    pdfTableRow row = table.createRow();
                    try
                    {
                        // try to add value to second cell 
                        row[0].columnValue = result.StepsRequired[i];
                    }
                    catch (System.Exception)
                    {
                        // on a indexOutOfBounds add empty
                        row[0].columnValue = "";
                    }

                    row[1].columnValue = result.StepsTaken[i];
                    //add table row
                    table.addRow(row);
                }
            //calc new height
            height -= 20;
            //add table to page
            page.addTable(table, 20, height);
        }
    }
}
