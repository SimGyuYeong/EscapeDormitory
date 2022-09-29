using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("카메라 기본속성")]
    private Transform _camTransform = null; //카메라 캐싱준비
    public GameObject objTarget = null;
    private Transform _objTargetTransform = null;

    //마우스 카메라 조절 좌표
    public float detailX = 5f;
    public float detailY = 5f;

    //마우스 회전값
    public float rotationX = 0f;
    public float rotationY = 0f;

    //캐릭터에 카메라 눈 장작 포인트
    public Transform posFirstameraTarget = null;

    public Transform character;
    
    private void Awake()
    {
        _camTransform = transform;
    }

    private void LateUpdate()
    {
        if (objTarget == null) return;

        if (_objTargetTransform == null) _objTargetTransform = objTarget.transform;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX = _camTransform.localEulerAngles.y + mouseX * detailX;
        rotationX = (rotationX > 180.0f) ? rotationX - 360.0f : rotationX;

        rotationY = rotationY + mouseY * detailY;
        rotationY = (rotationY > 180.0f) ? rotationY - 360.0f : rotationY;

        if (rotationY <= -80f) rotationY = -80f;
        if (rotationY >= 80F) rotationY = 80f;

        if (rotationX <= -80f + character.rotation.y) rotationX = -80f + character.rotation.y;
        if (rotationX >= 80f + character.rotation.y) rotationX = 80f + character.rotation.y;

        _camTransform.localEulerAngles = new Vector3(-rotationY, rotationX);
        _camTransform.position = posFirstameraTarget.position;
    }
}
