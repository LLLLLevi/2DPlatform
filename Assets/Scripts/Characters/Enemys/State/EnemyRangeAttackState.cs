using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackState : EnemyAttackState
{
    protected GameObject projectile;
    protected Enemy_Projectile projectileScript;

    public EnemyRangeAttackState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName, attackPosition)
    {
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
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        //Éú³É¹­¼ý
        projectile = GameObject.Instantiate(entity.data.projectile, attackTransform.position, attackTransform.rotation);
        projectileScript = projectile.GetComponent<Enemy_Projectile>();
        projectileScript.FireProjectile(entity.data.projectileSpeed, entity.data.projectileTravelDis);
    }
}
