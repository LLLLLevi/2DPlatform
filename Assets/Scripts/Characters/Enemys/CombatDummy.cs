using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    //[SerializeField] private GameObject hitParticles;   //��������
    private Animator anim;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    public void Damage(float amount)
    {
        Debug.Log("�ܵ�" + amount + "���˺�");

        //��������Ч��
        //Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        anim.SetTrigger("damage");
        //Destroy(gameObject);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
