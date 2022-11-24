using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("카메라 기본속성")]
    private Transform _camTransform = null; //카메라 캐싱준비
    public float rotateSpeed = 4.0f;

    //마우스 카메라 조절 좌표
    public float detailX = 2f;
    public float detailY = 2f;

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

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (character.GetComponent<CCTVViewer>().CCTVViewing == true)
            return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX = _camTransform.localEulerAngles.y + mouseX * detailX;
        rotationX = (rotationX > 180.0f) ? rotationX - 360.0f : rotationX;

        rotationY = rotationY + mouseY * detailY;
        rotationY = (rotationY > 180.0f) ? rotationY - 360.0f : rotationY;

        if (rotationY <= -80f) rotationY = -80f;
        if (rotationY >= 80F) rotationY = 80f;

        _camTransform.localEulerAngles = new Vector3(-rotationY, rotationX);
        character.localEulerAngles = new Vector3(0, rotationX, 0);
        _camTransform.position = posFirstameraTarget.position;
    }
}
