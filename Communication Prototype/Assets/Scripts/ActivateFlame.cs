using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFlame : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponentInChildren<BoxCollider>().tag == "Torch")
        {
            Debug.Log("working");
        }
    }
}
