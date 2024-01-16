using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    public MovementState(Entity etity, FiniteStateMachine stateMachine, string animBoolName) : base(etity, stateMachine, animBoolName)
    {
        this.entity = etity;
        this.animBoolName = animBoolName;
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);

    }

}
