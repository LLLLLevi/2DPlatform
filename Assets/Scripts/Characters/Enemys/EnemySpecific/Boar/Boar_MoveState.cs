using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar_MoveState : EnemyMoveState
{
    private Boar boar;  

    public Boar_MoveState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Boar boar) : base(entity, stateMachine, animBoolName)
    {
        this.boar = boar;
    }

    public override void Enter()
    {
        base.Enter();

        //entity.Core.Movement.SetVelocityX(entity.data.movementSpeed * entity.Core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //��ҽ���С��Χ���
        if (isMinRangeDectctedPlayer)
        {
            stateMachine.ChangState(boar.playerDetectedState);
        }
        //����⵽ǽ����û��⵽ƽ̨
        else if (entity.Core.CollisionSenses.WallFront || !entity.Core.CollisionSenses.Ledge_Down)
        {
            stateMachine.ChangState(boar.idleState);
            boar.idleState.SetFlipAfterIdle(true);  //��ת����
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
