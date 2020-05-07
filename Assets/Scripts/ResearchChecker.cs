using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            List<Results> results = CheckAllResearch();
        }
    }

    public List<Results> CheckAllResearch()
    {
        List<Results> results = new List<Results>();
        var gameobjects = Resources.FindObjectsOfTypeAll<ResearchManager>();
        foreach (ResearchManager item in gameobjects)
        {
            results.Add(new Results(item.StepsRequired, item.StepsTaken);
        }

        return results;
    }
}
