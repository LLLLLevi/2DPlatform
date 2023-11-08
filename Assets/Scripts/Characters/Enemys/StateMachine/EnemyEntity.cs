using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

/// <summary>
/// 所有敌人都将继承该实体类 该类用于存放每个敌人都拥有的特性
/// </summary>
public class EnemyEntity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    [SerializeField] public Data_Enemy data;

    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public Core Core { get; private set; }

    [SerializeField] private Transform playerCheckTran;     //挂在敌人身上 用用检测玩家位置的 点位 不是玩家的位置

    public AnimationToStateMachine atsm{ get; private set; }

    public virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Core = GetComponentInChildren<Core>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();    //状态机不挂载在任何物体上 所以直接生成即可
    }

    public virtual void Update()
    {
        Core.LogicUpdate();

        stateMachine.CurrentState.LogicUpdate();    //实时调用状态的更新函数

        Anim.SetFloat("yVelocity", RB.velocity.y);
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicUpdate();    //实时调用状态的物理更新函数
    }

    //绘制在Unity scence中可视的线 便于查看碰撞检测是否正常:要进行非空检测 因为在编译阶段游戏没开始则未实例化Core
    public virtual void OnDrawGizmos()
    {
        if(Core != null)    //当游戏未运行时 awake函数没被调用 所以core未实例化 此时会报错
        {
            Gizmos.DrawLine(Core.CollisionSenses.WallCheckTrans.position, Core.CollisionSenses.WallCheckTrans.position +
               (Vector3)(Vector2.right * Core.Movement.FacingDirection * Core.CollisionSenses.WallCheckDistence));
            Gizmos.DrawLine(Core.CollisionSenses.LedgeCheckTrans.position, Core.CollisionSenses.LedgeCheckTrans.position +
                (Vector3)(Vector2.down * Core.CollisionSenses.LedgeCheckDistence));
            Gizmos.DrawWireSphere(playerCheckTran.position + (Vector3)(transform.right * data.closeRangeActionDis), 0.2f);
            Gizmos.DrawWireSphere(playerCheckTran.position + (Vector3)(transform.right * data.minAggrDistence), 0.2f);
            Gizmos.DrawWireSphere(playerCheckTran.position + (Vector3)(transform.right * data.maxAggrDistence), 0.2f);
        }
    }

    //受击小跳
    public virtual void DamageHop(float velocity)
    {
        Core.Movement.SetVelocityY(velocity); 
    }

    public void DamageHit(Collider2D damageHit)
    {
        Debug.Log("进入扣血");

        IDamageable damageable = damageHit.GetComponentInChildren<IDamageable>();
        Debug.Log("damageable = " + damageable);

        if (damageable != null)
        {
            Debug.Log("扣血");
            damageable.Damage(data.projectileDamage);
        }

        IKnockbackable knockbackable = damageHit.GetComponentInChildren<IKnockbackable>();
        if (knockbackable != null)
        {
            knockbackable.Knocback(data.knockbackAngle, data.knockbackStrength,
                Core.Movement.FacingDirection);
        }
    }

    //小范围检测玩家
    public virtual bool CheckPlayerInMinAggraRange()
    {
        return Physics2D.Raycast(playerCheckTran.position, 
            transform.right, data.minAggrDistence, data.whatIsPlayer);
    }
    //大范围检测玩家
    public virtual bool CheckPlayerInMaxAggraRange()
    {
        return Physics2D.Raycast(playerCheckTran.position,
            transform.right, data.maxAggrDistence, data.whatIsPlayer);
    }
    //检测玩家是否咋在进程攻击范围内
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheckTran.position, transform.right,
            data.closeRangeActionDis, data.whatIsPlayer);
    }
}
