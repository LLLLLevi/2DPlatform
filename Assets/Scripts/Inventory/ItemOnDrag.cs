using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���ص���Ʒ���ϣ�ʵ����קЧ��
public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;    //��¼��ʼ�ĸ���λ��
    public Inventory mainInventory;
    private int curItemID;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        curItemID = originalParent.GetComponent<Slot>().slotID;

        transform.SetParent(transform.parent.parent);   //���Ĳ㼶��ϵΪ�������ֵܣ���ֹ��Ⱦ����ס
        transform.position = eventData.position;    //λ��������ƶ�
        //��קʱ���Ƶ���Ʒ�ᵲס���ߵĴ�͸��������Ҫ����������ײ������Ʒ�����жϣ�����Ҫ�ص�
        GetComponent<CanvasGroup>().blocksRaycasts = false;     
    }

    public void OnDrag(PointerEventData eventData)
    { 
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name); //��ʾ���������ײ������������
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject itemOnRaycast = eventData.pointerCurrentRaycast.gameObject;
        Transform itemTransOnRaycast = eventData.pointerCurrentRaycast.gameObject.transform;

        //����ק�յ��������Ʒʱ������������Ʒ��λ��
        if(itemOnRaycast != null)
        {
            if (itemOnRaycast.CompareTag("Item"))
            {
                //�ı丸����λ��
                transform.SetParent(itemTransOnRaycast.parent);     //itemTransOnRaycast.parent���Ǹ���
                transform.position = itemTransOnRaycast.parent.position;

                //ˢ��itemList����Ʒ�洢λ��
                var temp = mainInventory.itemList[curItemID];
                mainInventory.itemList[curItemID] = mainInventory.itemList[itemOnRaycast.GetComponentInParent<Slot>().slotID];
                mainInventory.itemList[itemOnRaycast.GetComponentInParent<Slot>().slotID] = temp;

                itemTransOnRaycast.position = originalParent.position;
                itemTransOnRaycast.SetParent(originalParent);

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            //û����Ʒʱ�����䵽���Ǹ����ӣ�ֱ�Ӹ�ֵ���������
            else if (itemOnRaycast.CompareTag("Slot"))
            {
                transform.SetParent(itemTransOnRaycast);
                transform.position = itemTransOnRaycast.position;
                //�ո��ӵ�λ��Ҳ�û�
                itemTransOnRaycast.Find("Item").position = originalParent.position;
                itemTransOnRaycast.Find("Item").SetParent(originalParent);
                

                mainInventory.itemList[itemOnRaycast.GetComponent<Slot>().slotID] = mainInventory.itemList[curItemID];
                //��λ���˵Ļ��ͽ�ԭ���ĸ�Ϊ��
                if (itemOnRaycast.GetComponent<Slot>().slotID != curItemID)
                    mainInventory.itemList[curItemID] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        
        //�䵽��������ʱ�ص�ԭλ��
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true; 
    }

}
