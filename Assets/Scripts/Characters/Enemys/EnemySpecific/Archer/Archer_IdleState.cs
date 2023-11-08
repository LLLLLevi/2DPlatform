using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_IdleState : EnemyIdleState
{
    Archer archer;
    public Archer_IdleState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Archer archer) : base(entity, stateMachine, animBoolName)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isMinRangDectctedPlayer)
        {
            stateMachine.ChangState(archer.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangState(archer.moveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
