using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;    
    public int itemHeldNum;    //���е���Ʒ��
    [TextArea]              //ʹ������Ϊ�����ı�������ǵ���
    public string itemInfo; //��Ʒ����
    public ItemType type;
}

public enum ItemType{
    key,
    food,
    equipment
}
