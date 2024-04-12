using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyBehaviour m_AttachedBehaviour;

    public EnemyState(EnemyBehaviour behaviour)
    {
        m_AttachedBehaviour = behaviour;
    }

    public abstract void Execute();
    
}
