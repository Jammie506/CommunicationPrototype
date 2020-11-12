using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchTimeUI : MonoBehaviour
{
    private Image timeBar;
    public float currentTime;
    private float maxTime;
    PlayerMovement player;

    private void Start()
    {
        timeBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
        maxTime = player.timer;
    }

    private void Update()
    {
        currentTime = player.timer;
        timeBar.fillAmount = currentTime / maxTime;
    }
}
