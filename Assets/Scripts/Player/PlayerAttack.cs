using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashPlayerAnimations))]

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private Vector3 _attackRange;
    [SerializeField] private LayerMask _layerEnemy;

    private Animator _animator;
    private HashPlayerAnimations _hashPlayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _hashPlayer = GetComponent<HashPlayerAnimations>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (HandleInput())
        {
            _animator.SetTrigger(_hashPlayer.Attack);
        }
    }

    private bool HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return true;
        }

        return false;
    }

    private void PlayerAttacking()
    {
        Collider[] enemiesToDamage = Physics.OverlapBox(_attackPosition.position, _attackRange, Quaternion.identity, _layerEnemy);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(_damage);
        }
    }
}
