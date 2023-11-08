using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform attackTransform;
    protected bool isAnimationFinshed;

    public EnemyAttackState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackTransform = attackPosition;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;     //赋值给转接脚本
        isAnimationFinshed = false;
        entity.Core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(0f);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public virtual void TriggerAttack()
    {

    }
    public virtual void FinishAttack()
    {
        isAnimationFinshed = true;
    }
}
