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
        m_AttachedBehaviour.exitJob();
    }
    
    
}
