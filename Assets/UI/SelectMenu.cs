using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SelectMenu : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    public List<string> allScenes = new List<string>();
    public List<Button> sceneButtons;
    public GameObject pfbutton;
    public GameObject contentgrid;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;

        sceneButtons = new List<Button>();
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            allScenes.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));

            if (allScenes[i] == "Main menu")
                continue;

            GameObject button = Instantiate(pfbutton);
            Text text = button.transform.GetChild(0).GetComponent(typeof(Text)) as Text;
            text.text = allScenes[i];
            Button b = button.GetComponent<Button>();
            b.onClick.AddListener(delegate ()
            {
                Text name = b.transform.GetChild(0).GetComponent(typeof(Text)) as Text;
                SceneManager.LoadScene(name.text);
                audioSource.PlayOneShot(clip, volume);
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
