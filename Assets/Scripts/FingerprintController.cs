using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerprintController : MonoBehaviour
{

    private MeshRenderer meshRenderer;

    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {

        //gets texture and disables it
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
        {
            if (meshRenderer.enabled == false)
            {
                particle.Play();
            }
            meshRenderer.enabled = true;
        }
    }
}
