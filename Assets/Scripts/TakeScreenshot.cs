using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TakeScreenshot : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public Camera camera;
    public TakeRoomScreenshot takeRoomScreenshot;
    public GameObject simpelcamera;
    public GameObject realisticcamera;

    private string path = "Screenshot";

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
           // ScreenCapture.CaptureScreenshot("Screenshot VPD - " + DateTime.Now.ToString("h-mm-ss")+".png");


            var currentRT = RenderTexture.active;
            RenderTexture.active = camera.targetTexture;

            // Render the camera's view.
            camera.Render();

            // Make a new texture and read the active Render Texture into it.
            Texture2D image = new Texture2D(1920, 1080);
            image.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
            image.Apply();

            SaveTextureAsJPG(image, path + "/Screenshot VPD - " + DateTime.Now.ToString("h-mm-ss.fff") + ".jpg");

            Debug.Log("Screenshot taken");

            TakeRoomScreenshot();
            
        }
    }

    private void TakeRoomScreenshot()
    {
        simpelcamera.SetActive(true);
        realisticcamera.SetActive(false);

        takeRoomScreenshot.TakeScreenshot(false);

        simpelcamera.SetActive(false);
        realisticcamera.SetActive(true);
    }


    public void SaveTextureAsJPG(Texture2D _texture, string _fullPath)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        byte[] _bytes = _texture.EncodeToJPG();
        File.WriteAllBytes(_fullPath, _bytes);
    }
}
