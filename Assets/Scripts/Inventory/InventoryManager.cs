using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //�õ���ģʽ �������
    static InventoryManager instance;

    public Inventory mainInventory;
    public GameObject slotParent;   //���ӵĵ�  
    //public Slot slotPrefab;
    public GameObject emptySlot;    //�ո���

    public List<GameObject> slotsList = new List<GameObject>();     //������ſո��ӵ��б�


    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();      //��Ϸ��ʼʱˢ�±���
    }

    //ˢ�µ�ǰ��������Ʒ��
    public static void RefreshItem()
    {
        //�����������������ɾ��
        for(int i = 0; i < instance.slotParent.transform.childCount; i++)
        {
            if (instance.slotParent.transform.childCount == 0)
                break;
            Destroy(instance.slotParent.transform.GetChild(i).gameObject);
            instance.slotsList.Clear(); //����б�
        }

        //���´�����Ʒ
        for(int i = 0; i < instance.mainInventory.itemList.Count; i++)
        {
            //���ɿո�������ӵ��ո����б���
            GameObject newSlot = Instantiate(instance.emptySlot);
            //newSlot.transform.localScale = new Vector2(2, 2);
            instance.slotsList.Add(newSlot);    
            instance.slotsList[i].transform.SetParent(instance.slotParent.transform);   //��̬�����ı���һ���Ǿ�ֵ̬
            instance.slotsList[i].GetComponent<Slot>().slotID = i;  //������
            instance.slotsList[i].GetComponent<Slot>().SetupSlot(instance.mainInventory.itemList[i]);   //��ֵ������Ʒ������
        }
    }
}
