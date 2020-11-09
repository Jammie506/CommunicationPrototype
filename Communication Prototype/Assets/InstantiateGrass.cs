using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGrass : MonoBehaviour
{
    public GameObject grass;

    void Start()
    {
        createGrass();
    }

    void createGrass()
    {
        for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                float randomValueX = Random.Range(-50, 50);
                float randomValueY = Random.Range(-50, 50);
                grass.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                grass.transform.localScale = new Vector3(Random.Range(0.2f, 1.9f), Random.Range(0.5f, 1f), Random.Range(0.25f, 1.5f));
                Instantiate(grass, new Vector3(i + randomValueX, 0.5f, j + randomValueY), grass.transform.rotation);
            }
        }
    }
}
