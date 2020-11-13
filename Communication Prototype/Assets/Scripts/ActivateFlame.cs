using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFlame : MonoBehaviour
{
    public Transform collider;
    public Transform torch;
    public Transform light;
    public Transform firePS;

    public PlayerMovement player;

    public AudioSource lightTorch;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public static bool activateFlame;
    private void OnTriggerEnter(Collider collision)
    {
        collision = collider.GetComponentInChildren<BoxCollider>();

        if (collider.tag == "Torch")
        {
            if (activateFlame == false)
            {
                lightTorch.Play();

            }
            torch = collider.Find("Torch(Clone)");
            light = torch.Find("Torch Light");
            firePS = torch.Find("Fire PS");
            firePS.gameObject.SetActive(true);
            light.gameObject.SetActive(true);
            activateFlame = true;
            PlayerMovement.resumeTimer = true;
            player.timer = player.resetTime;
        }
    }
}
