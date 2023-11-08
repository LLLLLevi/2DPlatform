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
            stateMachine.ChangState(boar.moveState);    //ת����Ҳû�ҵ���Ҿͻָ��ƶ�״̬
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
