using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeState : EnemyState
{
    protected bool isDodgeOver;

    public EnemyDodgeState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        isDodgeOver = false;

        entity.Core.Movement.SetVelocity(entity.data.dodgeSpeed, entity.data.dodgeAngle, -entity.Core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + entity.data.dodgeTime && entity.Core.CollisionSenses.Ground)
        {
            isDodgeOver = true;     
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
