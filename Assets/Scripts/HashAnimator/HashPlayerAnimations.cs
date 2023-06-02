using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashPlayerAnimations : MonoBehaviour
{
    public readonly int Run = Animator.StringToHash("isRun");
    public readonly int Jump = Animator.StringToHash("isJump");
    public readonly int Attack = Animator.StringToHash("attack");
}
