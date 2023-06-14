using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
