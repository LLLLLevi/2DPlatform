using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动一段时间后进入站立状态
/// </summary>
public class EnemyIdleState : EnemyState
{
    protected bool filpAfterIdle;   //站立时是否要掉头 用于判断是由于走了一段时间而停下还是因为检测到平台边缘
    protected bool isIdleTimeOver;      //站立时间到

    protected float idleTime;   //站立时间

    protected bool isMinRangDectctedPlayer;

    public EnemyIdleState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isMinRangDectctedPlayer = entity.CheckPlayerInMinAggraRange();
    }

    public override void Enter()
    {
        base.Enter();

        entity.Core.Movement.SetVelocityX(0f);     //速度清空

        SetRamdomIdleTime();
        isIdleTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();

        if (filpAfterIdle)
        {
            entity.Core.Movement.Flip();    //反转朝向
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(0f);      //速度清空

        if (Time.time > startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        filpAfterIdle = flip;
    }

    //设置随机站立时间
    protected void SetRamdomIdleTime()
    {
        idleTime = Random.Range(entity.data.minIdleTime, entity.data.maxIdleTime);
    }
}
