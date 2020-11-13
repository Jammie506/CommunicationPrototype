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
    public enum NoteType
    {
        noNote,
        note1,
        note2,
        note3,
        note4,
        note5,
        note6,
        note7
    }

    public ItemType itemType;
    public int amount;

    public NoteType noteType;

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
