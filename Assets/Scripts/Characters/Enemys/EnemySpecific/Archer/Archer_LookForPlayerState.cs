using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_LookForPlayerState : LookForPlayerState
{
    Archer archer;

    public Archer_LookForPlayerState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Archer archer) : base(entity, stateMachine, animBoolName)
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

        if (isMinRangeDectctedPlayer)
        {
            stateMachine.ChangState(archer.playerDetectedState);
        }
        else if (isAllTurnsDone)
        {
            stateMachine.ChangState(archer.moveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
