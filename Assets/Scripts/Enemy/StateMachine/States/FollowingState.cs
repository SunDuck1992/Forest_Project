using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HashEnemyAnimations))]
[RequireComponent(typeof(Animator))]

public class FollowingState : PlayerInteractionState
{
    [SerializeField] private int _speed;

    private Animator _animator;
    private HashEnemyAnimations _hashEnemy;   
    private bool _isFaceRight = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _hashEnemy = GetComponent<HashEnemyAnimations>();
    }

    private void Update()
    {
        Follow();
    }

    private void OnDisable()
    {
        _animator.SetBool(_hashEnemy.Walk, false);
    }

    private void Follow()
    {
        _animator.SetBool(_hashEnemy.Walk, true);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, _speed * Time.deltaTime);

        if (Player.transform.position.x > transform.position.x && !_isFaceRight)
        {
            Flip();
        }

        if (Player.transform.position.x < transform.position.x && _isFaceRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFaceRight = !_isFaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
