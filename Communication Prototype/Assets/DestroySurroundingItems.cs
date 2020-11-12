using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySurroundingItems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grass" ||  other.gameObject.tag =="Tree" || other.gameObject.tag =="Boulder")
        {
            Destroy(other.gameObject);
        }
    }
 
}
