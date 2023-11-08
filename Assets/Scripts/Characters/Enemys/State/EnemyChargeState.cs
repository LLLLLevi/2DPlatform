using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected bool isMinRangeDectctedPlayer;

    protected bool isLedge;
    protected bool isWall;

    protected bool isChargeTimeOver;

    protected bool performCloseRangeAction;  //是否开启近程动作（攻击）：射线检测到玩家就开启

    public EnemyChargeState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isMinRangeDectctedPlayer = entity.CheckPlayerInMinAggraRange();
        isLedge = entity.Core.CollisionSenses.Ledge;
        isWall = entity.Core.CollisionSenses.WallFront;

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction(); 
    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        entity.Core.Movement.SetVelocityX(entity.data.chargeSpeed * entity.Core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(entity.data.chargeSpeed * entity.Core.Movement.FacingDirection);

        if (Time.time > startTime + entity.data.chargeTime)
        {
            isChargeTimeOver = true;
            Debug.Log("时间到");
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
