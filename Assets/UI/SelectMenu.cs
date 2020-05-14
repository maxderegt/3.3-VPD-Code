using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SelectMenu : MonoBehaviour
{
    [Header("dont remove")]
    [TextArea]
    public string description = "this script fils the menu with buttons for the different scene's";

    private AudioSource audioSource;
    [Tooltip("the audio to be played on button click")]
    public AudioClip clip;
    [Tooltip("the loudness of the played sound")]
    public float volume = 0.5f;

    private List<string> allScenes = new List<string>();
    private List<Button> sceneButtons;
    [Tooltip("the button that is used in the menu")]
    public GameObject pfbutton;
    [Tooltip("the grid to which the buttons are added")]
    public GameObject contentgrid;

    // Start is called before the first frame update
    void Start()
    {
        //get audio
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;

        sceneButtons = new List<Button>();
        //get scenes
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            //get scene name
            allScenes.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
            //dont add main menu to the menu
            if (allScenes[i] == "Main menu")
                continue;

            //create the button set text and try to set a previeuw
            GameObject button = Instantiate(pfbutton);
            Text text = button.transform.GetChild(0).GetComponent(typeof(Text)) as Text;
            text.text = allScenes[i];
            Button b = button.GetComponent<Button>();
            try
            {
                b.image.sprite = loadImage(new Vector2(1920, 1080), "Assets/Scenes/images/" + allScenes[i] + ".png");
            }
            catch (System.Exception)
            {
                Debug.Log("Error generating scene select menu: " + allScenes[i] + " doesn't have preview image");
            }

            //add listener to the button where it loads the scene and plays a sound
            b.onClick.AddListener(delegate ()
            {
                Text name = b.transform.GetChild(0).GetComponent(typeof(Text)) as Text;
                SceneManager.LoadScene(name.text);
                audioSource.PlayOneShot(clip, volume);
            });
            //set content grid as parent thus adding the button to the grid
            button.transform.SetParent(contentgrid.transform, false);
            sceneButtons.Add(b);
        }

    }

    /// <summary>
    /// load image from file path and change it to sprite
    /// </summary>
    /// <param name="size"> size of the image, width and height</param>
    /// <param name="filePath"> loaction of the image on disc </param>
    /// <returns></returns>
    private static Sprite loadImage(Vector2 size, string filePath)
    {
        //load image
        byte[] bytes = File.ReadAllBytes(filePath);
        //create texture2D to hold the image
        Texture2D texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
        texture.filterMode = FilterMode.Trilinear;
        //put image in texture
        texture.LoadImage(bytes);
        //create a sptrite using the texture 
        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        return sprite;
    }
}
