using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_DodgeState : EnemyDodgeState
{
    Archer archer;

    public Archer_DodgeState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Archer archer) : base(entity, stateMachine, animBoolName)
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

        if (isDodgeOver)
        {
            if (!entity.CheckPlayerInMaxAggraRange())
            {
                stateMachine.ChangState(archer.lookForPlayerState);
            }
            else if(entity.CheckPlayerInMaxAggraRange() && !entity.CheckPlayerInCloseRangeAction())
            {
                stateMachine.ChangState(archer.rangeAttactState);
            }
            else
            {
                stateMachine.ChangState(archer.idleState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
