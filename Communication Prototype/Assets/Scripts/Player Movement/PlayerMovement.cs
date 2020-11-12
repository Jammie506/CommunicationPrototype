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
    private void Start()
    {
        ItemAssets.Instance.pfItemWorld[0].GetComponent<BoxCollider>().enabled = true;


        //CreateGrass(1, Vector3.zero, 10);
      
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
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    public static int amount = 0;
    private GameObject objectTransform;
    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.Torch:
                if(amount < 1)
                {
                    objectTransform = Instantiate(ItemAssets.Instance.pfItemWorld[0], targetPosition.position, targetPosition.transform.rotation);
                    objectTransform.GetComponent<Rigidbody>().useGravity = false;
                    objectTransform.GetComponent<Rigidbody>().isKinematic = true;
                    objectTransform.GetComponent<BoxCollider>().isTrigger = false;
                    objectTransform.transform.parent = targetPosition.transform;
                    targetPosition.tag = "Torch";
                    amount++;
                   
                }
                break;
            case Item.ItemType.Key:
                Debug.Log("Key");
                break;
            case Item.ItemType.Note:
                break;
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
    }
}
