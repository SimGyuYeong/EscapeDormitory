using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVViewer : MonoBehaviour
{
    [SerializeField]
    private LayerMask cctvLayerMask;

    private RaycastHit _hit;
    private CCTV _viewCCtv;

    [SerializeField]
    private RawImage _image;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, Mathf.Infinity, cctvLayerMask))
            {
                _viewCCtv = _hit.transform.GetComponent<CCTV>();
                Material mat = _viewCCtv.ZoomIn();
                _image.transform.gameObject.SetActive(true);
                _image.texture = mat.mainTexture;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_image.gameObject.activeSelf == true)
            {
                _image.transform.gameObject.SetActive(false);
            }
        }
    }

}
