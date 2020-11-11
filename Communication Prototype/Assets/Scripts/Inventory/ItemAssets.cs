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

    public GameObject[] pfItemWorld = new GameObject[3];

    public Sprite torchSprite;
    public Sprite lanternSprite;
    public Sprite randomSprite;
}
