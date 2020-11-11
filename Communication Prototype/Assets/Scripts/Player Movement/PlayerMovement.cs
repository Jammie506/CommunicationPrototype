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

    public Transform targetPosition;

    Vector3 velocity;
    private bool isGrounded;

    private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    private void OnEnable()
    {

    }
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

    }
    private void Start()
    {
        ItemAssets.Instance.pfItemWorld[0].GetComponent<BoxCollider>().enabled = true;


        //CreateGrass(1, Vector3.zero, 10);
        ItemWorld.SpawnItemWorld(new Vector3(Random.Range(-15, 15), 0.25f, Random.Range(-16, 16)), new Item { itemType = Item.ItemType.Torch, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(Random.Range(-15, 15), 0.5f, Random.Range(-16, 16)), new Item { itemType = Item.ItemType.Key, amount = 1 });
        ItemWorld.SpawnItemWorld(new Vector3(Random.Range(-15, 15), 0.5f, Random.Range(-16, 16)), new Item { itemType = Item.ItemType.Note, amount = 1 });
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
    public void CreateGrass(int num, Vector3 point, int radius)
    {
        for (int i = 0; i < num; i++)
        {
            radius += Random.Range(1, 6);
           

            /* Distance around the circle */
            var radians = 2 * Mathf.PI / num * i;

            /* Get the vector direction */
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            float randomX = Random.Range(-0.2f, 0.2f);
            float randomY = Random.Range(-0.2f, 0.2f);
            var spawnDir = new Vector3(horizontal + randomX, 0f, vertical + randomY);

            ItemWorld.SpawnItemWorld(spawnDir, new Item { itemType = Item.ItemType.Torch, amount = 1 });
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

    }
}
