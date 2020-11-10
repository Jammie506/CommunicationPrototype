using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{

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

        activityObject = GameObject.FindGameObjectWithTag("ActivityObject");
        playerActivity = activityObject.GetComponent<ActivityObject>();

    }

    public void ShutInventory()
    {
        movementScript.speed = ActivityObject.resetSpeed;
        cameraMovement.enabled = true;

        playerActivity.uiPanel.SetActive(false);
    }
}
