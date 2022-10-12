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

    private Vector3 _leftRotateVec;
    private Vector3 _rightRotateVec;

    private void Start()
    {
        _leftRotateVec = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 30f, transform.eulerAngles.z);
        _rightRotateVec = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 30f, transform.eulerAngles.z);

        StartCoroutine(CameraMove());
    }

    private IEnumerator CameraMove()
    {
        while(true)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DORotate(_rightRotateVec, _moveDuration));
            seq.AppendInterval(_waitDuration);
            seq.Append(transform.DORotate(_leftRotateVec, _moveDuration));
            seq.AppendInterval(_waitDuration);
            yield return new WaitForSeconds(seq.Duration());
        }
    }
}
