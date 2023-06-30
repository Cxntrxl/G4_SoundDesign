using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEventManager : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("btn_clickEvent_audioSource") != gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
