using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public List<string> allScenes = new List<string>();
    public List<Button> sceneButtons;
    public GameObject pfbutton;
    public GameObject contentgrid;

    // Start is called before the first frame update
    void Start()
    {
        sceneButtons = new List<Button>();
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            allScenes.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
            GameObject button = Instantiate(pfbutton);
            Text text = button.transform.GetChild(0).GetComponent(typeof(Text)) as Text;
            text.text = allScenes[i];
            Button b = button.GetComponent<Button>();
            b.onClick.AddListener(delegate () {
                Text name = b.transform.GetChild(0).GetComponent(typeof(Text)) as Text;
                SceneManager.LoadScene(name.text); 
            });
            button.transform.parent = contentgrid.transform;
            sceneButtons.Add(b);
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
