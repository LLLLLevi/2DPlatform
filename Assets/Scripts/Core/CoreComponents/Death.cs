using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;

    public void Die()
    {
        //�������� ���ö��� 
        foreach (var particle in deathParticles)
        {
            core.ParticleManager.StartParticles(particle);
        }

        core.transform.parent.gameObject.SetActive(false);
    }

    //����Ϸ�����ϵĽű�����״����ã������ʱ������������Զ�������
    //��Awake֮��ִ��
    private void OnEnable()
    {
        //core.Stats.OnHealthZero += Die;
    }

    public void SubscribeToHealthZeroEvent()
    {
        core.Stats.OnHealthZero += Die;
    }
}
