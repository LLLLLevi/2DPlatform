using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Progress;

/// <summary>
/// 攻击型武器
/// </summary>
public class AggressiveWeapon : Weapon
{
    private List<IDamageable> detectedDamageables = new List<IDamageable>();     //攻击范围内的敌人
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();     
    
    public override void AnimationActionTrigger()
    {
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        foreach (IDamageable item in detectedDamageables.ToList())    //ToList()用于复制生成个新链表 从而防止出现敌人被destroy了但是依旧被调用的情况
        {
            item.Damage(weaponData.attackDetails[attackCount].damageAmount);
            Debug.Log(weaponData.attackDetails[attackCount].damageAmount);
        }

        foreach(IKnockbackable item in detectedKnockbackables.ToList())
        {
            item.Knocback(weaponData.attackDetails[attackCount].knockbackAngle,
                weaponData.attackDetails[attackCount].knockbackStrength, core.Movement.FacingDirection);
        }
    }

    //将武器检测到的物体记录
    public void AddToDetected(Collider2D collision)
    {
        //将伤害和击退分开 
        IDamageable damageable = collision.GetComponentInChildren<IDamageable>();

        if (damageable != null && !detectedDamageables.Contains(damageable))
        {
            detectedDamageables.Add(damageable);
        }

        IKnockbackable knockbackable = collision.GetComponentInChildren<IKnockbackable>();

        if(knockbackable != null && !detectedKnockbackables.Contains(knockbackable))
        {
            detectedKnockbackables.Add(knockbackable);
        }
    }

    //将武器检测到的物体移除
    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageables.Remove(damageable);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackables.Remove(knockbackable);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToDetected(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
}
