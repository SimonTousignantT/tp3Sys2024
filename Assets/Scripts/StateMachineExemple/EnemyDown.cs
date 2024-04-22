using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : EnemyState
{
    public EnemyDown(EnemyBehaviour behaviour) : base(behaviour)
    {
        m_AttachedBehaviour.GetComponent<Renderer>().material.color = Color.black;
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AttachedBehaviour.ChangeState(new EnemyIdle(m_AttachedBehaviour));
        }
    }
}
