using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// 向前移动直到碰到墙或者平台边缘
/// </summary>
public class EnemyMoveState : EnemyState
{
    //记录是否检测到平台边缘或者墙
    protected bool isDetecLegde;    
    protected bool isDetecWall;

    protected bool isMinRangeDectctedPlayer;

    public EnemyMoveState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isDetecLegde = entity.Core.CollisionSenses.Ledge_Down;
        isDetecWall = entity.Core.CollisionSenses.WallFront;
        isMinRangeDectctedPlayer = entity.CheckPlayerInMinAggraRange();
    }

    public override void Enter()
    {
        base.Enter();

        entity.Core.Movement.SetVelocityX(entity.data.movementSpeed * entity.Core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(entity.data.movementSpeed * entity.Core.Movement.FacingDirection);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        isDetecLegde = entity.Core.CollisionSenses.Ledge_Down;
        isDetecWall = entity.Core.CollisionSenses.WallFront;
    }
}
