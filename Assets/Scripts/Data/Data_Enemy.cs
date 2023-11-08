using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/EnemyData")]   //�����˵�
public class Data_Enemy : ScriptableObject     //ScriptableObject�����ڽű�����ڵ����ڴ���ű����ݵ�����
{
    //public float maxHealth = 50f;
    public float damageHopSpeed = 6f;

    public LayerMask whatIsPlayer;

    public float movementSpeed = 4f;

    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;

    //������ⷶΧ
    public float minAggrDistence = 3f;
    public float maxAggrDistence = 4f;

    //���״̬charge
    public float chargeSpeed = 8f;
    public float chargeTime = 1f;

    //detectedPlayer
    public float longRangeActionTime = 1f;   //ִ�ж�����ǰҡ

    //LookForPlayer
    public int amountOfTurn = 2;    //ת�����
    public float timeBetweenTurn = 0.75f;   //ÿ����Ѱʱ��

    //attack
    public float closeRangeActionDis = 1f;
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;
     
    //knockback
    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;

    //Stun
    public float stunTime = 2f;     //ѣ��ʱ��

    public float stunKnockbackTime = 0.2f;
    public float stunKnockbackSpeed = 20f;
    public Vector2 stunKnockbackAngle;

    public float stunResistance = 3f;   //ѣ������ Ҳ�����ܻ����κ�Ż�ѣ��
    public float stunRecoveryTime = 2f;

    //dodge
    public float dodgeSpeed = 10f;
    public float dodgeTime = 0.2f;
    public float dodgeCooldown = 2f;    //��Ծ��ȴʱ��
    public Vector2 dodgeAngle;

    //RangeAttack
    public GameObject projectile;      //����Ϸ����
    public float projectileDamage = 30f;  
    public float projectileSpeed = 12f; 
    public float projectileTravelDis = 12f;     //�������Զ 
}
