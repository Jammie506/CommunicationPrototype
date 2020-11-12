using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightNewCampfire : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject firePS;
    public GameObject light;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            if(ActivateFlame.activateFlame)
            {
                firePS.SetActive(true);
                light.SetActive(true);
            }
        }
    }
}
