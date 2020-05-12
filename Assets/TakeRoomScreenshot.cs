using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeRoomScreenshot : MonoBehaviour
{
    public Camera camera;
    public TrackPlayerMovement trackPlayerMovement;
    public Light light;
    public Light roomlight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() { 
        if (Input.GetKeyDown(KeyCode.R))
        {
            trackPlayerMovement.drawPlayerMovement();
            light.enabled = true;
            roomlight.enabled = false;


            var currentRT = RenderTexture.active;
            RenderTexture.active = camera.targetTexture;

            // Render the camera's view.
            camera.Render();

            // Make a new texture and read the active Render Texture into it.
            Texture2D image = new Texture2D(1920, 1080);
            image.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
            image.Apply();

            SaveTextureAsJPG(image, "RoomScreenshot VPD - " + DateTime.Now.ToString("h-mm-ss") + ".jpg");

            Debug.Log("Screenshot taken");


            light.enabled = false;
            roomlight.enabled = true;

        }
    }

    public static void SaveTextureAsJPG(Texture2D _texture, string _fullPath)
    {
        byte[] _bytes = _texture.EncodeToJPG();
        System.IO.File.WriteAllBytes(_fullPath, _bytes);
    }
}
