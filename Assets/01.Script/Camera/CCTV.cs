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

    private Vector3 _minRotate;
    private Vector3 _maxRotate;


    private void Start()
    {
        _rotateTrm = _linkCam.transform.GetChild(0);

        _minRotate = new Vector3(_rotateTrm.localRotation.x, _rotateTrm.localRotation.y - 5f, _rotateTrm.localRotation.z);
        _maxRotate = new Vector3(_rotateTrm.localRotation.x, _rotateTrm.localRotation.y + 5f, _rotateTrm.localRotation.z);

        _rotateTrm.rotation = Quaternion.Euler(_minRotate);
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while(true)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(_rotateTrm.DORotate(_maxRotate, _rotateAmount)).SetEase(Ease.InOutQuad);
            seq.Append(_rotateTrm.DORotate(_minRotate, _rotateAmount)).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(seq.Duration());
        }
    }

    public Material ZoomIn()
    {
        return transform.GetComponent<MeshRenderer>().material;
    }
}
