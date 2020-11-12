using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatController : MonoBehaviour
{
    public GameObject campFire;
    public AudioSource heartBeat;

    private float timer = 2.75f;
    private float resetTimer;

    private void OnEnable()
    {
        heartBeat.GetComponent<AudioSource>();
    }
    private void Start()
    {
        resetTimer = timer;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 distance = transform.position - campFire.transform.position;

       // Debug.Log( "Distance = " + distance.magnitude);
        if(distance.magnitude < 40)
        {
            timer = resetTimer;
        }
        if (distance.magnitude > 40 && distance.magnitude < 55)
        {
            heartBeatControl(1);
        }
        if (distance.magnitude > 55  && distance.magnitude < 65)
        {
            heartBeatControl(2);
        }
        if (distance.magnitude > 65 && distance.magnitude < 85)
        {
            heartBeatControl(3);
        }
        if (distance.magnitude > 85)
        {
            heartBeatControl(4);
        }
    }

    public void heartBeatControl(int n)
    {
        switch (n)
        {
            case 1:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    heartBeat.Play(0);
                    timer = 2.75f;
                }
                break;
            case 2:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    heartBeat.Play(0);
                    timer = 1.75f;
                }
                break;
            case 3:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    heartBeat.Play(0);
                    timer = 0.75f;
                }
                break;
            case 4:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    heartBeat.Play(0);
                    timer = 0.47f;
                }
                break;
            default:
                timer = 3;
                return;
        }
    }
}
