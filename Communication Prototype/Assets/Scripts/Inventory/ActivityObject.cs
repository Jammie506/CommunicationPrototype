using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ActivityObject : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private GameObject player;
    private GameObject playerCamera;
    private PlayerMovement movementScript;
    private MouseLook cameraMovement;
    private Collider boxCollider;

    private GameObject ground;
    public Image lantern;
    public GameObject uiPanel;


    public static float resetSpeed;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraMovement = playerCamera.GetComponent<MouseLook>();

        boxCollider = player.GetComponent<BoxCollider>();
        ground = GameObject.FindGameObjectWithTag("Ground");

    }
    private void Start()
    {
        resetSpeed = movementScript.speed;
    }
    public bool inventoryActive = false;
    void Update()
    {
     
            if (Input.GetKeyDown(KeyCode.R))
            {
            CloseInventory.closeInventory = false;
                inventoryActive = !inventoryActive;
            }
          
        if (inventoryActive && !CloseInventory.closeInventory)
        {
            movementScript.speed = 0f;
            cameraMovement.enabled = false;
            uiPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (!inventoryActive)
        {
            {
                movementScript.speed = ActivityObject.resetSpeed;
                cameraMovement.enabled = true;
                uiPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
