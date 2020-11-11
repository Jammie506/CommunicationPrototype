using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform background;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;


    private void Awake()
    {
        background = transform.Find("BackGround");
        itemSlotContainer = background.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if(child == itemSlotTemplate)
            {
                continue;
            }

            Destroy(child.gameObject);
        }
        float x = 0;
        float y = 0;
        float itemSlotCellSize = 108f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            itemSlotRectTransform.gameObject.SetActive(true);
            x++;
            if (item.itemType == Item.ItemType.Torch)
            {
                image.tag = "Torch";
            }
         
        }
    }
}
