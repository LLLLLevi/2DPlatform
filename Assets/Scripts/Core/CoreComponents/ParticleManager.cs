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

    //�������� ָ��λ�ú���ת
    public GameObject StartParticles(GameObject particlePrefab, Vector2 position, Quaternion rotation)
    {
        //�����ӹ�������ָ��λ�ú���ת��������
        return Instantiate(particlePrefab, position, rotation, particalContainerTrans);
    }
    //�ڹ�������λ���ϲ���ת����
    public GameObject StartParticles(GameObject particlePrefab)
    {
        return StartParticles(particlePrefab, transform.position, Quaternion.identity);
    }
    //�����ת
    public GameObject StartParticlesWithRandomRotation(GameObject particlePrefab)
    {
        var randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        return StartParticles(particlePrefab, transform.position, randomRotation);
    }
}
