using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController _characterController;
    private CollisionFlags collisionsFlags = CollisionFlags.None;

    [SerializeField] private float _walkSpd = 2.0f;
    [SerializeField] private float _runSpd = 5.0f;

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
        SetGravity();
    }

    private void Move()
    {
        //���� ����
        Transform cameraTransform = Camera.main.transform;
        //����ī�޶� �ٶ󺸴� ������ ����󿡼� � �����ΰ�
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

        if (Input.GetButtonDown("Jump"))
        {
            _jumpVelocity.y += Mathf.Sqrt(3f * -3.0f * -9.81f);
        }
        _jumpVelocity.y += _verticalSpd;
        _characterController.Move(_jumpVelocity * Time.deltaTime);

        collisionsFlags = _characterController.Move(amount);
    }

    private void BodyRotation()
    {
        Vector3 newForward = _characterController.velocity;
        newForward.y = 0;

        transform.forward = Vector3.Lerp(transform.forward, newForward, 50.0f * Time.deltaTime);
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
