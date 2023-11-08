using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ұ���̳л��������� ʵ����Ұ��ĸ���״̬��
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

        //��һ��this�ǳ����enemyEntity �ڶ���this��Ұ�� �ھ������� �ڶ��������˵�һ��
        moveState = new Boar_MoveState(this, stateMachine, "move", this);   
        idleState = new Boar_IdleState(this, stateMachine, "idle", this);
        playerDetectedState = new Boar_PlayerDetectedState(this, stateMachine, "playerDetected", this);
        chargeState = new Boar_ChargeState(this, stateMachine, "charge", this);
        lookforPlayerState = new Boar_LookForPlayerState(this, stateMachine, "lookForPlayer", this);
        meleeAttackState = new Boar_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackTransform,this);
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);     //��ʼΪ�ƶ�״̬
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
