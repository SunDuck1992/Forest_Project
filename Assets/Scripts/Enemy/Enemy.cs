using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashEnemyAnimations))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _timeBeforeAttack;
    [SerializeField] private float _delayAfterTakeDamage;

    private IEnumerable _currentState;
    private int _currentHealth;
    private bool _isFaceRight = false;
    private Animator _animator;
    private Player _target;
    private HashEnemyAnimations _hashEnemy;

    public Player Target => _target;

    private void Awake()
    {
         Player player = FindObjectOfType<Player>();
        _target = player;
        _hashEnemy = GetComponent<HashEnemyAnimations>();
        _currentState = Following();
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
        _animator = GetComponent<Animator>();
        StartCoroutine(StateMachine());
    }


    private void Start()
    {
        _currentHealth = _health;
    }

    private IEnumerator StateMachine()
    {
        while (_currentState != null)
        {
            foreach (var current in _currentState)
            {
                yield return current;
            }
        }
    }

    private IEnumerable Following()
    {
        while (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < _transitionRange)
            {
                _currentState = Attacking();
                yield break;
            }

            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

            if (_target.transform.position.x > transform.position.x && !_isFaceRight)
            {
                Flip();
            }

            if (_target.transform.position.x < transform.position.x && _isFaceRight)
            {
                Flip();
            }

            yield return null;
        }
    }

    private IEnumerable Attacking()
    {
        _animator.SetBool(_hashEnemy.Idle, true);

        foreach (var current in WaitForSeconds(_timeBeforeAttack))
        {
            yield return current;
        }

        while (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) > _transitionRange)
            {
                _currentState = Following();
                _animator.SetBool(_hashEnemy.Brake, false);
                _animator.SetBool(_hashEnemy.Idle, false);
                yield break;
            }

            if(_health <= 0)
            {
                _currentState = Dieing();
                yield break;
            }

            if (_currentHealth > _health)
            {
                foreach (var current in WaitForSeconds(_delayAfterTakeDamage))
                {
                    yield return current;
                }
            }

            Attack(_target);

            foreach (var current in WaitForSeconds(_attackDelay))
            {
                yield return current;
            }
        }
    }

    private IEnumerable Dieing()
    {
        _animator.Play(_hashEnemy.Die);

        foreach (var current in WaitForSeconds(3f))
        {
            yield return current;
        }

        _target = null;

        Destroy(gameObject);
    }

    private IEnumerable WaitForSeconds(float time)
    {
        var estimatedTime = 0f;

        while (estimatedTime < time)
        {
            estimatedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void Attack(Player target)
    {
        _animator.SetBool(_hashEnemy.Brake, true);

        target.ApplyDamage(_damage);
    }

    private void Flip()
    {
        _isFaceRight = !_isFaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;      
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
