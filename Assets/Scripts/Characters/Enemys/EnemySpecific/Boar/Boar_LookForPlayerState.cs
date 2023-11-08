using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_LookForPlayerState : LookForPlayerState
{
    Boar boar;
    public Boar_LookForPlayerState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Boar boar) : base(entity, stateMachine, animBoolName)
    {
        this.boar = boar;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isMinRangeDectctedPlayer)
        {
            stateMachine.ChangState(boar.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangState(boar.moveState);    //转完身也没找到玩家就恢复移动状态
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
