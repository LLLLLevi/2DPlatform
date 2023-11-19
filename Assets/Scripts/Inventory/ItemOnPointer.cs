using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemOnPointer : MonoBehaviour, IPointerEnterHandler, IPointerMoveHandler, IPointerExitHandler
{
    public GameObject Description;
    public Text DescriptionText;

    public Vector2 vec = new Vector2(200, -130);     //������ƫ��ֵ

    public void OnPointerEnter(PointerEventData eventData)
    {
        Description.SetActive(true);
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        Description.transform.position = eventData.position + vec;//��Ʒ������������
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Description.SetActive(false);
    }
}
