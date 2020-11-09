using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    public GameObject ground;

    public GameObject player;
    private GameObject playerCamera;
    private PlayerMovement movementScript;
    private MouseLook cameraMovement;

    public GameObject activityObject;
    private ActivityObject playerActivity;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraMovement = playerCamera.GetComponent<MouseLook>();

        activityObject = GameObject.Find("ActivityObject");
        ground = GameObject.FindGameObjectWithTag("Ground");

    }
    public void ShutInventory()
    {
        ground.layer = 0;

        movementScript.enabled = true;
        cameraMovement.enabled = true;

        playerActivity.uiPanel.SetActive(false);
    }
}
