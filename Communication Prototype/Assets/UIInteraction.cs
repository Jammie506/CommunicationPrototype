using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    public static GameObject uiPanel;

    public void Start()
    {
        uiPanel = GameObject.FindGameObjectWithTag("UIPanel");
    }
}
