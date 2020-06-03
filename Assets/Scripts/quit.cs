using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of quit")]
    [TextArea(2, 5)]
    public string Description = "This script cleans up the screenshot folder on startup and starts the exit procedure";

    [Tooltip("The script that checks all the evidence and will start the PDF generator")]
    public ResearchChecker research;

    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo di = new DirectoryInfo("Screenshot");

        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitScene();
        }
    }

    public void QuitScene()
    {
        Debug.Log("quit game");
        research.GenerateEverything();
        SceneManager.LoadScene("Main menu");
    }
}
