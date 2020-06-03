using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dddonlfixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject newGO = new GameObject();
        this.transform.parent = newGO.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
