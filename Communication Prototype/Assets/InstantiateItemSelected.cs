using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItemSelected : MonoBehaviour
{
    public GameObject torchPrefab;
    public GameObject target;

    public int firstAmount = 1;

    static int itemAmount ;

    private void Start()
    {
        if (this.gameObject.tag == "Torch")
        {
            itemAmount = 0;
        }
    }
    public void InstantiateTorch()
    {

            if (this.gameObject.tag == "Torch")
            {
                if (itemAmount < 1)
                {
                    ItemAssets.Instance.pfItemWorld[0].transform.rotation = Quaternion.Euler(90, 0, 0);
                    ItemAssets.Instance.pfItemWorld[0].GetComponent<BoxCollider>().enabled = false;
                    ItemWorld.SpawnItemWorld(target.transform.position, new Item { itemType = Item.ItemType.Torch, amount = 1 });
                    itemAmount++;
                    firstAmount++;
                }
            }
    }
}
