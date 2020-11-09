using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

}
