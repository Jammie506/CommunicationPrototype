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

    public Quaternion quat;
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
    void Update()
    {
       /* ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                print(hit.collider.name);
                if (hit.collider == boxCollider)
                {
                    movementScript.enabled = false;
                    cameraMovement.enabled = false;
                    ground.layer = 2;
                    uiPanel.SetActive(true);
                }
                if (hit.collider != boxCollider)
                {
                    movementScript.enabled = true;
                    cameraMovement.enabled = true;
                }

            }
        }*/
        if(Input.GetKey(KeyCode.I))
        {
            uiPanel.SetActive(true);
        }
    }
}
