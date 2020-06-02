using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InputManager : MonoBehaviour
{
    [Header("Actions")]
    public SteamVR_Action_Boolean touch = null;
    public SteamVR_Action_Boolean press = null;
    public SteamVR_Action_Vector2 touchposition = null;
    public SteamVR_Action_Boolean trigger = null;

    [Header("Scene Objects")]
    public RadialMenu ResearchMenu = null;
    public RadialMenu ToolsMenu = null;
    public RadialMenu MarkersMenu = null;
    public RadialMenu LightMenu = null;

    [Header("Player tools")]
    public GameObject Brush;
    public GameObject Camera;
    public GameObject Flashlight;

    [Header("Markers")]
    public List<GameObject> Markers;

    [Header("Method Adder")]
    public MethodAdder methodAdder;

    private bool toolsmenu = true;
    private Hand hand;
    private bool playertoolactive = false;
    private GameObject handrenderer;
    private void Awake()
    {
        touch.onChange += Touch;
        press.onStateUp += PressRelease;
        touchposition.onAxis += Position;
        trigger.onStateDown += Pinch;
        trigger.onStateUp += UnPinch;

        Flashlight.transform.parent = null;
        hand = GetComponent<Hand>();
    }

    private void onDestroy()
    {
        touch.onChange -= Touch;
        press.onStateUp -= PressRelease;
        touchposition.onAxis -= Position;
    }

    public void SpawnMarker(int i)
    {
        var marker = Instantiate(Markers[i]);
        marker.transform.position = transform.position;
    }

    public void switchLight(int i)
    {
        FlashLightController controller = GetComponentInChildren<FlashLightController>();
        controller.Switchto(i);
    }
    public void EnterMarkersMenu()
    {
        toolsmenu = false;
    }

    public void LeaveMarkersMenu()
    {
        toolsmenu = true;
    }

    public void switchtools(int i)
    {
        if(handrenderer == null)
        {
            handrenderer = transform.Find("RightRenderModel Slim(Clone)").gameObject;
        }

        switch (i)
        {
            case 0:
                hand.enabled = true;
                handrenderer.SetActive(true);
                Brush.SetActive(false);
                Camera.SetActive(false);
                playertoolactive = false;
                break;
            case 1:
                Flashlight.SetActive(true);
                Flashlight.transform.position = transform.position;
                Flashlight.transform.rotation = transform.rotation;
                break;
            case 2:
                hand.enabled = false;
                handrenderer.SetActive(false);
                Camera.SetActive(true);
                playertoolactive = true;
                break;
            case 3:
                hand.enabled = false;
                handrenderer.SetActive(false);
                Brush.SetActive(true);
                playertoolactive = true;
                break;
        }
    }

    private void UnPinch(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        ToolsMenu.Show(false);
        ResearchMenu.Show(false);
        MarkersMenu.Show(false);
        LightMenu.Show(false);
    }
    private void Pinch(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (Camera.active)
        {
            TakeScreenshot screenshot = GetComponentInChildren<TakeScreenshot>();
            screenshot.takescreenshot();
        }
    }

    private void Position(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        if (!playertoolactive)
        {
            Hand hand = this.GetComponent<Hand>();
            var objects = hand.AttachedObjects;
            if (objects.Count == 0)
            {                
                if (toolsmenu)
                    ToolsMenu.SetTouchPosition(axis);
                else
                    MarkersMenu.SetTouchPosition(axis);
                
            }
            else
            {
                var item = objects[0].attachedObject;
                if (item.name.Equals("PF_Flashlight"))
                {
                    LightMenu.SetTouchPosition(axis);
                }
                else
                {
                    ResearchMenu.SetTouchPosition(axis);
                }
            }
        }
    }

    private void Touch(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (!playertoolactive)
        {
            Hand hand = this.GetComponent<Hand>();
            var objects = hand.AttachedObjects;
            if (objects.Count == 0)
            {                
                if (toolsmenu)
                    ToolsMenu.Show(newState);
                else
                    MarkersMenu.Show(newState);
            }
            else
            {
                var item = objects[0].attachedObject;
                if (item.name.Equals("PF_Flashlight"))
                {
                    LightMenu.Show(newState);
                }
                else
                {
                    ResearchMenu.Show(newState);
                }
            }
        }
    }

    private void PressRelease(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (!playertoolactive)
        {
            Hand hand = this.GetComponent<Hand>();
            var objects = hand.AttachedObjects;
            if (objects.Count == 0)
            {
                if (toolsmenu)
                    ToolsMenu.ActivateHighligtedSection();
                else
                    MarkersMenu.ActivateHighligtedSection();
            }
            else
            {
                var item = objects[0].attachedObject;
                if (item.name.Equals("PF_Flashlight"))
                {
                    LightMenu.ActivateHighligtedSection();
                }
                else
                {
                    ResearchMenu.ActivateHighligtedSection();
                }
            }
        }
        else
        {
            switchtools(0);
        }
    }
}

