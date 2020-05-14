using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playSound : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of play Sound")]
    [TextArea(2, 5)]
    public string Description = "this script plays a sound when it's function is called";

    private AudioSource audioSource;

    [Tooltip("The audio clip that is played when a screenshot is taken")]
    public AudioClip clip;

    [Tooltip("The volume of the clip that is played")]
    public float volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
    }

    public void click()
    {
        audioSource.PlayOneShot(clip, volume);

    }
}
