using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of Flash Light Controller")]
    [TextArea(2, 5)]
    public string Description = "This script handles everything for the UV Flash light";
    [Space]


    [Header("UV Light settings")]
    [Space]
    [Tooltip("The spotlight that is used for the UV lighting")]
    public Light Spotlight;

    [Tooltip("The List of all the UV Colliders")]
    public List<BoxCollider> Colliders;

    [Tooltip("The List of the UV Colors")]
    public List<Color> Colors;

    [Tooltip("The color display on the flashlight to show the current status")]
    public Material ColorDisplay;

    [Tooltip("The text display on the flashlight to show the current status")]
    public TextMesh TextDisplay;


    [Space]

    [Header("Audio settings")]
    [Tooltip("The location where the audio is played from")]
    public AudioSource audioSource;
    [Tooltip("The audio clip that is played when a screenshot is taken")]
    public AudioClip clip;
    [Tooltip("The volume of the clip that is played")]
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
            //go back through the list
            if (Input.GetKeyDown(KeyCode.K))
            {
                PreviousNM();
            }
            //go forward through the list
            if (Input.GetKeyDown(KeyCode.L))
            {
                NextNM();
            }
        }
        //switches the flashlight on or off
        if (Input.GetKeyDown(KeyCode.O))
        {
            PowerOnOff();
        }
    }

    public void Switchto(int i)
    {
        audioSource.PlayOneShot(clip, volume);
        int previous = SelectedColor;
        SelectedColor = i;
        ChangeColliderAndColor(SelectedColor, previous);
    }

    public void PreviousNM()
    {
        audioSource.PlayOneShot(clip, volume);
        int previous = SelectedColor;
        SelectedColor--;
        if (SelectedColor < 0)
            SelectedColor = Colliders.Count - 1;
        //sets the new color and collider
        ChangeColliderAndColor(SelectedColor, previous);
    }

    public void NextNM()
    {
        audioSource.PlayOneShot(clip, volume);
        int previous = SelectedColor;
        SelectedColor++;
        if (SelectedColor > Colliders.Count - 1)
            SelectedColor = 0;
        //sets the new color and collider
        ChangeColliderAndColor(SelectedColor, previous);
    }

    public void PowerOnOff()
    {//plays a clicking sound
        audioSource.PlayOneShot(clip, volume);
        //on or off
        LightOn = !LightOn;
        Spotlight.enabled = LightOn;

        //if light is on than set the displays correctly
        if (LightOn)
        {
            ColorDisplay.color = Colors[SelectedColor];
            TextDisplay.text = Colliders[SelectedColor].transform.tag;
        }
        //if else set the displays to off status
        else
        {
            ColorDisplay.color = Color.black;
            TextDisplay.text = "off";
        }

    }

    private void ChangeColliderAndColor(int current, int previous)
    {
        //plays a clicking sound
        audioSource.PlayOneShot(clip, volume);
        //enables current ÚV collider
        Colliders[current].enabled = true;
        //disables previous UV collider
        Colliders[previous].enabled = false;
        //switches the UV spotlight to current color
        Spotlight.color = Colors[current];
        //switches the color display to current color
        ColorDisplay.color = Colors[current];
        //changes the text display to current text
        TextDisplay.text = Colliders[current].transform.tag;
    }
}