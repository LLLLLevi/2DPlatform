using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Weapon")]
public class SO_WeaponData : ScriptableObject
{
    public float[] movementSpeed;   //�洢���еĹ����ƶ��ٶ�
    public WeaponAttackDetails[] attackDetails;   //����ϸ��
}
