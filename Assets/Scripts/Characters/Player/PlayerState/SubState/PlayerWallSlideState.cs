using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
    }

    public override void LogicalUpdate() 
    {
        base.LogicalUpdate();
        
        if (!isExitingState)
        {
            core.Movement.SetVelocityY(-data.wallSlideVelocity);

            if (ifGrabInput && yInput == 0)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
        }
    }
}
