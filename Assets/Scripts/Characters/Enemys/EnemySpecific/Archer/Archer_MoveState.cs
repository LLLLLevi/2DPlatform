using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_MoveState : EnemyMoveState
{
    Archer archer;
    public Archer_MoveState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Archer archer) : base(entity, stateMachine, animBoolName)
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

        //����⵽ǽ����û��⵽ƽ̨
        else if (entity.Core.CollisionSenses.WallFront || !entity.Core.CollisionSenses.Ledge_Down)
        {
            stateMachine.ChangState(archer.idleState);
            archer.idleState.SetFlipAfterIdle(true);  //��ת����
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
