using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCCTV : MonoBehaviour
{
    [SerializeField]
    private LayerMask cctvLayerMask;

    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, Mathf.Infinity, cctvLayerMask))
            {
                _hit.transform.GetComponent<CCTV>().ZoomIn();
            }
        }
    }
}
