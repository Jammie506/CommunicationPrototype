using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    public PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    private static Transform torch;
    private static Transform light;
    private static Transform firePS;

    public static GameObject objectTransform;
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        switch (item.itemType)
        {
            default:
            case Item.ItemType.Torch:
                objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[0], position,Quaternion.Euler(180,90,0));
                torch = objectTransform.transform;
                light = torch.Find("Torch Light");
                firePS = torch.Find("Fire PS");
                if (ActivateFlame.activateFlame)
                {
                    light.gameObject.SetActive(true);
                    firePS.gameObject.SetActive(true);
                    PlayerMovement.resumeTimer = true;
                }
                break;
            case Item.ItemType.Key:
                objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[1], position, Quaternion.identity);
                break;
            case Item.ItemType.Note:
                objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[2], position, Quaternion.identity);
                break;
        }
        ItemWorld itemWorld = objectTransform.GetComponent<ItemWorld>();

        itemWorld.SetItem(item);
        return itemWorld;
    }

    public static ItemWorld DropItem(Transform dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPosition.transform.position - dropPosition.transform.forward * 1.5f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(Vector3.down * 2f, ForceMode.Impulse);
        return itemWorld;
    }
    private Item item;

    public void Update()
    {
        if(player.timer <= 0 && light!= null && firePS != null)
        {
            light.gameObject.SetActive(false);
            firePS.gameObject.SetActive(false);
        }
    }
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
