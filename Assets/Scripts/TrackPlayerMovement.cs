﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerMovement : MonoBehaviour
{

    List<Vector3> playerPos = new List<Vector3>();
    public Material trail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos.Add(transform.position);

        if (Input.GetKeyDown(KeyCode.M))
        {
            drawPlayerMovement();
        }
    }

    public void drawPlayerMovement()
    {
        Color red = Color.red;
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = trail;
        lineRenderer.startWidth = 0.03F;
        lineRenderer.endWidth = 0.03F;
        lineRenderer.receiveShadows = false;
        lineRenderer.allowOcclusionWhenDynamic = false;

        //Change how mant points based on the mount of positions is the List
        lineRenderer.positionCount = playerPos.Count-1;

        for (int i = 0; i < playerPos.Count-1; i++)
        {
            //Change the postion of the lines
            lineRenderer.SetPosition(i, playerPos[i]);
        }
    }
}
