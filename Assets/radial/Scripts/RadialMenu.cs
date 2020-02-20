using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    [Header("Scene")]
    public Transform selectionTransform = null;
    public Transform cursorTransform = null;
    public List<RadialSection> radialSections = new List<RadialSection>();

    private Vector2 touchPosition = Vector2.zero;
    private RadialSection highlightedsection = null;
    

    private void Start()
    {
        Show(false);
    }

    private void Awake()
    {
        CreateSections();
    }
    
    private void CreateSections()
    {
        int i = 0;
        foreach(RadialSection section in radialSections)
        {
            //section.iconrenderer.sprite = section.icon;
            section.name = i.ToString();
            i++;
        }
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
        print(highlightedsection.name);
    }
}
