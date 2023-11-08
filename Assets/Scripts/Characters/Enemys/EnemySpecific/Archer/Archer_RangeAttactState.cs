using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_RangeAttactState : EnemyRangeAttackState
{
    Archer archer;
    public Archer_RangeAttactState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, Archer archer) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.archer = archer;
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinshed)
        {
            if (entity.CheckPlayerInMinAggraRange())
            {
                stateMachine.ChangState(archer.playerDetectedState);
            }
            else
            {
                stateMachine.ChangState(archer.lookForPlayerState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
