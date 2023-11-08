using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Progress;

/// <summary>
/// ����������
/// </summary>
public class AggressiveWeapon : Weapon
{
    private List<IDamageable> detectedDamageables = new List<IDamageable>();     //������Χ�ڵĵ���
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();     
    
    public override void AnimationActionTrigger()
    {
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        foreach (IDamageable item in detectedDamageables.ToList())    //ToList()���ڸ������ɸ������� �Ӷ���ֹ���ֵ��˱�destroy�˵������ɱ����õ����
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

    //��������⵽�������¼
    public void AddToDetected(Collider2D collision)
    {
        //���˺��ͻ��˷ֿ� 
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

    //��������⵽�������Ƴ�
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
