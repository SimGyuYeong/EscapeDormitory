using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController _characterController;
    private CollisionFlags collisionsFlags = CollisionFlags.None;

    [SerializeField] private float _walkSpd = 5.0f;
    [SerializeField] private float _runSpd = 8.0f;

    private Vector3 _moveDirect;
    private float _verticalSpd = 0;
    private float _gravity = 0.8f;
    private bool _isRunning = false;
    private Vector3 _jumpVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        BodyRotation();
        Jump();
        SetGravity();
        Running();
    }

    private void Running()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRunning = false;
        }
    }

    private void Move()
    {
        if (_characterController.isGrounded && _jumpVelocity.y < 0)
        {
            _jumpVelocity.y = 0f;
        }

        //백터 내적
        Transform cameraTransform = Camera.main.transform;
        //메인카메라가 바라보는 방향이 월드상에서 어떤 방향인가
        Vector3 foward = cameraTransform.TransformDirection(Vector3.forward);
        foward.y = 0f;

        Vector3 right = new Vector3(foward.z, 0f, -foward.x);

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 targetDirect = horizontal * right + vertical * foward;

        _moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, 500.0f * Mathf.Deg2Rad * Time.deltaTime, 1000f);
        _moveDirect = _moveDirect.normalized;

        float spd = _isRunning ? _runSpd : _walkSpd;

        Vector3 amount = (_moveDirect * spd * Time.deltaTime);

        collisionsFlags = _characterController.Move(amount);
    }

    private void BodyRotation()
    {
        Vector3 newForward = _characterController.velocity;
        newForward.y = 0;

        transform.forward = Vector3.Lerp(transform.forward, newForward, 50.0f * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpVelocity.y += Mathf.Sqrt(3f * -3.0f * -9.81f);
        }
        _jumpVelocity.y += _verticalSpd;
        _characterController.Move(_jumpVelocity * Time.deltaTime);
    }

    private void SetGravity()
    {
        if ((collisionsFlags & CollisionFlags.CollidedBelow) != 0)
        {
            _verticalSpd = 0f;
        }
        else
        {
            _verticalSpd -= _gravity * Time.deltaTime;
        }
    }
}
