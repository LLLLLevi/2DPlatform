using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    //input
    private int xInput;
    private bool ifJumpInput;
    private bool ifJumpInputStop;
    private bool grabInput;
    private bool dashInput;


    //checks
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool oldIsTouchingWall;
    private bool oldIsTouchingWallBack;
    private bool isTouchingLedge;

    //other
    private bool ifWallJumpCoyoteTime;
    private bool ifCoyoteTime;
    private bool isJumping;

    private float startWallJumpCoyoteTime;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        oldIsTouchingWall = isTouchingWall;
        oldIsTouchingWallBack = isTouchingWallBack;

        isGrounded = core.CollisionSenses.Ground;
        isTouchingWall = core.CollisionSenses.WallFront;
        isTouchingWallBack = core.CollisionSenses.WallBack;
        isTouchingLedge = core.CollisionSenses.Ledge;

        if(!ifWallJumpCoyoteTime && !isTouchingWall && !isTouchingWallBack &&
            (oldIsTouchingWall || oldIsTouchingWallBack))
        {
            StartWallJumpCoyoteTime();
        }

        //保存预备攀台的位置
        if(isTouchingWall && !isTouchingLedge)
        {
            player.LedgeClimbState.SetDetectedPos(player.transform.position);
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        isTouchingWall = false;
        isTouchingWallBack = false;
        oldIsTouchingWall = false;
        oldIsTouchingWallBack = false;
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        CheckCoyoteTime();
        CheckWallJumpCoyoteTime();

        xInput = player.InputHandler.NormInputX;
        ifJumpInput = player.InputHandler.IfJumpInput;
        ifJumpInputStop = player.InputHandler.IfJumpInputStop;
        dashInput = player.InputHandler.IfDashInput;

        CheckJumpMultiplier();

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondAttackState);
        }
        else if (isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (isTouchingWall && !isTouchingLedge && !isGrounded)
        {
            stateMachine.ChangeState(player.LedgeClimbState);
        }
        else if(ifJumpInput && (isTouchingWall || isTouchingWallBack || ifWallJumpCoyoteTime))
        {
            StopWallJumpCoyoteTime();
            isTouchingWall = core.CollisionSenses.WallFront;
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (ifJumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (grabInput && isTouchingWall && isTouchingLedge)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if(isTouchingWall && xInput == core.Movement.FacingDirection
            && core.Movement.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else if(dashInput && player.DashState.CheckifCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        //空中移动
        else
        {
            core.Movement.CheckIfShouldFlip(xInput);
            core.Movement.SetVelocityX(data.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //土狼时间
    public void StartCoyoteTime() => ifCoyoteTime = true;
    public void StartWallJumpCoyoteTime()
    {
        ifWallJumpCoyoteTime = true;
        startWallJumpCoyoteTime = Time.time;
    }
    public void StopWallJumpCoyoteTime() => ifWallJumpCoyoteTime = false;
    public void SetIsJumping() => isJumping = true;

    public void CheckCoyoteTime()
    {
        if(ifCoyoteTime && Time.time > startTime + data.coyoteTime)
        {
            ifCoyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void CheckWallJumpCoyoteTime()
    {
        if (ifWallJumpCoyoteTime && Time.time > startWallJumpCoyoteTime + data.coyoteTime)
        {
            ifWallJumpCoyoteTime = false;
        }
    }

    private void CheckJumpMultiplier()
    {
        //跳跃中松开跳跃键
        if (isJumping)
        {
            if (ifJumpInputStop)
            {
                core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * data.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (core.Movement.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }
}
