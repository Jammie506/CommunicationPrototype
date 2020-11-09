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

    public Image cipher;

    public void Start()
    {
        resources.gameObject.SetActive(true);
        map.gameObject.SetActive(true);
        messages.gameObject.SetActive(true);
        
        back.gameObject.SetActive(false);
        
        cipher.gameObject.SetActive(false);
    }

    public void ResourcesClicked()
    {
        resources.gameObject.SetActive(false);
        map.gameObject.SetActive(false);
        messages.gameObject.SetActive(false);
        
        back.gameObject.SetActive(true);
        
        cipher.gameObject.SetActive(true);
    }

    public void MapClicked()
    {
        resources.gameObject.SetActive(false);
        map.gameObject.SetActive(false);
        messages.gameObject.SetActive(false);
        
        back.gameObject.SetActive(true);
        
    }
    
    public void MessagesClicked()
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
        
        cipher.gameObject.SetActive(false);
    }
}
