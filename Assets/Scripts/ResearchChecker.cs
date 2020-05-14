using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchChecker : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of Research Checker")]
    [TextArea(2, 5)]
    public string Description = "This script wraps up the scene and checks all the Evidence to see what steps were taken and forgotten etc";

    [Tooltip("The script needed to generate the PDF")]
    public pdf pdf;

    [Tooltip("the script needed to take a picture of the player's movement")]
    public TakeRoomScreenshot roomScreenshot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            roomScreenshot.TakeScreenshot(true);
            pdf.createPdf(CheckAllResearch());
        }
    }

    public void GenerateEverything()
    {
        roomScreenshot.TakeScreenshot(true);
        pdf.createPdf(CheckAllResearch());
    }

    public List<Results> CheckAllResearch()
    {
        List<Results> results = new List<Results>();
        var gameobjects = Resources.FindObjectsOfTypeAll<ResearchManager>();
        foreach (ResearchManager item in gameobjects)
        {
            results.Add(new Results(item.transform.name, item.StepsRequired, item.StepsTaken));
        }
        return results;
    }
}
