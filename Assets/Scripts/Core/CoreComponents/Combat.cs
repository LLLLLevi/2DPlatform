using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable    //仅能继承一个类 但能实现多个接口
{
    //计算击退的后摇时间 时间到了就恢复常态
    private bool isKnockbackActive;
    private float knockbackStartTime;
    private float lastDamageTime;   //保存最后受击的时间，用于开始眩晕的计时

    [SerializeField] private float maxKnockbackTime = 0.2f;     //控制最大击退时间  防止卡在空中动不得

    [SerializeField] private GameObject damagePaticles;     //粒子

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

        //Debug.Log(core.transform.parent.name + "被破坏");
        core.Stats.DecreaseHealth(amount);      //扣血
        core.ParticleManager.StartParticlesWithRandomRotation(damagePaticles);
    }

    //击退
    public void Knocback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);

        core.Movement.canSetVelocity = false;   //将无法再修改速度

        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        //当击退被激活 受击者下坠 且(接触地面或者击退时间到了） 关闭击退
        if(isKnockbackActive && (core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Ground) 
                ||(Time.time > knockbackStartTime + maxKnockbackTime))
        {
            isKnockbackActive = false;
            core.Movement.canSetVelocity = true;
        }
    }
}
