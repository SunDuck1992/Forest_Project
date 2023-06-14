using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class HealthMushroom : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.GetHeal(_heal);
            Destroy(gameObject);
        }
    }
}
