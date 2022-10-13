using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CCTV : MonoBehaviour
{
    [Tooltip("멈춰있는 시간")]
    [SerializeField]
    private float _waitDuration = 1f;

    [Tooltip("한바퀴 도는데 걸리는 시간")]
    [SerializeField]
    private float _moveDuration = 3f;

    [SerializeField]
    private Camera _linkCam;

    private Vector3 _leftRotateVec;
    private Vector3 _rightRotateVec;

    Sequence _camAutoMoveSeq;

    private void Start()
    {
        _leftRotateVec = new Vector3(_linkCam.transform.eulerAngles.x, _linkCam.transform.eulerAngles.y - 30f, _linkCam.transform.eulerAngles.z);
        _rightRotateVec = new Vector3(_linkCam.transform.eulerAngles.x, _linkCam.transform.eulerAngles.y + 30f, _linkCam.transform.eulerAngles.z);

        _linkCam.transform.DORotate(_leftRotateVec, 0);

        _camAutoMoveSeq = DOTween.Sequence()
            .SetAutoKill(false)
            .Append(_linkCam.transform.DORotate(_rightRotateVec, _moveDuration).SetEase(Ease.InSine))
            .AppendInterval(_waitDuration)
            .Append(_linkCam.transform.DORotate(_leftRotateVec, _moveDuration).SetEase(Ease.InSine))
            .AppendInterval(_waitDuration)
            .SetLoops(-1);
    }

    private void OnEnable()
    {
        _camAutoMoveSeq.Restart();
    }

    public void ZoomIn()
    {
        _camAutoMoveSeq.Kill();
        Debug.Log(transform.name);
    }

    public void ZoomOut()
    {
        _camAutoMoveSeq.Restart();
    }
}
