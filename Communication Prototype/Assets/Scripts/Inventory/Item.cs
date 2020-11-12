using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Torch,
        Key,
        Note
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Torch:
                return ItemAssets.Instance.torchSprite;
            case ItemType.Key:
                return ItemAssets.Instance.lanternSprite;
            case ItemType.Note:
                return ItemAssets.Instance.randomSprite;
        }

    }
}
