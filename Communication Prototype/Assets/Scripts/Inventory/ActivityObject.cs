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
    private DragDrop dragDrop;
    public GameObject uiPanel;


    public static float resetSpeed;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementScript = player.GetComponent<PlayerMovement>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraMovement = playerCamera.GetComponent<MouseLook>();

        boxCollider = player.GetComponent<BoxCollider>();
        dragDrop = lantern.GetComponent<DragDrop>();
        ground = GameObject.FindGameObjectWithTag("Ground");

    }
    private void Start()
    {
        resetSpeed = movementScript.speed;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.R))
        {
            movementScript.speed = 0f;
            cameraMovement.enabled = false;
            uiPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
