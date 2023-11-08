using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    //protected EnemyAttackDetails attackDetails;

    protected bool isMinRangeDectctedPlayer;

    public EnemyMeleeAttackState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName, attackPosition)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isMinRangeDectctedPlayer = entity.CheckPlayerInMinAggraRange();
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

        //用碰撞体数组存储物理圆碰撞到的物体
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll
            (attackTransform.position, entity.data.attackRadius, entity.data.whatIsPlayer);

        foreach(Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if(damageable != null)
            {
                damageable.Damage(entity.data.attackDamage);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if(knockbackable != null)
            {
                knockbackable.Knocback(entity.data.knockbackAngle, entity.data.knockbackStrength,
                    entity.Core.Movement.FacingDirection);
            }
        }
    }
}
