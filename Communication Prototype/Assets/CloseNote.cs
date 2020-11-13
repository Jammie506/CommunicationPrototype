using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseNote : MonoBehaviour
{
    public Transform note;
    // Start is called before the first frame update
    void Start()
    {
        note = gameObject.transform.parent;
    }

    
    public void CloseMessage()
    {
        note.gameObject.SetActive(false);
    }
}
