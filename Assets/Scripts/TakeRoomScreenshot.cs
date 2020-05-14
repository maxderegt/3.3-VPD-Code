using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TakeRoomScreenshot : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of Take Room Screenshot")]
    [TextArea(2, 5)]
    public string Description = "This script takes a picture from above whenever a picture with a camera is taken";

    [Tooltip("The Camera feed of which the picture is taken")]
    public Camera camera;

    [Tooltip("The script that takes care of the player tracking")]
    public TrackPlayerMovement trackPlayerMovement;

    [Tooltip("The directional light to create a even lighting situation")]
    public Light light;

    [Tooltip("The normal light that is used in the scene")]
    public Light roomlight;

    private string path = "Screenshot";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() { 
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeScreenshot(true);
        }
    }

    public void TakeScreenshot(bool showplayermovement)
    {
        //shows the player path
        if (showplayermovement)
            trackPlayerMovement.drawPlayerMovement();

        //sets the directional light on for an even lighting situation
        light.enabled = true;
        roomlight.enabled = false;
        

        //this part takes the screenshot and puts it in a Texture2D variable
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(1920, 1080);
        image.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
        image.Apply();

        //saves the sreenshot as jpeg
        SaveTextureAsJPG(image, path + "/RoomScreenshot VPD - " + DateTime.Now.ToString("h-mm-ss.fff") + ".jpg");

        Debug.Log("Screenshot taken");

        //return the light to normal
        light.enabled = false;
        roomlight.enabled = true;
    }

    //saves the sreenshot as jpeg
    public void SaveTextureAsJPG(Texture2D _texture, string _fullPath)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        byte[] _bytes = _texture.EncodeToJPG();
        File.WriteAllBytes(_fullPath, _bytes);
    }
}
