﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopContol : MonoBehaviour
{
    public Button map;
    public Button decoder;
    public Button clues;

    public GameObject alphabetHolder;

    public Button back;

    public Image cipher;

    public Text decoderTxt;

    
    public bool a; public bool c; public bool f;
    public bool h; public bool i; public bool l;
    public bool p; public bool r; public bool t;
    public bool w; 
    

    public void Start()
    {
        map.gameObject.SetActive(true);
        decoder.gameObject.SetActive(true);
        clues.gameObject.SetActive(true);
        
        back.gameObject.SetActive(false);
        
        cipher.gameObject.SetActive(false);
        
        alphabetHolder.SetActive(false);
    }

    private void Update()
    {
        Decoder();
    }

    public void MapClicked()
    {
        map.gameObject.SetActive(false);
        decoder.gameObject.SetActive(false);
        clues.gameObject.SetActive(false);
        
        back.gameObject.SetActive(true);
    }

    public void DecoderClicked()
    {
        map.gameObject.SetActive(false);
        decoder.gameObject.SetActive(false);
        clues.gameObject.SetActive(false);
        
        back.gameObject.SetActive(true);
        
        alphabetHolder.SetActive(true);
    }
    
    public void CluesClicked()
    {
        map.gameObject.SetActive(false);
        decoder.gameObject.SetActive(false);
        clues.gameObject.SetActive(false);
        
        back.gameObject.SetActive(true);
        
    }

    public void BackClicked()
    {
        map.gameObject.SetActive(true);
        decoder.gameObject.SetActive(true);
        clues.gameObject.SetActive(true);
        
        back.gameObject.SetActive(false);
        
        alphabetHolder.SetActive(false);
    }

    public void Decoder()
    {
        decoderTxt.text = "DECODER";

        if (l && f && t && r)
        {
            decoderTxt.text = "Look for the Red Tree";
        }

        if (f && i && t && w && p)
        {
            decoderTxt.text = "Free in the Wild Plains";
        }

        if (h && a && t && c && f)
        {
            decoderTxt.text = "Home as the Crow Flies";
        }
        
        
    }

    public void Clear()
    {
        a = false;
        c = false;
        f = false;
        h = false;
        i = false;
        l = false;
        p = false;
        r = false;
        t = false;
        w = false;
    }
}
