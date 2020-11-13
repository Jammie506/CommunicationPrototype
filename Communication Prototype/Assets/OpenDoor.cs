using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public bool turnOnXAxis;
    public GameObject trapDoor;
    public float turnSpeed = 1.0f;
    public float openAngle;
    public float openAngleX;

    private Quaternion doorOpenZ = Quaternion.identity;
    private Quaternion doorOpenX = Quaternion.identity;


    public bool opening = false;

    public Transform collider;
    // Start is called before the first frame update
    void Start()
    {
        doorOpenZ = Quaternion.Euler(0, 0, openAngle);
        doorOpenX = Quaternion.Euler(openAngleX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(opening)
        {
            if (!turnOnXAxis)
            {
                Debug.Log("turn on z axis");
                while (Quaternion.Angle(trapDoor.transform.localRotation, doorOpenZ) > 1.0f)
                {
                    trapDoor.transform.localRotation = Quaternion.Slerp(trapDoor.transform.localRotation, doorOpenZ, Time.deltaTime * turnSpeed);
                    return;
                }
            }
            if (turnOnXAxis)
            {
                Debug.Log("turn on x axis");
                while (Quaternion.Angle(trapDoor.transform.localRotation, doorOpenX) > 1.0f)
                {
                    trapDoor.transform.localRotation = Quaternion.Slerp(trapDoor.transform.localRotation, doorOpenX, Time.deltaTime * turnSpeed);
                    return;
                }
            }
        }
    }
    public GameObject crankMessage;
    private void OnTriggerEnter(Collider collision)
    {
        collision = collider.GetComponentInChildren<BoxCollider>();
     
            crankMessage.SetActive(true);

        if (collider.tag == "Crank")
        {
            opening = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
      
            crankMessage.SetActive(false);
    }
}
