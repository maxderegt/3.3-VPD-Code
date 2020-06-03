using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFoto: MonoBehaviour
{
    [Header("make screenshot as previeuw for the main menu")]
    [TextArea(2, 5)]
    public string Description = "this class makes a foto from the players perspective and saves it. The menu uses these foto's as previeuws for the scene";
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

            ScreenCapture.CaptureScreenshot("Assets/Resources/Textures" + sceneName + ".png");


            Debug.Log("screenshot");
        }
    }
}
