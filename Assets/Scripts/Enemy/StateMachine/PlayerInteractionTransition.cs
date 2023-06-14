using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractionTransition : Transition
{
    protected void Trigger(Player player)
    {
        if (Target is PlayerInteractionState state)
        {
            state.Init(player);
            Trigger();
        }
        else
        {
            throw new InvalidOperationException("Not correct state");
        }
    }
}
