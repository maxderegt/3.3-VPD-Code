using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVEvidenceController : MonoBehaviour
{
    [Header("Dont remove")]
    [Tooltip("A description of UV Evidence Controller")]
    [TextArea(2,5)]
    public string Description;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //get UV texture and disable it
        meshRenderer = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //check to see if collider is UVhitbox if so enable UV texture
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
