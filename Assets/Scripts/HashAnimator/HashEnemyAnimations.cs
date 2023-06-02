using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashEnemyAnimations : MonoBehaviour
{
    public readonly int Idle = Animator.StringToHash("isIdle");
    public readonly int Brake = Animator.StringToHash("isBrake");
    public readonly int Die = Animator.StringToHash("Die");
}
