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


    Vector3 velocity;
    private bool isGrounded;

    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;


    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

    }
    private void Start()
    {

        ItemWorld.SpawnItemWorld(new Vector3(Random.Range(-15, 15), 0.25f, Random.Range(-16, 16)), new Item { itemType = Item.ItemType.Torch, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(Random.Range(-15, 15), 0.5f, Random.Range(-16, 16)), new Item { itemType = Item.ItemType.Key, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(Random.Range(-15, 15), 0.5f, Random.Range(-16, 16)), new Item { itemType = Item.ItemType.Note, amount = 1 });
    }
    private void OnTriggerEnter(Collider collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            //If the colliding object contains Items world script
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 
        //Creates a sphere that returns true if collides with an object it wants to detect

        if(isGrounded && velocity.y < 0)
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

    }
}
