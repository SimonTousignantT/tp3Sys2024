using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState 
{
    protected PlayerBehaviour m_AttachedBehaviour;
    public PlayerState(PlayerBehaviour behaviour)
    {
        m_AttachedBehaviour = behaviour;
    }
    public abstract void Execute();
    

}
