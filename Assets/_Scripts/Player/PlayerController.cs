using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _turnSpeed = 0.1f;

    private Vector3 _movement;

    private PlayerInput _playerInput;
    private FrameInput _frameInput;

    private Rigidbody _rigidbody; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        TurnPlayer();
    }

    private void GatherInput()
    {
        _frameInput = _playerInput.FrameInput;
        _movement = new Vector3(_frameInput.Move.y, 0, _frameInput.Move.x);
    }

    private void MovePlayer()
    {
        _rigidbody.MovePosition(transform.position + 
            (_movement * _moveSpeed * Time.deltaTime));
    }

    private void TurnPlayer()
    {
        if(_movement.sqrMagnitude > 0.01f) 
        {
            Quaternion rotation = Quaternion.Slerp(_rigidbody.rotation,
                                                  Quaternion.LookRotation(_movement),
                                                  _turnSpeed);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }


}
