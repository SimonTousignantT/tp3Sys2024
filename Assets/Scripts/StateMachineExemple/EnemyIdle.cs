using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(EnemyBehaviour behaviour) : base(behaviour)
    {
        m_AttachedBehaviour.GetComponent<Renderer>().material.color = Color.blue;

        m_AttachedBehaviour.StartCoroutine(IdleCoroutine());
    }

    public override void Execute()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        //Déplacer mon personnage
    }

    private IEnumerator IdleCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        m_AttachedBehaviour.ChangeState(new EnemyPatrolling(m_AttachedBehaviour));
    }
}
