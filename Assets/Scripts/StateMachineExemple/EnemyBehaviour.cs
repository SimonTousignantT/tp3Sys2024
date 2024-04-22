using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyState m_CurrentState;

    void Start()
    {
        m_CurrentState = new EnemyIdle(this);
    }

    public void ChangeState(EnemyState newState)
    {
        m_CurrentState = newState;
    }

    private void Update()
    {
        m_CurrentState.Execute();
    }

   
}
