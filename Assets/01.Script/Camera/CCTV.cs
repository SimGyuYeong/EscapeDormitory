using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CCTV : MonoBehaviour
{
    [Tooltip("돌아가는 속도")]
    [SerializeField]
    private float _rotateAmount = 0.5f;

    [SerializeField]
    private GameObject _linkCam;

    private Transform _rotateTrm;

    private void Start()
    {
        _rotateTrm = _linkCam.transform.GetChild(0);
    }

    private void Update()
    {
         _rotateTrm.rotation = Quaternion.Euler(_rotateTrm.eulerAngles.x, (Mathf.Sin(Time.realtimeSinceStartup) * _rotateAmount) + _rotateTrm.eulerAngles.y, _rotateTrm.eulerAngles.z);
    }

    public Material ZoomIn()
    {
        return transform.GetComponent<MeshRenderer>().material;
    }
}
