using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    [Header("Scene")]
    public Transform selectionTransform = null;
    public Transform cursorTransform = null;
    public List<RadialSection> radialSections = new List<RadialSection>();
    public InputManager inputManager;

    private Vector2 touchPosition = Vector2.zero;
    private RadialSection highlightedsection = null;
    

    private void Start()
    {
    }

    public void Show(bool value)
    {
        gameObject.SetActive(value);
    }

    private void Update()
    {
        Vector2 direction = Vector2.zero + touchPosition;
        float rotation = GetDegeree(direction);

        SetCursorPosition();
        SetSelectionRotation(rotation);
        SetSelectedEvent(rotation);
    }

    private float GetDegeree(Vector2 direction)
    {
        float value = Mathf.Atan2(direction.x, direction.y);
        value *= Mathf.Rad2Deg;

        if (value < 0)
            value += 360;


        return value;
    }

    private void SetCursorPosition()
    {
        cursorTransform.localPosition = touchPosition;
    }

    public void SetTouchPosition(Vector2 newvalue)
    {
        touchPosition = newvalue;
    }

    private void SetSelectionRotation(float newRotation)
    {
        float snaprotation = SnapRotation(newRotation);
        selectionTransform.localEulerAngles = new Vector3(0, 0, -snaprotation);
    }

    private float SnapRotation(float rotation)
    {
        return GetNearestIncrement(rotation) * (360/radialSections.Count);
    }

    private int GetNearestIncrement(float rotation)
    {
        return Mathf.RoundToInt(rotation / (360 / radialSections.Count));
    }

    private void SetSelectedEvent(float currentRotation)
    {
        int index = GetNearestIncrement(currentRotation);
        if (index == radialSections.Count)
            index = 0;

        highlightedsection = radialSections[index];
    }

    public void ActivateHighligtedSection()
    {
        switch (highlightedsection.name)
        {
            case "UV Lamp":
                inputManager.switchtools(1);
                Show(false);
                break;
            case "Camera":
                inputManager.switchtools(2);
                Show(false);
                break;
            case "Kwast":
                inputManager.switchtools(3);
                Show(false);
                break;
            case "Markers":
                Show(false);
                inputManager.EnterMarkersMenu();
                break;
            case "000nm":
                inputManager.switchLight(0);
                break;
            case "350nm":
                inputManager.switchLight(1);
                break;
            case "415nm":
                inputManager.switchLight(2);
                break;
            case "450nm":
                inputManager.switchLight(3);
                break;
            case "MBack":
                Show(false);
                inputManager.LeaveMarkersMenu();
                break;
            case "m1":
                inputManager.SpawnMarker(0);
                break;
            case "m2":
                inputManager.SpawnMarker(1);
                break;
            case "m3":
                inputManager.SpawnMarker(2);
                break;
            case "m4":
                inputManager.SpawnMarker(3);
                break;
            case "m5":
                inputManager.SpawnMarker(4);
                break;
            case "m6":
                inputManager.SpawnMarker(5);
                break;
            case "m7":
                inputManager.SpawnMarker(6);
                break;
            case "m8":
                inputManager.SpawnMarker(7);
                break;
            case "m9":
                inputManager.SpawnMarker(8);
                break;
            case "m10":
                inputManager.SpawnMarker(9);
                break;
                break;
            case "r1":
                inputManager.methodAdder.addResearch(ResearchMethods.DNA);
                break;
            case "r2":
                inputManager.methodAdder.addResearch(ResearchMethods.Fingerprint);
                break;
            case "r3":
                inputManager.methodAdder.addResearch(ResearchMethods.Label);
                break;
            case "r4":
                inputManager.methodAdder.addResearch(ResearchMethods.Saliva);
                break;
            case "r5":
                inputManager.methodAdder.addResearch(ResearchMethods.Shoeprint);
                break;
            case "r6":
                inputManager.methodAdder.addResearch(ResearchMethods.GunshotResidue);
                break;
            case "r7":
                inputManager.methodAdder.addResearch(ResearchMethods.CauseOfDeath);
                break;
            case "r8":
                inputManager.methodAdder.addResearch(ResearchMethods.KIV);
                break;
            case "r9":
                inputManager.methodAdder.addResearch(ResearchMethods.MilieOnderzoek);
                break;
            case "r10":
                inputManager.methodAdder.addResearch(ResearchMethods.DrugAnalysis);
                break;
            case "r11":
                inputManager.methodAdder.addResearch(ResearchMethods.HandwritingAnalysis);
                break;
            case "r12":
                inputManager.methodAdder.addResearch(ResearchMethods.DigitalAnalysis);
                break;
            case "r13":
                inputManager.methodAdder.sendoff();
                break;
        }
    }
}
