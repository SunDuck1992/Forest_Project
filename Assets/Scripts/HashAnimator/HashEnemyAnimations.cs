using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashEnemyAnimations : MonoBehaviour
{
    public readonly int Brake = Animator.StringToHash("isBrake");
    public readonly int Die = Animator.StringToHash("isDie");
    public readonly int Walk = Animator.StringToHash("isWalk");
}
