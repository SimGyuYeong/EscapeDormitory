using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private float _walkSpd = 2.0f;
    [SerializeField] private float _runSpd = 5.0f;

    private Vector3 _moveDirect;
    private bool _isRunning = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        BodyRotation();
    }

    private void Move()
    {
        //백터 내적
        Transform cameraTransform = Camera.main.transform;
        //메인카메라가 바라보는 방향이 월드상에서 어떤 방향인가
        Vector3 foward = cameraTransform.TransformDirection(Vector3.forward);
        foward.y = 0f;

        Vector3 right = new Vector3(foward.z, 0f, -foward.x);

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 targetDirect = horizontal * right + vertical * foward;

        _moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, 50.0f * Mathf.Deg2Rad * Time.deltaTime, 1000f);
        _moveDirect = _moveDirect.normalized;

        float spd = _isRunning ? _walkSpd : _runSpd;

        Vector3 amount = (_moveDirect * spd * Time.deltaTime);

        _characterController.Move(amount);
    }

    private void BodyRotation()
    {
        Vector3 newForward = _characterController.velocity;
        newForward.y = 0;

        transform.forward = Vector3.Lerp(transform.forward, newForward, 50.0f * Time.deltaTime);
    }
}
