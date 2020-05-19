using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSway : MonoBehaviour
{
    public GameObject Camera;
    float time;
    float halfPI = Mathf.PI / 2;

    // Update is called once per frame
    Coroutine coroutine;
    private void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        Camera.transform.Rotate(0, Mathf.Sin(time - halfPI) / 3, 0);

    }

}