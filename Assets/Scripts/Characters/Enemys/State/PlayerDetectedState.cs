using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyState
{
    protected bool isMinRangeDectctedPlayer;
    protected bool isMaxRangeDectctedPlayer;

    protected bool performLongRangeAction;  //是否开启远程动作(冲锋）：前摇时间到就开启
    protected bool performCloseRangeAction;  //是否开启近程动作（攻击）：射线检测到玩家就开启

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

        //冲锋前摇
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
