using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerOneAttacks : MonoBehaviour
{

    public AudioSource p1_shield;

    [SerializeField]
    private GameObject stabAttack;

    [SerializeField]
    private GameObject sweepAttack;

   [SerializeField]
    private GameObject sheld;

    [SerializeField]
    private Vector2 spawnPoint;

    public GameObject player1;
    public GameObject player1R;

    [SerializeField]
    private bool canAttack;

    bool canSheld;

    public float timerTime = 3f;
    public float timer;

    private void Start()
    {
        timerTime = 2f;
        spawnPoint = player1.transform.position;
        canAttack = true;  
        canSheld = true;
    }

    void Update()
    {
        // finds the player transform 
        spawnPoint = player1.transform.position;

        if (timer > 0)
        {
            timer -= Time.deltaTime;         
            
        }
        else if (timer < 0)
        {
            timer = 0;
        }


        if (Input.GetKeyDown(KeyCode.Slash) && canAttack == true)
        {
            timer = timerTime;            
            Instantiate(stabAttack, spawnPoint, player1R.transform.rotation);         
            canAttack = false;              
        }
        else if (Input.GetKeyDown(KeyCode.Period) && canAttack == true)
        {
            timer = timerTime;
            Instantiate(sweepAttack, spawnPoint, player1R.transform.rotation);
            canAttack=false;
            canSheld=false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canSheld == true)
        {
            timer = 1;
            Instantiate(sheld, spawnPoint, player1R.transform.rotation);
            canSheld = false;
            canAttack = false;
            p1_shield.Play();
        }


        if (timer <= 0f)
        {
            canAttack = true;
            canSheld = true;
        }
        
        


        
    }

 
}
