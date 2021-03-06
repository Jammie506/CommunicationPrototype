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


    public bool a;
    public bool b;
    public bool c;
    public bool d;
    public bool e;
    public bool f;
    public bool g;
    public bool h;
    public bool i;
    public bool j;
    public bool k;
    public bool l;
    public bool m;
    public bool n;
    public bool o;
    public bool p;
    public bool q;
    public bool r;
    public bool s;
    public bool t;
    public bool u;
    public bool v;
    public bool w;
    public bool x;
    public bool y;
    public bool z;


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

    public void BClick()
    {
        b = true;
    }

    public void CClick()
    {
        c = true;
    }

    public void DClick()
    {
        d = true;
    }

    public void EClick()
    {
        e = true;
    }

    public void FClick()
    {
        f = true;
    }

    public void GClick()
    {
        g = true;
    }

    public void HClick()
    {
        h = true;
    }

    public void IClick()
    {
        i = true;
    }

    public void JClick()
    {
        j = true;
    }

    public void KClick()
    {
        k = true;
    }

    public void LClick()
    {
        l = true;
    }

    public void MClick()
    {
        m = true;
    }

    public void NClick()
    {
        n = true;
    }

    public void OClick()
    {
        o = true;
    }

    public void PClick()
    {
        p = true;
    }

    public void QClick()
    {
        q = true;
    }

    public void RClick()
    {
        r = true;
    }

    public void SClick()
    {
        s = true;
    }

    public void TClick()
    {
        t = true;
    }

    public void UClick()
    {
        u = true;
    }

    public void VClick()
    {
        v = true;
    }

    public void WClick()
    {
        w = true;
    }

    public void XClick()
    {
        x = true;
    }

    public void YClick()
    {
        y = true;
    }

    public void ZClick()
    {
        z = true;
    }


    void Decoder()
    {
        decoderTxt.text = "DECODER";

        if (h && n && o && t && m && c && f && r)
        {
            decoderTxt.text = "Head North of the Main Campsite to find the Red Tree";
        }

        if (h && s && e && o && t && r && d && a && c)
        {
            decoderTxt.text = "Head South East of the Red Tree to Discover Another Campsite";


            if (h && s && w && o && t && c)
            {
                decoderTxt.text = "Head South West of the Second Campsite to find the Car";
            }

            if (h && s && o && t && c && f)
            {
                decoderTxt.text = "Head South of the Car to find the Container";
            }

            if (h && s && w && o && t && c && f && a && n)
            {
                decoderTxt.text = "Head South West of the Container to find a New Campsite";
            }

            if (h && n && w && o && t && c && f && l && r)
            {
                decoderTxt.text = "Head North West of the Third Campsite to find the Large Rock";
            }

            if (h && n && o && t && l && r && f && d && b)
            {
                decoderTxt.text = "Head North of the Large Rock to find the Draw Bridge";
            }
        }

        void Clear()
        {
            a = false;
            b = false;
            c = false;
            d = false;
            e = false;
            f = false;
            g = false;
            h = false;
            i = false;
            j = false;
            k = false;
            l = false;
            m = false;
            n = false;
            o = false;
            p = false;
            q = false;
            r = false;
            s = false;
            t = false;
            u = false;
            v = false;
            w = false;
            x = false;
            y = false;
            z = false;
        }
    }
}
