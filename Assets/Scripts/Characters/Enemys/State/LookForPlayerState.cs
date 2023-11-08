using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : EnemyState
{
    protected bool isMinRangeDectctedPlayer;

    protected bool isFlip;

    protected bool isAllTurnsDone;      //ת������ľ�
    protected bool isAllTurnsTimeDone;  //ת��ʱ�����

    protected float lastTurnTime;       //Ŀǰ����ת��ĳ���ʱ��

    protected int amountOfTurnsDone;    //Ŀǰ����˼���ת��

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

        if (isFlip)     //��һ��ת��
        {
            entity.Core.Movement.Flip();

            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            isFlip = false;
        }

        //��һ��֮���ת��
        else if(Time.time > lastTurnTime + entity.data.timeBetweenTurn && !isAllTurnsDone)
        {
            entity.Core.Movement.Flip();

            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        //����ת�����
        if(amountOfTurnsDone >= entity.data.amountOfTurn)
        {
            isAllTurnsDone = true;
        }

        //�����ľ������һ��ʱ��ľ�
        if(Time.time > lastTurnTime + entity.data.timeBetweenTurn && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    //������״̬�п���ɶʱ��ת��
    public void SetFilp(bool filp)
    {
        isFlip = filp;
    }
}
