using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        GameObject transform;

        switch (item.itemType)
        {
            default:
            case Item.ItemType.Torch:
                transform = Instantiate(ItemAssets.Instance.pfItemWorld[0], position,Quaternion.identity);
                break;
            case Item.ItemType.Key:
                transform = Instantiate(ItemAssets.Instance.pfItemWorld[1], position, Quaternion.identity);
                break;
            case Item.ItemType.Note:
                transform = Instantiate(ItemAssets.Instance.pfItemWorld[2], position, Quaternion.identity);
                break;
        }
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();

        itemWorld.SetItem(item);
        return itemWorld;
    }

    public static ItemWorld DropItem(Transform dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPosition.transform.position - dropPosition.transform.forward * 3f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(Vector3.down * 2f, ForceMode.Impulse);
        return itemWorld;
    }
    private Item item;
   /* private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }*/
    public void SetItem(Item item)
    {
        this.item = item;
       // spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
