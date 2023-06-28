using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Health : MonoBehaviour
{
    public int helth = 3;

    public float hitCoolDown = 3f;
    public float timer;

    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        helth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //invinsabilty timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        else if (timer < 0)
        {
            timer = 0;
            isHit = false;
        }

        // kill the player when haeth is 0
        if (helth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if the Trigger is an Attack and is the invinsabilty cool down is done
        if ((collision.gameObject.name == ("stab attack") || collision.gameObject.name == ("Closed Sprite Shape")) && timer == 0 && isHit == false)
        {         
            timer = hitCoolDown;
            isHit = true;
            helth--;
         
        }
    }
}
