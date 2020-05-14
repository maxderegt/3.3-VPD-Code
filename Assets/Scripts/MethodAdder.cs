using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodAdder : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of Method Adder")]
    [TextArea(2, 5)]
    public string Description = "This script adds a research method to it's child objects of the child has a Research Manager script";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            addDNA();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            addFingerprint();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            addLabel();
        }
    }

    public void addDNA()
    {
        //searches for child with Research Manager script
        foreach (Transform child in transform)
        {
            ResearchManager sn = child.GetComponent<ResearchManager>();
            if (sn != null)
            {
                //adds DNA to it
                sn.addStep(ResearchMethods.DNA);
            }
        }
    }
    public void addFingerprint()
    {
        //searches for child with Research Manager script
        foreach (Transform child in transform)
        {
            ResearchManager sn = child.GetComponent<ResearchManager>();
            if (sn != null)
            {
                //adds fingerprint to it
                sn.addStep(ResearchMethods.Fingerprint);
            }
        }
    }
    public void addLabel()
    {
        //searches for child with Research Manager script
        foreach (Transform child in transform)
        {
            ResearchManager sn = child.GetComponent<ResearchManager>();
            if (sn != null)
            {
                //adds label to it
                sn.addStep(ResearchMethods.Label);
            }
        }
    }
}
