using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }
    private bool isHolding;
    private bool dashInputStop;

    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName) : base(player, stateMachine, data, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        player.InputHandler.IfUseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * player.core.Movement.FacingDirection;

        Time.timeScale = data.holdTimeScale;    //慢放
        startTime = Time.unscaledTime;      //未修改时间缩放的时间

        player.DashDirectionIndicator.gameObject.SetActive(true);   //显示冲刺箭头
    }

    public override void Exit()
    {
        base.Exit();

        if(core.Movement.CurrentVelocity.y > 0f)
        {
            core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * data.dashEndYMultipliter);
        }
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();

        if (!isExitingState)
        {
            player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));
            player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);

            if (isHolding)
            {
                dashDirectionInput = player.InputHandler.DashDirectionInput;
                dashInputStop = player.InputHandler.IfDashInputStop;

                if(dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                if(dashInputStop || Time.unscaledTime >= startTime + data.maxHoldTime)
                {
                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;

                    core.Movement.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = data.drag;
                    core.Movement.SetVelocity(data.dashVelocity, dashDirection);

                    player.DashDirectionIndicator.gameObject.SetActive(false);
                }
            }
            else
            {
                core.Movement.SetVelocity(data.dashVelocity, dashDirection);

                if(Time.time >= startTime + data.dashTime)
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }


    public bool CheckifCanDash()
    {
        if(CanDash && Time.time >= lastDashTime + data.dashCoolDown)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetCanDash() => CanDash = true;

}
