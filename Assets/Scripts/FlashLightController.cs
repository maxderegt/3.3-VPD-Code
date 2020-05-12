using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public Light Spotlight;
    public List<BoxCollider> Colliders;
    public List<Color> Colors;
    public Material ColorDisplay;
    public TextMesh TextDisplay;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    private bool LightOn = true;
    private int SelectedColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        Colliders[SelectedColor].enabled = true;
        Spotlight.color = Colors[SelectedColor];
        ColorDisplay.color = Colors[SelectedColor];
        TextDisplay.text = Colliders[SelectedColor].transform.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightOn)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                int previous = SelectedColor;
                SelectedColor--;
                if (SelectedColor < 0)
                    SelectedColor = Colliders.Count - 1;
                ChangeColliderAndColor(SelectedColor, previous);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                int previous = SelectedColor;
                SelectedColor++;
                if (SelectedColor > Colliders.Count - 1)
                    SelectedColor = 0;
                ChangeColliderAndColor(SelectedColor, previous);
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            audioSource.PlayOneShot(clip, volume);
            LightOn = !LightOn;
            Spotlight.enabled = LightOn;
            if (LightOn)
            {
                ColorDisplay.color = Colors[SelectedColor];
                TextDisplay.text = Colliders[SelectedColor].transform.tag;
            }
            else
            {
                ColorDisplay.color = Color.black;
                TextDisplay.text = "off";
            }
        }
    }

    private void ChangeColliderAndColor(int current, int previous)
    {
        audioSource.PlayOneShot(clip, volume);
        Colliders[current].enabled = true;
        Colliders[previous].enabled = false;
        Spotlight.color = Colors[current];
        ColorDisplay.color = Colors[current];
        TextDisplay.text = Colliders[current].transform.tag;
    }
}