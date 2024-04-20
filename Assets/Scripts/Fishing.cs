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
        Debug.Log("Fishing state");
        m_AttachedBehaviour.SetAnimation("Wood");
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_AttachedBehaviour.exitJob();
        }
    }
}
