using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 拥有所有敌人状态的基本功能
/// </summary>
public class EnemyState
{
    protected FiniteStateMachine stateMachine;
    protected EnemyEntity entity;

    public float startTime;
    protected string animBoolName;  //用于控制动画的启动和关闭 无需在Unity的动画器中创建和连线
    
    //构造函数初始化状态机和父类实体
    public EnemyState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
     
    //virtual可被子类继承与重写
    public virtual void Enter()
    {
        startTime = Time.time;  //记录状态开始的时间
        entity.Anim.SetBool(animBoolName, true);    //启动状态动画

        DoCheck();
    }
    public virtual void Exit()
    {
        entity.Anim.SetBool(animBoolName,  false);    //关闭状态动画
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void PhysicUpdate()
    {
        DoCheck();
    }

    //小技巧：在进入和物理更新中调用，用于给子类检查一些判断时，不用在进入和物理更新中写两遍
    public virtual void DoCheck()
    {

    }
}
