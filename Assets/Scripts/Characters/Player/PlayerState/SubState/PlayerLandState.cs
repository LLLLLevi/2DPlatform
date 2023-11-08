using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
    }
    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
