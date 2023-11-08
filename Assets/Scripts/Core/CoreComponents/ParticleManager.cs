using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : CoreComponent
{
    private Transform particalContainerTrans;

    protected override void Awake()
    {
        base.Awake();
        particalContainerTrans = 
            GameObject.FindGameObjectWithTag("ParticleContainer").transform;
    }

    //生成粒子 指定位置和旋转
    public GameObject StartParticles(GameObject particlePrefab, Vector2 position, Quaternion rotation)
    {
        //在粒子管理器上指定位置和旋转生成粒子
        return Instantiate(particlePrefab, position, rotation, particalContainerTrans);
    }
    //在管理器的位置上不旋转生成
    public GameObject StartParticles(GameObject particlePrefab)
    {
        return StartParticles(particlePrefab, transform.position, Quaternion.identity);
    }
    //随机旋转
    public GameObject StartParticlesWithRandomRotation(GameObject particlePrefab)
    {
        var randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        return StartParticles(particlePrefab, transform.position, randomRotation);
    }
}
