using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;

    public event Action<State> Finished;

    public void Enter()
    {
        enabled = true;

        foreach (Transition transition in _transitions)
        {
            transition.Triggered += OnTriggered;
            transition.enabled = true;
        }
    }

    public void Exit()
    {
        foreach (Transition transition in _transitions)
        {
            transition.Triggered -= OnTriggered;
            transition.enabled = false;
        }

        enabled = false;
    }

    private void OnTriggered(State next)
    {
        Finished?.Invoke(next);
    }
}
