using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public RectTransform box;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        box.anchoredPosition = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

}
