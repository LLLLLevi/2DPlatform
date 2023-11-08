using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPos;
    private Vector2 cornerdPos;
    private Vector2 startPos;
    private Vector2 stopPos;
    private Vector2 workSpace;

    private bool isHanging;
    private bool isClimbing;
    private bool jumpInput;

    private int xIntput;
    private int yIntput;

    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
        player.transform.position = detectedPos;

        cornerdPos = DetemineCornerPosition();

        startPos.Set(cornerdPos.x - (core.Movement.FacingDirection * data.startOffset.x),
            cornerdPos.y - data.startOffset.y);
        stopPos.Set(cornerdPos.x + (core.Movement.FacingDirection * data.stopOffset.x),
            cornerdPos.y + data.stopOffset.y);

        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();

        isHanging = false;

        if (isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            core.Movement.SetVelocityZero();
            player.transform.position = startPos;

            xIntput = player.InputHandler.NormInputX;
            yIntput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.IfJumpInput;

            if (xIntput == core.Movement.FacingDirection && isHanging && !isClimbing)
            {
                isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if (yIntput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else if(jumpInput && !isClimbing)
            {
                player.WallJumpState.DetermineWallJumpDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }
        }
    }

    public void SetDetectedPos(Vector2 pos) => detectedPos = pos;

    private Vector2 DetemineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(core.CollisionSenses.WallCheckTrans.position,
            Vector2.right * core.Movement.FacingDirection, core.CollisionSenses.WallCheckDistence, core.CollisionSenses.WhatIsGround);
        float xDist = xHit.distance;

        workSpace.Set((xDist + 0.015f) * core.Movement.FacingDirection, 0f);

        RaycastHit2D yHit = Physics2D.Raycast(core.CollisionSenses.LedgeCheckTrans.position + (Vector3)(workSpace),
            Vector2.down, core.CollisionSenses.LedgeCheckTrans.position.y - core.CollisionSenses.WallCheckTrans.position.y + 0.015f, core.CollisionSenses.WhatIsGround);
        float yDist = yHit.distance;

        workSpace.Set(core.CollisionSenses.WallCheckTrans.position.x + (xDist * core.Movement.FacingDirection),
            core.CollisionSenses.LedgeCheckTrans.position.y - yDist);

        return workSpace;
    }
}
