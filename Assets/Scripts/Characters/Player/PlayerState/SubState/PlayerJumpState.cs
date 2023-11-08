using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;   //Ê£ÓàÌøÔ¾Êý

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
        amountOfJumpsLeft = data.acountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        player.InputHandler.IfUseJumpInput();
        core.Movement.SetVelocityY(data.jumpVelocity);
        isAbilityDone = true;
        amountOfJumpsLeft--;

        player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if(amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = data.acountOfJumps;
    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
