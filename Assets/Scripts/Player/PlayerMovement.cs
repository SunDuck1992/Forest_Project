using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashPlayerAnimations))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private const string HorizontalDirection = "Horizontal";
    private const string VerticalDirection = "Vertical";

    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool _isFaceRight = true;
    private bool _isGround;
    private HashPlayerAnimations _hashPlayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _hashPlayer = GetComponent<HashPlayerAnimations>();
    }

    private void Update()
    {
        TryJump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xDirection = Input.GetAxisRaw(HorizontalDirection);
        float zDirection = Input.GetAxisRaw(VerticalDirection);

        Vector3 movement = new Vector3(xDirection, 0, zDirection);

        transform.Translate(movement * _speed * Time.deltaTime);

        if (xDirection != 0 || zDirection != 0)
        {
            _animator.SetBool(_hashPlayer.Run, true);
        }
        else
        {
            _animator.SetBool(_hashPlayer.Run, false);
        }

        if (xDirection > 0 && !_isFaceRight)
        {
            Flip();
        }

        if (xDirection < 0 && _isFaceRight)
        {
            Flip();
        }
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }

        if (!_isGround)
        {
            _animator.SetBool(_hashPlayer.Jump, true);
        }
        else
        {
            _animator.SetBool(_hashPlayer.Jump, false);
        }
    }

    private void Flip()
    {
        _isFaceRight = !_isFaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            _isGround = value;
        }
    }
}
