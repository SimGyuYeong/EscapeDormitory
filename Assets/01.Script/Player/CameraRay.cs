using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    private float range = 0f;

    [SerializeField]
    private RaycastHit layer;

    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        
    }

    void Update()
    {
        RayCastShoot();    
    }

    private void RayCastShoot()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out layer, range, layerMask))
        {
            if(layer.transform.tag == "bell")
            {
                InfoUP();
            }
        }
    }

    private void InfoUP()
    {

    }
}
