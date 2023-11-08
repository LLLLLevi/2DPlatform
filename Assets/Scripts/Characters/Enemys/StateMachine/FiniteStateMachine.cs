using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����׷�ٵ��˵�ǰλ��ʲô״̬�Լ���״̬������ȷ����
/// </summary>
public class FiniteStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangState(EnemyState state)
    {
        CurrentState.Exit();    //���˳���ǰ״̬
        CurrentState = state;
        CurrentState.Enter();
    }
}
