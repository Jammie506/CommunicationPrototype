using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public Transform[] pfItemWorld = new Transform[3];

    public Sprite torchSprite;
    public Sprite lanternSprite;
    public Sprite randomSprite;
}
