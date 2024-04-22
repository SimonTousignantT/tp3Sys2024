using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : PlayerState
{
    public Fishing(PlayerBehaviour behaviour) : base(behaviour)
    {

    }
    public override void Execute()
    {
        //Debug.Log("Fishing state");
        m_AttachedBehaviour.UiNotify();
        m_AttachedBehaviour.SetAnimation("Water");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            m_AttachedBehaviour.exitJob();
        }
    }
}
