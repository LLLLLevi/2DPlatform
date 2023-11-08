using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : EnemyState
{
    protected bool isMinRangeDectctedPlayer;

    protected bool isFlip;

    protected bool isAllTurnsDone;      //转身次数耗尽
    protected bool isAllTurnsTimeDone;  //转身时间结束

    protected float lastTurnTime;       //目前这轮转身的持续时间

    protected int amountOfTurnsDone;    //目前完成了几轮转身

    public LookForPlayerState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isMinRangeDectctedPlayer = entity.CheckPlayerInMinAggraRange();
    }

    public override void Enter()
    {
        base.Enter();
        
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        amountOfTurnsDone = 0;

        entity.Core.Movement.SetVelocityX(0f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.Core.Movement.SetVelocityX(0f);

        if (isFlip)     //第一次转身
        {
            entity.Core.Movement.Flip();

            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            isFlip = false;
        }

        //第一次之后的转身
        else if(Time.time > lastTurnTime + entity.data.timeBetweenTurn && !isAllTurnsDone)
        {
            entity.Core.Movement.Flip();

            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        //所有转身结束
        if(amountOfTurnsDone >= entity.data.amountOfTurn)
        {
            isAllTurnsDone = true;
        }

        //轮数耗尽且最后一轮时间耗尽
        if(Time.time > lastTurnTime + entity.data.timeBetweenTurn && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    //在其他状态中控制啥时候转身
    public void SetFilp(bool filp)
    {
        isFlip = filp;
    }
}
