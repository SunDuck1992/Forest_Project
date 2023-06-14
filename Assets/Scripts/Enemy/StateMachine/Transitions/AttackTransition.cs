using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : PlayerInteractionTransition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _transitionRange)
        {
            Trigger(_player);
        }
    }
}
