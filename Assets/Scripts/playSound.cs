using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;
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
