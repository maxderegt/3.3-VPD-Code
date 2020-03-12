using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TakeScreenshot : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(clip, volume);
            ScreenCapture.CaptureScreenshot("Screenshot VPD - " + DateTime.Now.ToString("h-mm-ss")+".png");
            Debug.Log("Screenshot taken");
        }
    }
}
