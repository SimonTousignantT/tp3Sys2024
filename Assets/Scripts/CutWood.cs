using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWood : PlayerState
{
   
    public CutWood(PlayerBehaviour behaviour) : base(behaviour)
    {

    }
    public override void Execute()
    {
        m_AttachedBehaviour.UiNotify();
        //Debug.Log("cut wood state");
        m_AttachedBehaviour.SetAnimation("Wood");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_AttachedBehaviour.exitJob();
        }
        
    }
    
    
}
