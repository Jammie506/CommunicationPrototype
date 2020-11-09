using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotlightInteract : MonoBehaviour
{
    public Text interact;
    void Start()
    {
        interact.gameObject.SetActive(false);
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            interact.gameObject.SetActive(true);
            Debug.Log("collide");
        }
    }
}
