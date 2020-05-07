using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVEvidenceController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.tag.Equals(other.transform.tag))
            meshRenderer.enabled = true;
        else
            meshRenderer.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        meshRenderer.enabled = false;
    }
}
