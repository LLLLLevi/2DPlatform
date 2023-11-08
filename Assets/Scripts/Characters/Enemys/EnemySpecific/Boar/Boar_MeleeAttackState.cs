using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_MeleeAttackState : EnemyMeleeAttackState
{
    Boar boar;

    public Boar_MeleeAttackState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, Boar boar) 
        : base(entity, stateMachine, animBoolName, attackPosition)
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

        //Íê³É¹¥»÷¶¯»­
        if (isAnimationFinshed)
        {
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
