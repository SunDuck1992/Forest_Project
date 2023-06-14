using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _current;

    private void OnEnable()
    {
        _current.Enter();
        _current.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _current.Finished -= OnFinished;
        _current.Exit();
    }

    private void OnFinished(State next)
    {
        _current.Finished -= OnFinished;
        _current.Exit();

        _current = next;
        _current.Enter();
        _current.Finished += OnFinished;
    }
}
