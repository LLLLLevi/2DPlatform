using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : EnemyEntity
{
    public Archer_IdleState idleState { get; private set; }
    public Archer_MoveState moveState { get; private set; }
    public Archer_PlayerDetectedState playerDetectedState { get; private set; }
    public Archer_LookForPlayerState lookForPlayerState { get; private set; }
    public Archer_DodgeState dodgeState { get; private set; }
    public Archer_RangeAttactState rangeAttactState { get; private set; }

    [SerializeField] private Transform rangeAttackTransform;

    public override void Awake()
    {
        base.Awake();

        moveState = new Archer_MoveState(this, stateMachine, "move", this);
        idleState = new Archer_IdleState(this, stateMachine, "idle", this);
        playerDetectedState = new Archer_PlayerDetectedState(this, stateMachine, "playerDetected", this);
        lookForPlayerState = new Archer_LookForPlayerState(this, stateMachine, "lookForPlayer", this);
        dodgeState = new Archer_DodgeState(this, stateMachine, "dodge", this);
        rangeAttactState = new Archer_RangeAttactState(this, stateMachine, "rangeAttack", rangeAttackTransform, this);
        
    }

    private void Start()
    {
        stateMachine.Initialize(moveState);     //³õÊ¼ÎªÒÆ¶¯×´Ì¬
    }

    public override void Update()
    {
        base.Update();
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if (rangeAttackTransform && data)
        {
            Gizmos.DrawWireSphere(rangeAttackTransform.position, data.attackRadius);
        }
    }
}
