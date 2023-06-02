using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class HealthMushroom : MonoBehaviour
{
    [SerializeField] private int _heal;

    private Player player;
    //[SerializeField] private Player _player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            player.GetHeal(_heal);
            Destroy(gameObject);
        }
    }
}
