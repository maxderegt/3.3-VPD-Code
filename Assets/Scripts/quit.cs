using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class quit : MonoBehaviour
{
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
            Application.Quit();
        }
    }
}
