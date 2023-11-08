using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : EnemyState
{
    protected bool isMinRangeDectctedPlayer;

    protected bool isLedge;
    protected bool isWall;

    protected bool isChargeTimeOver;

    protected bool performCloseRangeAction;  //�Ƿ������̶����������������߼�⵽��ҾͿ���

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
            Debug.Log("ʱ�䵽");
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
