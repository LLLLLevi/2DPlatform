using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private float velocityToSet;
    private bool isSetVelocity;

    private int xIntput;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isSetVelocity = false;

        weapon.EnterWeapon();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        xIntput = player.InputHandler.NormInputX;

        core.Movement.CheckIfShouldFlip(xIntput);  //攻击过程中可翻转

        if (isSetVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * player.core.Movement.FacingDirection);
        }
    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;

        weapon.InitializeWeapon(this, core);
    }

    public void SetVelocity(float velocity)
    {
        core.Movement.SetVelocityX(velocity * player.core.Movement.FacingDirection);

        velocityToSet = velocity;
        isSetVelocity = true;
    }

    #region Animation Triggers
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }
    #endregion
}
