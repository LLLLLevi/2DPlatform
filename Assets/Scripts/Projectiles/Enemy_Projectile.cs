using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_Projectile : MonoBehaviour
{
    private float speed;
    private float travelDistance;
    private float xStartPos;

    [SerializeField] private float gravity;
    [SerializeField] private float damageRadius;

    private Rigidbody2D rb;
    GameObject EnemyOb;
    EnemyEntity enemyScript;

    private bool isGravityOn;
    private bool hasHitGround;

    private bool hasDealtDamage; // ���ڸ����Ƿ��Ѿ�������˺�

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform damagePositon;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyOb = GameObject.FindGameObjectWithTag("Enemy");
        enemyScript = EnemyOb.GetComponent<EnemyEntity>();

        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        isGravityOn = false;
        hasDealtDamage = false;

        xStartPos = transform.position.x;
    }

    private void Update()
    {
        if (!hasHitGround)
        {
            if (isGravityOn)
            {
                //ʹ�����´�
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        Collider2D groundHit = Physics2D.OverlapCircle(damagePositon.position, damageRadius, whatIsGround); //��ײ����

        Collider2D damageHit = Physics2D.OverlapCircle(damagePositon.position, damageRadius, whatIsPlayer);

        if (!hasDealtDamage && damageHit)
        { 
            Debug.Log("damageH" + damageHit);
            enemyScript.DamageHit(damageHit);
            hasDealtDamage = true; // ���ñ�־Ϊtrue����ʾ�Ѿ�������˺�
            //Destroy(gameObject);
        }

        if (groundHit)
        {
            hasHitGround = true;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            Destroy(gameObject);
        }

        if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)  //���������û�е��䵽����
        {
            isGravityOn = true;
            rb.gravityScale = gravity;
        }    
    }

    //����������ô˺������乭��
    public void FireProjectile(float speed, float travelDis)
    {
        this.speed = speed;
        this.travelDistance = travelDis;
        hasDealtDamage = false;

    }

    private void OnDrawGizmos()
    {
        if (!damagePositon)
        {
            Gizmos.DrawWireSphere(damagePositon.position, damageRadius);
        }
        
    }
}
