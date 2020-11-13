using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadFinalScene : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(1.0f);
      
    }

    IEnumerator WaitForSeconds()
    {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(0, 2, false);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(WaitForSeconds());
        }
    }
}
