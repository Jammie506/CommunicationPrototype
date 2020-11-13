using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeOut : MonoBehaviour
{
    public Image fadeImage;
    public GameObject buttonContainer;

    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(2.0f);
        StartCoroutine(WaitForSeconds());
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(2, 2, false);
        buttonContainer.SetActive(true);
    }
}
