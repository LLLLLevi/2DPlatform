using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyState
{
    protected bool isMinRangeDectctedPlayer;
    protected bool isMaxRangeDectctedPlayer;

    protected bool performLongRangeAction;  //�Ƿ���Զ�̶���(��棩��ǰҡʱ�䵽�Ϳ���
    protected bool performCloseRangeAction;  //�Ƿ������̶����������������߼�⵽��ҾͿ���

    public PlayerDetectedState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isMinRangeDectctedPlayer = entity.CheckPlayerInMinAggraRange();
        isMaxRangeDectctedPlayer = entity.CheckPlayerInMaxAggraRange();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
        entity.Core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(0f);

        //���ǰҡ
        if (Time.time > startTime + entity.data.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
