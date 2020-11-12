using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopContol : MonoBehaviour
{
    public Button map;
    public Button decoder;
    public Button clues;
    public Button clear;

    public Button aButton; public Button cButton; public Button fButton;
    public Button hButton; public Button iButton; public Button lButton;
    public Button pButton; public Button rButton; public Button tButton;
    public Button wButton;

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

    public void AClick()
    {
        a = true;
    }
    public void CClick()
    {
        c = true;
    }
    public void FClick()
    {
        f = true;
    }
    public void HClick()
    {
        h = true;
    }
    public void IClick()
    {
        i = true;
    }
    public void LClick()
    {
        l = true;
    }
    public void PClick()
    {
        p = true;
    }
    public void RClick()
    {
        r = true;
    }
    public void TClick()
    {
        t = true;
    }
    public void WClick()
    {
        w = true;
    }
    
    
    void Decoder()
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
        a = false; c = false; f = false;
        h = false; i = false; l = false;
        p = false; r = false; t = false;
        w = false;
    }
}
