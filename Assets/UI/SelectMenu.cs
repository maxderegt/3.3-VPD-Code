using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    List<Scene> allScenes;
    public List<Button> sceneButtons;

    // Start is called before the first frame update
    void Start()
    {
        sceneButtons = new List<Button>();
        allScenes = new List<Scene>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            allScenes.Add(SceneManager.GetSceneAt(i));
     
        }

    }

    public void Select(string levelName)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
