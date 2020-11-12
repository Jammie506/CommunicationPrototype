using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateConsecutiveFlame : MonoBehaviour
{
    public Transform collider;
    public Transform torch;
    public Transform light;
    public Transform firePS;

    public PlayerMovement player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision = collider.GetComponentInChildren<BoxCollider>();

        if (collider.tag == "Torch")
        {
            if(ActivateFlame.activateFlame)
            {
                torch = collider.Find("Torch(Clone)");
                light = torch.Find("Torch Light");
                firePS = torch.Find("Fire PS");
                firePS.gameObject.SetActive(true);
                light.gameObject.SetActive(true);
                PlayerMovement.resumeTimer = true;
                player.timer = player.resetTime;
            }
        }
    }
}
