using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    public Transform player;
        Vector3 vector;

    // Update is called once per frame
    void Update()
    {
        vector.z = player.eulerAngles.y;
        transform.localEulerAngles = vector;
    }
}
