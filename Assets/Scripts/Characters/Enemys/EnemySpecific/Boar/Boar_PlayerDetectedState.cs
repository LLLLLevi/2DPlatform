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

        if (performCloseRangeAction)    //������Χ��
        {
            stateMachine.ChangState(boar.meleeAttackState);
        }
        //��⵽�����ǰҡ���� ���
        else if (performLongRangeAction)
        {
            stateMachine.ChangState(boar.chargeState);
        }
        else if(!isMaxRangeDectctedPlayer)
        {
            stateMachine.ChangState(boar.lookforPlayerState);   //����뿪���Χ�Ϳ�ʼѰ�����
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
