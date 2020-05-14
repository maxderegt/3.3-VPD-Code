using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

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
            addResearch(ResearchMethods.DNA);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            addResearch(ResearchMethods.Fingerprint);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            addResearch(ResearchMethods.Label);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            sendoff();
        }
    }

    public void addResearch(ResearchMethods method)
    {
        Hand hand = this.GetComponent<Hand>();
        var objects = hand.AttachedObjects;
        //searches for child with Research Manager script
        foreach (var child in objects)
        {
            var attachedobject = child.attachedObject;
            ResearchManager sn = attachedobject.GetComponent<ResearchManager>();
            if (sn == null)
            {
                attachedobject.AddComponent<ResearchManager>();
                sn = attachedobject.GetComponent<ResearchManager>();
                sn.StepsRequired = new List<ResearchMethods>();
                sn.StepsTaken = new List<ResearchMethods>();
            }
            //adds DNA to it
            sn.addStep(method);
        }
    }
    public void sendoff()
    {
        Hand hand = this.GetComponent<Hand>();
        var objects = hand.AttachedObjects;
        //searches for child with Research Manager script
        foreach (var child in objects)
        {
            var attachedobject = child.attachedObject;
            ResearchManager sn = attachedobject.GetComponent<ResearchManager>();
            if (sn == null)
            {
                attachedobject.AddComponent<ResearchManager>();
                sn = attachedobject.GetComponent<ResearchManager>();
                sn.StepsRequired = new List<ResearchMethods>();
                sn.StepsTaken = new List<ResearchMethods>();
            }
            attachedobject.transform.position = new Vector3(attachedobject.transform.position.x, attachedobject.transform.position.y-20, attachedobject.transform.position.z);
            Rigidbody rb = attachedobject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.useGravity = false;
            }
            hand.DetachObject(attachedobject,false);
            attachedobject.transform.parent = null;
        }
    }
}
