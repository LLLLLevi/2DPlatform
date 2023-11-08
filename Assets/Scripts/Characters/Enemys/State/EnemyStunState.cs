using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunState : EnemyState
{
    protected bool isStunTimeOver;
    protected bool isGrounded;
    protected bool isMovementStopped;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;

    public EnemyStunState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isGrounded = entity.Core.CollisionSenses.Ground;
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAggraRange();
    }

    public override void Enter()
    {
        base.Enter();

        isStunTimeOver = false;
        isMovementStopped = false;

        entity.Core.Movement.SetVelocity(entity.data.stunKnockbackSpeed,
            entity.data.stunKnockbackAngle, entity.Core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
        //entity.ResetStunResistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + entity.data.stunTime)
        {
            isStunTimeOver = true;
        }

        if(isGrounded && Time.time >= startTime + entity.data.stunKnockbackTime && !isMovementStopped)    //击飞时间过了且触碰到地面
        {
            isMovementStopped = true;
            entity.Core.Movement.SetVelocityX(0f);      //防止在地面滑动
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
