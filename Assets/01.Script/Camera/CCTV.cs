using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CCTV : MonoBehaviour
{
    [Tooltip("돌아가는 시간")]
    [SerializeField]
    private float _rotateDuration = 5f;

    [SerializeField]
    private GameObject _linkCam;

    private Transform _rotateTrm;

    private Vector3 _minRotate;
    private Vector3 _maxRotate;


    private void Start()
    {
        _rotateTrm = _linkCam.transform.GetChild(0);

        _minRotate = new Vector3(_rotateTrm.localRotation.x, _rotateTrm.localRotation.y - 80f, _rotateTrm.localRotation.z);
        _maxRotate = new Vector3(_rotateTrm.localRotation.x, _rotateTrm.localRotation.y + 80f, _rotateTrm.localRotation.z);

        _rotateTrm.rotation = Quaternion.Euler(_minRotate);
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while(true)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(_rotateTrm.DORotate(_maxRotate, _rotateDuration)); 
            seq.AppendInterval(0.8f);
            seq.Append(_rotateTrm.DORotate(_minRotate, _rotateDuration));
            seq.AppendInterval(0.8f);
            yield return new WaitForSeconds(seq.Duration());
        }
    }

    public Material ZoomIn()
    {
        return transform.GetComponent<MeshRenderer>().material;
    }
}
