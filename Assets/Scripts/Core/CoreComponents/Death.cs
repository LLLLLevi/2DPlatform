using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;

    public void Die()
    {
        //播放粒子 禁用对象 
        foreach (var particle in deathParticles)
        {
            core.ParticleManager.StartParticles(particle);
        }

        core.transform.parent.gameObject.SetActive(false);
    }

    //当游戏对象上的脚本组件首次启用（被激活）时，这个方法会自动被调用
    //在Awake之后执行
    private void OnEnable()
    {
        //core.Stats.OnHealthZero += Die;
    }

    public void SubscribeToHealthZeroEvent()
    {
        core.Stats.OnHealthZero += Die;
    }
}
