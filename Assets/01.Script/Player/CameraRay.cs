using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private float range = 10f;

    [SerializeField] private float itemCheckrange = 0f;

    [SerializeField] private RaycastHit hitinfo;

    [SerializeField] private LayerMask layerMask;

    //[SerializeField] private UnityEvent ItemInfoEvent;




    
    
    private Camera cam;

    string infoname = null;

    void Start()
    {
        cam = UnityEngine.Camera.main;
        
    }

    void Update()
    {
        CheckingInview();
    }
    private void CheckingInview()
    {
        Collider[] ItemTargets = Physics.OverlapSphere(transform.position, itemCheckrange, layerMask);

        for(int i = 0; i < ItemTargets.Length; i++)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(ItemTargets[i].transform.position);

            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                Debug.Log("Ã¼Å·µÊ");
                if(Physics.Raycast(transform.position, transform.forward, out hitinfo))
                {
                    if(hitinfo.transform.CompareTag("Item"))
                    {

                    }
                
                }    
            }
        }
    }

}
