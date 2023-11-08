using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ƶ�һ��ʱ������վ��״̬
/// </summary>
public class EnemyIdleState : EnemyState
{
    protected bool filpAfterIdle;   //վ��ʱ�Ƿ�Ҫ��ͷ �����ж�����������һ��ʱ���ͣ�»�����Ϊ��⵽ƽ̨��Ե
    protected bool isIdleTimeOver;      //վ��ʱ�䵽

    protected float idleTime;   //վ��ʱ��

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

        entity.Core.Movement.SetVelocityX(0f);     //�ٶ����

        SetRamdomIdleTime();
        isIdleTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();

        if (filpAfterIdle)
        {
            entity.Core.Movement.Flip();    //��ת����
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(0f);      //�ٶ����

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

    //�������վ��ʱ��
    protected void SetRamdomIdleTime()
    {
        idleTime = Random.Range(entity.data.minIdleTime, entity.data.maxIdleTime);
    }
}
