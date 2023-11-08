using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ӵ�����е���״̬�Ļ�������
/// </summary>
public class EnemyState
{
    protected FiniteStateMachine stateMachine;
    protected EnemyEntity entity;

    public float startTime;
    protected string animBoolName;  //���ڿ��ƶ����������͹ر� ������Unity�Ķ������д���������
    
    //���캯����ʼ��״̬���͸���ʵ��
    public EnemyState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
     
    //virtual�ɱ�����̳�����д
    public virtual void Enter()
    {
        startTime = Time.time;  //��¼״̬��ʼ��ʱ��
        entity.Anim.SetBool(animBoolName, true);    //����״̬����

        DoCheck();
    }
    public virtual void Exit()
    {
        entity.Anim.SetBool(animBoolName,  false);    //�ر�״̬����
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void PhysicUpdate()
    {
        DoCheck();
    }

    //С���ɣ��ڽ������������е��ã����ڸ�������һЩ�ж�ʱ�������ڽ�������������д����
    public virtual void DoCheck()
    {

    }
}
