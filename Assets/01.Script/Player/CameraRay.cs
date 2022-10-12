using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    private float range = 10f;

    [SerializeField]
    private RaycastHit hitinfo;

    [SerializeField]
    private LayerMask layerMask;

    string infoname = null;

    void Start()
    {
        
    }

    void Update()
    {
        RayCastShoot();    
    }

    private void RayCastShoot()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            if (hitinfo.transform.tag == "bell")
            {
                EventManager.eventManager.InfoUP();
            }

        }
    }

    

        



    

    
}
