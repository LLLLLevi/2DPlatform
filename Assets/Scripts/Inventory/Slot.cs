using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;      //���ӵı��
    public Item slotItem;   //��Ʒ������
    public Image slotImage;
    public Text slotNum;     //������
    public GameObject Description;
    public Text DescriptionText;

    public GameObject itemInSlot;
    //���ɸ��ӵ�����
    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);    //�����ǰ����û��Ʒ���ݣ��ǾͲ���ʾ����Ʒ����Ȼ�ͻ���ʾһ�Ű�ͼ��
            return;
        }

        //��Ʒ������ʾ
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeldNum.ToString();
        DescriptionText.text = item.itemInfo;
    }
}
