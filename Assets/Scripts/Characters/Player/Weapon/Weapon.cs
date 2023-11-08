using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator weaponAnimator;

    protected PlayerAttackState state;

    protected Core core;

    [SerializeField] protected SO_WeaponData weaponData; 

    protected int attackCount;

    protected virtual void Start()
    {
        weaponAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        //当超过连击次数时
        if(attackCount >= weaponData.movementSpeed.Length)
        {
            attackCount = 0;    //重置攻击次数
        }

        weaponAnimator.SetBool("attack", true);
        weaponAnimator.SetInteger("attackCount", attackCount);
    }

    public virtual void ExitWeapon()
    {
        weaponAnimator.SetBool("attack", false);

        //每次攻击完成则次数+1
        attackCount++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers
    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetVelocity(weaponData.movementSpeed[attackCount]);   
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetVelocity(0f);
    }

    public virtual void AnimationActionTrigger()
    {

    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state = state;
        this.core = core;
    }

}
