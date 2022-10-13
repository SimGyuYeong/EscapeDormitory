using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private float range = 10f;

    [SerializeField] private RaycastHit hitinfo;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private List<GameObject> findList = null;

    private Camera cam;

    string infoname = null;

    void Start()
    {
        cam = UnityEngine.Camera.main;
    }

    void Update()
    {
        RayCastShoot();
        
    }
    private void LateUpdate()
    {
        CheckingInview();
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

    private void CheckingInview()
    {
        for(int i = 0; i < findList.Count; i++)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(findList[i].transform.position);
            if(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                Debug.Log($"Camera in object : {findList[i].name}");
            }
        }
    }

    

        



    

    
}
