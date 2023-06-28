using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // a timer so player 1's Attacks dont exsist forever.
        if (gameObject.name == ("ChankSparks(Clone)"))
        {
            Destroy(gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject, 3);
        }
     
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // a timer so player 1's Attacks dont exsist forever.
        if (collision.gameObject.name == ("Square"))
        {
            Destroy(gameObject);
        }

    }
}
