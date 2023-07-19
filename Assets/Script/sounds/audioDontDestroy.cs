using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDontDestroy : MonoBehaviour
{
    void Start()
    {
        string ObjectName = this.name;
        if (GameObject.Find(ObjectName) != gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
