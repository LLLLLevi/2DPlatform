using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_PlayerDetectedState : PlayerDetectedState
{
    Boar boar;

    public Boar_PlayerDetectedState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Boar boar) : base(entity, stateMachine, animBoolName)
    {
        this.boar = boar;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)    //攻击范围内
        {
            stateMachine.ChangState(boar.meleeAttackState);
        }
        //检测到玩家且前摇结束 冲锋
        else if (performLongRangeAction)
        {
            stateMachine.ChangState(boar.chargeState);
        }
        else if(!isMaxRangeDectctedPlayer)
        {
            stateMachine.ChangState(boar.lookforPlayerState);   //玩家离开最大范围就开始寻找玩家
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
