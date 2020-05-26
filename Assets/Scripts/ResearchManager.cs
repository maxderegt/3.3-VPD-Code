using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of Research Manager")]
    [TextArea(2, 5)]
    public string Description = "This script keeps track of all the Research Methods that needs to be done with this object and adds methods which have to be done";

    [Tooltip("list of all the steps required")]
    public List<ResearchMethods> StepsRequired =  new List<ResearchMethods>() { ResearchMethods.Label};

    [Tooltip("list of all the steps taken")]
    public List<ResearchMethods> StepsTaken;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addStep(ResearchMethods method)
    {
        if(!StepsTaken.Contains(method))
            StepsTaken.Add(method);
    }
}
