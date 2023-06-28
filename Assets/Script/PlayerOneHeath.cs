using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneHeath : MonoBehaviour
{
    public Player2Controller Player2Controller;

    public float speed;
    public GameObject player2;
    public float health;
    public bool canBeHit = true;

    public float timerTime = 3f;
    public float timer;
    

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        else if (timer <= 0)
        {
            timer = 0;
            canBeHit = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        speed = Player2Controller.curSpeed;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player2 && canBeHit == true & speed > 0.1f)
        {
            if (speed > 0.2f)
            {
                speed = 0.2f;
            }
            timer = timerTime;
            canBeHit = false;
            health -= speed;            
        }
    }


}
