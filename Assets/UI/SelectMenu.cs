using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            b.image.sprite = loadImage(new Vector2(1920, 1080), "screenshot/" + allScenes[i] + ".png");
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

    private static Sprite loadImage(Vector2 size, string filePath)
    {

        byte[] bytes = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
        texture.filterMode = FilterMode.Trilinear;
        texture.LoadImage(bytes);
        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        return sprite;
    }
}
