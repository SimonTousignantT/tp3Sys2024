using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : EnemyState
{
    public EnemyPatrolling(EnemyBehaviour behaviour) : base(behaviour)
    {
        m_AttachedBehaviour.GetComponent<Renderer>().material.color = Color.red;
    }

    public override void Execute()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehaviour.ChangeState(new EnemyDown(m_AttachedBehaviour));
        }

    }
}
