using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{

    public List<ResearchMethods> StepsRequired;
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
