using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/EnemyData")]   //建立菜单
public class Data_Enemy : ScriptableObject     //ScriptableObject独立于脚本类存在的用于储存脚本数据的容器
{
    //public float maxHealth = 50f;
    public float damageHopSpeed = 6f;

    public LayerMask whatIsPlayer;

    public float movementSpeed = 4f;

    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;

    //攻击检测范围
    public float minAggrDistence = 3f;
    public float maxAggrDistence = 4f;

    //冲刺状态charge
    public float chargeSpeed = 8f;
    public float chargeTime = 1f;

    //detectedPlayer
    public float longRangeActionTime = 1f;   //执行动作的前摇

    //LookForPlayer
    public int amountOfTurn = 2;    //转身次数
    public float timeBetweenTurn = 0.75f;   //每轮搜寻时间

    //attack
    public float closeRangeActionDis = 1f;
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;
     
    //knockback
    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;

    //Stun
    public float stunTime = 2f;     //眩晕时间

    public float stunKnockbackTime = 0.2f;
    public float stunKnockbackSpeed = 20f;
    public Vector2 stunKnockbackAngle;

    public float stunResistance = 3f;   //眩晕耐性 也就是受击三次后才会眩晕
    public float stunRecoveryTime = 2f;

    //dodge
    public float dodgeSpeed = 10f;
    public float dodgeTime = 0.2f;
    public float dodgeCooldown = 2f;    //跳跃冷却时间
    public Vector2 dodgeAngle;

    //RangeAttack
    public GameObject projectile;      //箭游戏对象
    public float projectileDamage = 30f;  
    public float projectileSpeed = 12f; 
    public float projectileTravelDis = 12f;     //箭能射多远 
}
