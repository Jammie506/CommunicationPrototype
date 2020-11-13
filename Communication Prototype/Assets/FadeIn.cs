using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeImage;
    public GameObject buttonContainer;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(WaitForSeconds());
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(0, 2, false);
        buttonContainer.SetActive(true);
    }
}
