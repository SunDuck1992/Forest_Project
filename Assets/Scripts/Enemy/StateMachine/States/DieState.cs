using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashEnemyAnimations))]

public class DieState : State
{
    private Animator _animator;
    private HashEnemyAnimations _hashEnemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _hashEnemy = GetComponent<HashEnemyAnimations>();
    }

    private void Start()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        _animator.SetBool(_hashEnemy.Die, true);

        foreach (var current in WaitForSeconds(2f))
        {
            yield return current;
        }

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
}
