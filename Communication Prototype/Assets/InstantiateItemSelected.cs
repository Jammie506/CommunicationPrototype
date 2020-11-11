using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItemSelected : MonoBehaviour
{
    public GameObject torchPrefab;
    public GameObject target;

    public void InstantiateTorch()
    {
        if (this.gameObject.tag == "Torch")
        {
            ItemWorld.SpawnItemWorld(target.transform.position, new Item { itemType = Item.ItemType.Torch, amount = 1 });
            ItemAssets.Instance.pfItemWorld[0].transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

}
