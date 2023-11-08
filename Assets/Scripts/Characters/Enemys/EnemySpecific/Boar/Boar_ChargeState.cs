using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_ChargeState : EnemyChargeState
{
    Boar boar;

    public Boar_ChargeState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Boar boar) : base(entity, stateMachine, animBoolName)
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
        else if ((!entity.Core.CollisionSenses.Ledge_Down) || entity.Core.CollisionSenses.WallFront)
        {
            stateMachine.ChangState(boar.lookforPlayerState);
        }
        //����ʱ��
        else if (isChargeTimeOver)
        {
            Debug.Log("���ʱ�䵽");
            
            if (isMinRangeDectctedPlayer)
            {
                stateMachine.ChangState(boar.playerDetectedState);
            }
            else
            {
                stateMachine.ChangState(boar.lookforPlayerState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
