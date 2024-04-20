using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveState : PlayerState
{
 
    public PlayerMoveState(PlayerBehaviour behaviour) : base(behaviour)
    {

    }
    public override void Execute()
    {
        Debug.Log("Move state");
        if (Input.GetKey(KeyCode.W))
        {
            m_AttachedBehaviour.SetAnimation("Move");
            m_AttachedBehaviour.MoveForward(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_AttachedBehaviour.SetAnimation("Move");
            m_AttachedBehaviour.MoveForward(true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_AttachedBehaviour.RotatePlayer(false);

        }
        if (Input.GetKey(KeyCode.D))
        {
            m_AttachedBehaviour.RotatePlayer(true);
        }
        
    }
    
}