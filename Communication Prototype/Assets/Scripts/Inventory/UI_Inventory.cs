using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform background;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    private PlayerMovement player;

    public AudioSource dropItem;
    private void Awake()
    {
        background = transform.Find("BackGround");
        itemSlotContainer = background.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

    }
    public void SetPlayer(PlayerMovement player)
    {
        this.player = player;
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

    public static bool rightClick = false;
    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate)
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
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                //Use Item
                inventory.UseItem(item);
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                //Drop Item
                dropItem.Play();
                foreach (GameObject n in player.note)
                {
                    n.SetActive(false);
                }
                inventory.RemoveItem(item);
                ItemWorld.DropItem(player.targetPosition.transform, item);

                rightClick = true;
                PlayerMovement.resumeTimer = false;
                if (ActivateFlame.activateFlame == true)
                {
                    PlayerMovement.resumeTimer = true;
                    PlayerMovement.torchIsStillAlive = false;
                }
                player.targetPosition.tag = "Untagged";
            };
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if (item.itemType == Item.ItemType.Torch)
            {
                image.tag = "Torch";
            }

        }
    }
}
