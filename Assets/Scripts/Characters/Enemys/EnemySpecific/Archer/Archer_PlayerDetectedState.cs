using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_PlayerDetectedState : PlayerDetectedState
{
    Archer archer;
    public Archer_PlayerDetectedState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Archer archer) : base(entity, stateMachine, animBoolName)
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

        if (entity.CheckPlayerInCloseRangeAction())
        {
            if (Time.time >= archer.dodgeState.startTime + entity.data.dodgeCooldown)
            {
                stateMachine.ChangState(archer.dodgeState);
            }
        }
        else if (performLongRangeAction)
        {
            stateMachine.ChangState(archer.rangeAttactState);
        }

        else if (!isMaxRangeDectctedPlayer)
        {
            stateMachine.ChangState(archer.lookForPlayerState);   //玩家离开最大范围就开始寻找玩家
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
