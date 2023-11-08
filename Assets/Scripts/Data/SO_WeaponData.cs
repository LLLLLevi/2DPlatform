using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Weapon")]
public class SO_WeaponData : ScriptableObject
{
    public float[] movementSpeed;   //存储所有的攻击移动速度
    public WeaponAttackDetails[] attackDetails;   //攻击细节
}
