using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGismos : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Vector3 _attackRange;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackPoint.position, _attackRange);
    }
}
