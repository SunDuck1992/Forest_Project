using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _target;

    public event Action<State> Triggered;

    protected State Target => _target;

    protected void Trigger()
    {
        Triggered?.Invoke(_target);
    }
}
