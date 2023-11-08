using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

/// <summary>
/// ���е��˶����̳и�ʵ���� �������ڴ��ÿ�����˶�ӵ�е�����
/// </summary>
public class EnemyEntity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    [SerializeField] public Data_Enemy data;

    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }
    public Core Core { get; private set; }

    [SerializeField] private Transform playerCheckTran;     //���ڵ������� ���ü�����λ�õ� ��λ ������ҵ�λ��

    public AnimationToStateMachine atsm{ get; private set; }

    public virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Core = GetComponentInChildren<Core>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();    //״̬�����������κ������� ����ֱ�����ɼ���
    }

    public virtual void Update()
    {
        Core.LogicUpdate();

        stateMachine.CurrentState.LogicUpdate();    //ʵʱ����״̬�ĸ��º���

        Anim.SetFloat("yVelocity", RB.velocity.y);
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicUpdate();    //ʵʱ����״̬��������º���
    }

    //������Unity scence�п��ӵ��� ���ڲ鿴��ײ����Ƿ�����:Ҫ���зǿռ�� ��Ϊ�ڱ���׶���Ϸû��ʼ��δʵ����Core
    public virtual void OnDrawGizmos()
    {
        if(Core != null)    //����Ϸδ����ʱ awake����û������ ����coreδʵ���� ��ʱ�ᱨ��
        {
            Gizmos.DrawLine(Core.CollisionSenses.WallCheckTrans.position, Core.CollisionSenses.WallCheckTrans.position +
               (Vector3)(Vector2.right * Core.Movement.FacingDirection * Core.CollisionSenses.WallCheckDistence));
            Gizmos.DrawLine(Core.CollisionSenses.LedgeCheckTrans.position, Core.CollisionSenses.LedgeCheckTrans.position +
                (Vector3)(Vector2.down * Core.CollisionSenses.LedgeCheckDistence));
            Gizmos.DrawWireSphere(playerCheckTran.position + (Vector3)(transform.right * data.closeRangeActionDis), 0.2f);
            Gizmos.DrawWireSphere(playerCheckTran.position + (Vector3)(transform.right * data.minAggrDistence), 0.2f);
            Gizmos.DrawWireSphere(playerCheckTran.position + (Vector3)(transform.right * data.maxAggrDistence), 0.2f);
        }
    }

    //�ܻ�С��
    public virtual void DamageHop(float velocity)
    {
        Core.Movement.SetVelocityY(velocity); 
    }

    public void DamageHit(Collider2D damageHit)
    {
        Debug.Log("�����Ѫ");

        IDamageable damageable = damageHit.GetComponentInChildren<IDamageable>();
        Debug.Log("damageable = " + damageable);

        if (damageable != null)
        {
            Debug.Log("��Ѫ");
            damageable.Damage(data.projectileDamage);
        }

        IKnockbackable knockbackable = damageHit.GetComponentInChildren<IKnockbackable>();
        if (knockbackable != null)
        {
            knockbackable.Knocback(data.knockbackAngle, data.knockbackStrength,
                Core.Movement.FacingDirection);
        }
    }

    //С��Χ������
    public virtual bool CheckPlayerInMinAggraRange()
    {
        return Physics2D.Raycast(playerCheckTran.position, 
            transform.right, data.minAggrDistence, data.whatIsPlayer);
    }
    //��Χ������
    public virtual bool CheckPlayerInMaxAggraRange()
    {
        return Physics2D.Raycast(playerCheckTran.position,
            transform.right, data.maxAggrDistence, data.whatIsPlayer);
    }
    //�������Ƿ�զ�ڽ��̹�����Χ��
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheckTran.position, transform.right,
            data.closeRangeActionDis, data.whatIsPlayer);
    }
}
