using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;

    protected virtual void Awake()
    {
        core = GetComponentInParent<Core>(); 

        if(core == null)
        {
            Debug.LogError("父类没有核心脚本");
        }
    }
}
