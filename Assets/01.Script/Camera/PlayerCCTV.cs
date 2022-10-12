using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCCTV : MonoBehaviour
{
    [SerializeField]
    private LayerMask cctvLayerMask;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if(hit.transform.parent.gameObject.layer == (int)cctvLayerMask)
                {
                    Debug.Log("link");
                    Transform transform = hit.transform.parent;
                    transform.GetComponent<CCTV>().ZoomIn();
                }
            }
        }

    }
}
