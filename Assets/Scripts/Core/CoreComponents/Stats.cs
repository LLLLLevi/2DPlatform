using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;   //标准命名On+xxx

    [SerializeField] public float maxHealth;   //可在Untiy调整
    private float currentHealth;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            core.Death.SubscribeToHealthZeroEvent();

            OnHealthZero?.Invoke();     //触发事件

            Debug.Log("Health is zero!");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);  //限制血量不超过最大值
    }
}
