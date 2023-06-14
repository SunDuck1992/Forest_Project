using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteractionState : State
{
    protected Player Player { get; private set; }

    public void Init(Player player)
    {
        Player = player;
    }
}
