using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericNotImplementedError<T>  //在声明此类时 需要指定T的类型 类似与List的用法
{
    public static T TryGet(T value, string name)
    {
        if(value != null)
        {
            return value;
        }

        Debug.LogError("在" + name + "中，" + typeof(T) + "没有被实现");
        return default;     //default根据实现来决定值
    }
}
