using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable    //���ܼ̳�һ���� ����ʵ�ֶ���ӿ�
{
    //������˵ĺ�ҡʱ�� ʱ�䵽�˾ͻָ���̬
    private bool isKnockbackActive;
    private float knockbackStartTime;
    private float lastDamageTime;   //��������ܻ���ʱ�䣬���ڿ�ʼѣ�εļ�ʱ

    [SerializeField] private float maxKnockbackTime = 0.2f;     //����������ʱ��  ��ֹ���ڿ��ж�����

    [SerializeField] private GameObject damagePaticles;     //����

    private void Start()
    {
        //currentStunResistance = data.stunResistance;
    }

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        lastDamageTime = Time.time;

        //Debug.Log(core.transform.parent.name + "���ƻ�");
        core.Stats.DecreaseHealth(amount);      //��Ѫ
        core.ParticleManager.StartParticlesWithRandomRotation(damagePaticles);
    }

    //����
    public void Knocback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);

        core.Movement.canSetVelocity = false;   //���޷����޸��ٶ�

        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        //�����˱����� �ܻ�����׹ ��(�Ӵ�������߻���ʱ�䵽�ˣ� �رջ���
        if(isKnockbackActive && (core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Ground) 
                ||(Time.time > knockbackStartTime + maxKnockbackTime))
        {
            isKnockbackActive = false;
            core.Movement.canSetVelocity = true;
        }
    }
}
