using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBtn : MonoBehaviour
{
    public Camera Camera;
    [Header("dont remove")]
    [TextArea]
    public string description = "this script contains logic an exit button";

    //close application
    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        //Camera.transform.Rotate(Mathf.Sin(i), Mathf.Sin(i), 0);
    }
}
