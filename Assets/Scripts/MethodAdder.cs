using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodAdder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            foreach (Transform child in transform)
            {
                ResearchManager sn = child.GetComponent<ResearchManager>();
                if (sn != null)
                {
                    sn.addStep(ResearchMethods.DNA);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            foreach (Transform child in transform)
            {
                ResearchManager sn = child.GetComponent<ResearchManager>();
                if (sn != null)
                {
                    sn.addStep(ResearchMethods.Fingerprint);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (Transform child in transform)
            {
                ResearchManager sn = child.GetComponent<ResearchManager>();
                if (sn != null)
                {
                    sn.addStep(ResearchMethods.Label);
                }
            }
        }
    }
}
