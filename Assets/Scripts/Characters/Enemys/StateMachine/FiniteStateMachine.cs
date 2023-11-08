using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于追踪敌人当前位于什么状态以及在状态内做正确的事
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
        CurrentState.Exit();    //先退出当前状态
        CurrentState = state;
        CurrentState.Enter();
    }
}
