using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartBeatController : MonoBehaviour
{
    public GameObject mainCampfire;
    public AudioSource heartBeat;

    public float timer = 15;
    private float swtichTimer;
    private float resetTimer;

    public GameObject[] secondaryCampfires = new GameObject[3];

    private void OnEnable()
    {
        heartBeat.GetComponent<AudioSource>();
    }
    Vector3 distance;
    Vector3 distance2;
    Vector3 distance3;
    Vector3 distance4;

    public ActivateConsecutiveFlame acf1;
    public ActivateConsecutiveFlame acf2;
    public ActivateConsecutiveFlame acf3;
    private void Start()
    {
        resetTimer = timer;
        swtichTimer = 3f;
        acf1 = secondaryCampfires[0].GetComponent<ActivateConsecutiveFlame>();
        acf2 = secondaryCampfires[1].GetComponent<ActivateConsecutiveFlame>();
        acf3 = secondaryCampfires[2].GetComponent<ActivateConsecutiveFlame>();
    }
    void Update()
    {
        distance = transform.position - mainCampfire.transform.position;
        distance2 = transform.position - secondaryCampfires[0].transform.position;
        distance3 = transform.position - secondaryCampfires[1].transform.position;
        distance4 = transform.position - secondaryCampfires[2].transform.position;
        Debug.Log( "Distance = " + distance.magnitude);
        if (distance.magnitude > 40 && distance2.magnitude > 40 && distance3.magnitude > 40 && distance4.magnitude > 40)
        {
            if (ActivateFlame.activateFlame == false)
            {
                timer -= Time.deltaTime;
                if (timer <= 13)
                {
                    heartBeatControl(4);
                }
                if (timer <= 0)
                {
                    StartCoroutine(WaitForSeconds());
                }
            }
        }
    }

    public IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(5);
        timer = resetTimer;
            SceneManager.LoadScene(1);
    }
    public void heartBeatControl(int n)
    {
        switch (n)
        {
            case 1:
                swtichTimer -= Time.deltaTime;
                if (swtichTimer <= 0)
                {
                    heartBeat.Play(0);
                }
                break;
            case 2:
                swtichTimer -= Time.deltaTime;
                if (swtichTimer <= 0)
                {
                    heartBeat.Play(0);
                    swtichTimer = 1.75f;
                }
                break;
            case 3:
                swtichTimer -= Time.deltaTime;
                if (swtichTimer <= 0)
                {
                    heartBeat.Play(0);
                    swtichTimer = 0.75f;
                }
                break;
            case 4:
                swtichTimer -= Time.deltaTime;
                if (swtichTimer <= 0)
                {
                    heartBeat.Play(0);
                    swtichTimer = 0.47f;
                }
                break;
            default:
                swtichTimer = 3;
                return;
        }
    }
}
