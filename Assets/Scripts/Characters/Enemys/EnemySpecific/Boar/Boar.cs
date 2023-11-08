using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 野猪：继承基础敌人类 实例化野猪的各种状态类
/// </summary>
public class Boar : EnemyEntity
{
    public Boar_IdleState idleState { get; private set; }
    public Boar_MoveState moveState { get; private set; }
    public Boar_PlayerDetectedState playerDetectedState { get; private set; }
    public Boar_ChargeState chargeState{ get; private set; }
    public Boar_LookForPlayerState lookforPlayerState{ get; private set; }
    public Boar_MeleeAttackState meleeAttackState{ get; private set; }

    [SerializeField] private Transform meleeAttackTransform;

    public override void Awake()
    {
        base.Awake();

        //第一个this是抽象的enemyEntity 第二个this是野猪 在具体类中 第二个覆盖了第一个
        moveState = new Boar_MoveState(this, stateMachine, "move", this);   
        idleState = new Boar_IdleState(this, stateMachine, "idle", this);
        playerDetectedState = new Boar_PlayerDetectedState(this, stateMachine, "playerDetected", this);
        chargeState = new Boar_ChargeState(this, stateMachine, "charge", this);
        lookforPlayerState = new Boar_LookForPlayerState(this, stateMachine, "lookForPlayer", this);
        meleeAttackState = new Boar_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackTransform,this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);     //初始为移动状态
    }

    public override void Update()
    {
        base.Update();
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackTransform.position, data.attackRadius);
    }
}
