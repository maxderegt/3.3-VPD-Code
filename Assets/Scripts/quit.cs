using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{

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
            Debug.Log("quit game");
            research.GenerateEverything();
            SceneManager.LoadScene("Main menu");
        }
    }
}
