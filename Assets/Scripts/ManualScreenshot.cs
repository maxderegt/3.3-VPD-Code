using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualScreenshot : MonoBehaviour
{
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Scene m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ScreenCapture.CaptureScreenshot("screenshot/"+sceneName + ".png");


            Debug.Log("screenshot");
        }
    }
}
