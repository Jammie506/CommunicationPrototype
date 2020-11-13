using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject torchPrefab;

    public Transform targetPosition;

    Vector3 velocity;
    private bool isGrounded;

    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    public PlayerMovement player;

    private void OnEnable()
    {
        player = this.gameObject.GetComponent<PlayerMovement>();
    }
    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);

    }

    public float timer = 30;
    public float resetTime;
    public static bool resumeTimer;

    public GameObject[] note = new GameObject[7];
 
    private void Start()
    {
        ItemAssets.Instance.pfItemWorld[0].GetComponent<BoxCollider>().enabled = true;

        resetTime = timer;

    }

    public void GetPosition()
    {
        Vector3 playerPos = player.transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //If the colliding object contains Items world script
            if(itemWorld.GetItem().itemType == Item.ItemType.Torch)
            {
                resumeTimer = false;

            }
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    [HideInInspector] public Transform torch;
    [HideInInspector] public Transform light;
    [HideInInspector] public Transform firePS;

    public static GameObject objectTransform;
    public static  bool flameIsActive = false;
    public static bool createNewFire = false;
    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.Torch:
                Destroy(objectTransform);
                objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[0], targetPosition.position, targetPosition.transform.rotation);
                objectTransform.tag = "Untagged";
                objectTransform.GetComponent<Rigidbody>().useGravity = false;
                objectTransform.GetComponent<Rigidbody>().isKinematic = true;
                objectTransform.GetComponent<BoxCollider>().isTrigger = false;
                objectTransform.transform.parent = targetPosition.transform;
                targetPosition.tag = "Torch";
                torch = objectTransform.transform;
                light = torch.Find("Torch Light");
                firePS = torch.Find("Fire PS");
                if(ActivateFlame.activateFlame)
                {
                    light.gameObject.SetActive(true);
                    firePS.gameObject.SetActive(true);
                    resumeTimer = true;
                    flameIsActive = true;
                    
                }
                foreach (GameObject n in note)
                {
                    n.SetActive(false);
                }
                break;
            case Item.ItemType.Key:
                Debug.Log("Key");
                resumeTimer = false;
                Destroy(objectTransform);
                objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[1], targetPosition.position, targetPosition.transform.rotation);
                objectTransform.tag = "Untagged";
                targetPosition.tag = "Crank";
                objectTransform.GetComponent<Rigidbody>().useGravity = false;
                objectTransform.GetComponent<Rigidbody>().isKinematic = true;
                objectTransform.GetComponent<BoxCollider>().isTrigger = false;
                objectTransform.transform.parent = targetPosition.transform;
                foreach(GameObject n in note)
                {
                    n.SetActive(false);
                }
                if (ActivateFlame.activateFlame)
                {
                    flameIsActive = true;
                }
                break;
            case Item.ItemType.Note:
                resumeTimer = false;
                Destroy(objectTransform);
                objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[2], targetPosition.position, targetPosition.transform.rotation);
                objectTransform.tag = "Untagged";
                targetPosition.tag = "Untagged";
                objectTransform.GetComponent<Rigidbody>().useGravity = false;
                objectTransform.GetComponent<Rigidbody>().isKinematic = true;
                objectTransform.GetComponent<BoxCollider>().isTrigger = false;
                objectTransform.transform.parent = targetPosition.transform;
                if (ActivateFlame.activateFlame)
                {
                    flameIsActive = true;
                }
                switch (item.noteType)
                {
                    case Item.NoteType.noNote:
                        return;
                    case Item.NoteType.note1:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[0].SetActive(true);
                        break;
                    case Item.NoteType.note2:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[1].SetActive(true);
                        break;
                    case Item.NoteType.note3:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[2].SetActive(true);
                        break;
                    case Item.NoteType.note4:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[3].SetActive(true);
                        break;
                    case Item.NoteType.note5:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[4].SetActive(true);
                        break;
                    case Item.NoteType.note6:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[5].SetActive(true);
                        break;
                    case Item.NoteType.note7:
                        foreach (GameObject n in note)
                        {
                            n.SetActive(false);
                        }
                        note[6].SetActive(true);
                        break;

                }
                break;
        }

    }
    public static bool torchIsStillAlive = true;
    public void TimerControl()
    {
        if(resumeTimer)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if(ActivateFlame.activateFlame)
                {
                    if(light != null && firePS != null)
                    {
                        light.gameObject.SetActive(false);
                        firePS.gameObject.SetActive(false);
                        flameIsActive = false;
                    }
                }

                resumeTimer = false;
                ActivateFlame.activateFlame = false;
                createNewFire = false;
            }
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Creates a sphere that returns true if collides with an object it wants to detect

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        ItemAssets.Instance.pfItemWorld[0].transform.position = targetPosition.transform.position;
        if (UI_Inventory.rightClick)
        {
            Destroy(objectTransform);
            UI_Inventory.rightClick = false;
        }

        TimerControl();
    }
}
