using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashEnemyAnimations))]

public class AttackState : PlayerInteractionState
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private float _transitionRange;

    private Animator _animator;
    private HashEnemyAnimations _hashEnemy;
    private float _lastTime;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _hashEnemy = GetComponent<HashEnemyAnimations>();
    }

    private void Update()
    {
        Attack(Player);
    }

    private void OnDisable()
    {
        _animator.SetBool(_hashEnemy.Brake, false);
    }

    private void Attack(Player target)
    {
        if (_lastTime > _delay)
        {
            _animator.SetBool(_hashEnemy.Brake, true);
            target.ApplyDamage(_damage);
            _lastTime = 0;
        }

        _lastTime += Time.deltaTime;
    }
}
