using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGrass : MonoBehaviour
{
    public GameObject player;
    public GameObject grass;
    public GameObject tree;
    public GameObject boulder;

    public List<GameObject> grassList = new List<GameObject>();
    public List<GameObject> treeList = new List<GameObject>();
    public List<GameObject> boulderList = new List<GameObject>();

    public int grassLoops = 15;
    public int treeIterations = 10;
    public int boulderIterations = 5;

    void Start()
    {
        CreateGrass(grassLoops,15, new Vector3(0f,0.5f,0f),15);
        CreateTree(treeIterations, 0, new Vector3(0f, 0f, 0f), 35);
        CreateBoulder(boulderIterations, 1, new Vector3(0f, 1f, 0f), 35);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        foreach(GameObject g in grassList)
        {
            if(g != null)
            {
                Vector3 d = player.transform.position - g.transform.position;
                if (d.magnitude < 70)
                {
                    g.SetActive(true);
                }
                else
                {
                    g.SetActive(false);
                }
            }
          
        }
        foreach (GameObject g in treeList)
        {
            if (g != null)
            {
                Vector3 d = player.transform.position - g.transform.position;
                if (d.magnitude < 160)
                {
                    g.SetActive(true);
                }
                else
                {
                    g.SetActive(false);
                }
            }
        }
        foreach (GameObject g in boulderList)
        {
            if (g != null)
            {
                Vector3 d = player.transform.position - g.transform.position;
                if (d.magnitude < 160)
                {
                    g.SetActive(true);
                }
                else
                {
                    g.SetActive(false);
                }
            }
        }
    }
    public void CreateGrass(int num,int num2, Vector3 point, int radius)
    {
        for (int i = 0; i < num; i++)
        {
            radius += Random.Range(1,6);
            num2 += 1;
            for (int j = 0; j < num2; j ++)
            {
                /* Distance around the circle */
                var radians = 2 * Mathf.PI / num2 * j;

                /* Get the vector direction */
                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);

                float randomX = Random.Range(-0.2f, 0.2f);
                float randomY = Random.Range(-0.2f, 0.2f);
                var spawnDir = new Vector3(horizontal + randomX, 0f, vertical + randomY);

                /* Get the spawn position */
                var spawnPos = point + spawnDir * radius ; // Radius is just the distance away from the point

                 grass.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                 grass.transform.localScale = new Vector3(Random.Range(0.4f, 1.2f), Random.Range(0.4f, 1.2f), Random.Range(0.4f, 1.2f));

                /* Now spawn */
                var enemy = Instantiate(grass, spawnPos, grass.transform.rotation) as GameObject;
                grassList.Add(enemy);
            }
        }
    }

    public void CreateTree(int num, int num2, Vector3 point, int radius)
    {
        for (int i = 0; i < num; i++)
        {
            radius += Random.Range(8, 12);
            num2 += 1;
            for (int j = 0; j < num2; j++)
            {
                /* Distance around the circle */
                var radians = 2 * Mathf.PI / num2 * j;

                /* Get the vector direction */
                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);

                float randomX = Random.Range(-0.3f, 0.3f);
                float randomY = Random.Range(-0.3f, 0.3f);
                var spawnDir = new Vector3(horizontal + randomX, 0f, vertical + randomY);

                /* Get the spawn position */
                var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

                tree.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                tree.transform.localScale = new Vector3(Random.Range(1f, 1.5f), Random.Range(1f, 1.5f), Random.Range(1f, 1.5f));

                /* Now spawn */
                var enemy = Instantiate(tree, spawnPos, tree.transform.rotation) as GameObject;
                treeList.Add(enemy);
            }
        }
    }
    public void CreateBoulder(int num, int num2, Vector3 point, int radius)
    {
        for (int i = 0; i < num; i++)
        {
            radius += Random.Range(15, 25);
            num2 += 2;
            for (int j = 0; j < num2; j++)
            {
                /* Distance around the circle */
                var radians = 2 * Mathf.PI / num2 * j;

                /* Get the vector direction */
                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);

                float randomX = Random.Range(-0.2f, 0.2f);
                float randomY = Random.Range(-0.2f, 0.2f);
                var spawnDir = new Vector3(horizontal + randomX, 0f, vertical + randomY);

                /* Get the spawn position */
                var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

                boulder.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                boulder.transform.localScale = new Vector3(Random.Range(1f, 1.2f), Random.Range(1f, 1.2f), Random.Range(1f, 1.2f));

                /* Now spawn */
                var enemy = Instantiate(boulder, spawnPos, boulder.transform.rotation) as GameObject;
                boulderList.Add(enemy);
            }
        }
    }
}
