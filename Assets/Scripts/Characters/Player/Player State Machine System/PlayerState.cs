using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Core core;

    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData data;
    protected PlayerInputHandler input;

    protected float startTime;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    private string animBoolName;

    //¹¹Ôìº¯Êý
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.data = data;
        this.animBoolName = animBoolName;
        core = player.core;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;

        isAnimationFinished = false;
        isExitingState = false;
        
    } 
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);

        isExitingState = true;
    } 
    public virtual void LogicalUpdate()
    {
        
    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    } 
    public virtual void AnimationTrigger() { }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
