using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVViewer : MonoBehaviour
{
    [SerializeField]
    private LayerMask cctvLayerMask;

    private RaycastHit _hit;

    [SerializeField]
    private RawImage _image;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, Mathf.Infinity, cctvLayerMask))
            {
                Material mat = _hit.transform.GetComponent<CCTV>().ZoomIn();
                
            }
        }
    }
}
