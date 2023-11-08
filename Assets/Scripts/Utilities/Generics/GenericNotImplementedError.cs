using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenericNotImplementedError<T>  //����������ʱ ��Ҫָ��T������ ������List���÷�
{
    public static T TryGet(T value, string name)
    {
        if(value != null)
        {
            return value;
        }

        Debug.LogError("��" + name + "�У�" + typeof(T) + "û�б�ʵ��");
        return default;     //default����ʵ��������ֵ
    }
}
