using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopContol : MonoBehaviour
{
    public Button resources;
    public Button map;
    public Button messages;

    public Button back;

    public void Start()
    {
        resources.gameObject.SetActive(true);
        map.gameObject.SetActive(true);
        messages.gameObject.SetActive(true);
        
        back.gameObject.SetActive(false);
    }

    public void ButtonClicked()
    {
        resources.gameObject.SetActive(false);
        map.gameObject.SetActive(false);
        messages.gameObject.SetActive(false);
        
        back.gameObject.SetActive(true);
    }

    public void BackClicked()
    {
        resources.gameObject.SetActive(true);
        map.gameObject.SetActive(true);
        messages.gameObject.SetActive(true);
        
        back.gameObject.SetActive(false);
    }
}
