using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public AudioSource p2_Dash;
    public AudioSource p2_hShield;
    public AudioSource p2_hWall;

    public bool inP2Collider = false;   
    public bool inDeadZone = false;
    public bool inWall = false;

    public bool parry = false;

    public float acceleration;
    public float maxSpeed = 0.023f;

    public GameObject mouseDeadZone;
    public GameObject player2;
    
    public float curSpeed;

    public float TimerTime = 5f;
    public float timer;
    public float dashTimer;
    public bool dashed;
    // Start is called before the first frame update
    void Start()
    {
        acceleration = 0.001f;
        maxSpeed = 0.2f;
        curSpeed = 0f;

        inDeadZone = false;
        dashed = false;

        mouseDeadZone = GameObject.Find("MouseDeadZone");
        player2 = GameObject.Find("Player1");

    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > 0)  // turens on and off "dashed" bool after a set time
        {
            timer -= Time.deltaTime;

        }
        else if (timer < 0)
        {
            timer = 0;
            dashed = false;
        }

        if (dashTimer > 0) // determands how long player can dash for and when thay can dash agan.
        {
            dashTimer -= Time.deltaTime;
            LookAtMouse();

        }
        else if (dashTimer < 0)
        {            
            if (curSpeed > maxSpeed)
            {
                curSpeed = maxSpeed;
            }
            dashTimer = 0;
        }

        if (curSpeed > 0.2f)
        {
            acceleration = 0.0005f;
        }
        else
        {
            acceleration = 0.001f;
        }

        // when player is not tuoching anything
        if (inP2Collider == false && inDeadZone == false)
        {
            // if speed is 0 it take a long time to acselarat so setting speed to abuve 0 incress play speed
            if (Input.GetKeyDown(KeyCode.Mouse0) && curSpeed >= -0.05 && curSpeed <= 0.05f)  
            {
                curSpeed = 0.05f;              
            }
            // Dashing
            if (Input.GetKeyDown(KeyCode.Mouse2) && dashed == false)  
            {
                curSpeed += 0.2f;
                dashed = true;
                p2_Dash.Play(); // Play Sound 
                timer = TimerTime;
                dashTimer = 0.5f;
            }
            else if (timer <= 0)
            {

            }

            // when the player will be looking a the mouse
            if (Input.GetKey(KeyCode.Mouse0) && curSpeed > 0.001)
            {

                if (curSpeed >= 0)
                {
                    LookAtMouse();
                }
            }
            else if (Input.GetKey(KeyCode.Mouse1) && curSpeed > 0)
            {
                if (curSpeed >= 0)
                {
                    LookAtMouse();
                }
            }
        }
        else if (inWall == true)
        {
            curSpeed = 0.06f;
        }
       
    }

    void FixedUpdate()
    {           
        
        if (inP2Collider == false && inDeadZone == false)
        {
            // player controles
            if (Input.GetKey(KeyCode.Mouse0) && curSpeed > 0.001)
            {
                Move();            
            }
            else if (Input.GetKey(KeyCode.Mouse1) && curSpeed > 0)
            {
                Brake();
            }     
            else if (curSpeed >= 0f)
            {
                SlowDown();
            }           
        }
        else if (inDeadZone == true && curSpeed > 0)
        {
            // if player is to close to the mouse
            SlowDown();
        }   
        // if player hits player 1
        SlowDownB();       
    }
    
    public void OnCollisionEnter2D(Collision2D col) // detects when entering a collider
    {
        // see if the collision hit is with player 2 or a wall
        if (col.gameObject == player2)
        {
            inP2Collider = true;
            
        }
        else if (col.gameObject.tag == ("Wall"))
        {
            inWall = true;   
            p2_hWall.Play();
        }
       
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        // see if the collision exited is with player 2 or a wall
        if (col.gameObject == player2)
        {
            inP2Collider = false;
        }
        else if (col.gameObject.tag == ("Wall"))
        {
            inWall = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // see is player is to close to mouse
        if (other.gameObject == mouseDeadZone)
        {
            inDeadZone = true;
        }

        // checks if player has been hit by an attack
        if (other.gameObject.name == ("stab attack") || other.gameObject.name == ("Closed Sprite Shape") || other.gameObject.name == ("Circle"))
        {
            //makes player look at attacker
            LookAtPlayer1();
            // pushes player backwords
            curSpeed = -0.2f;

            if (other.gameObject.name == ("Circle"))
            {
                p2_hShield.Play();
            }

            // checks if player is moving backwrds 
            if (curSpeed < 0f)
            {
                // slows players backwords movment down till player has stoped
                transform.Translate(Vector2.up * curSpeed);

                curSpeed += acceleration;

                Debug.Log("slowing down!");
            }
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // see is player is to close to mouse
        if (other.gameObject == mouseDeadZone)
        {
            inDeadZone = false;
        }
    }

    private void LookAtMouse()
    {
        // Makes the player look at the mouse.
        Vector2 mousePosition = Input.mousePosition;                                                                     // coulaats the angle betwen the mouse and the game oject
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);                                                   //makes sure both the mouse and game object are in the space(the camera
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); //finds the direction of the vector
        transform.up = direction;                                                                                       // sets the game object to that direction:     
    }

    void LookAtPlayer1()
    {
        Vector2 playe1Position = player2.transform.position;                                                                     // coulaats the angle betwen the Player1 and the game oject                                                        
        Vector2 direction2 = new Vector2(playe1Position.x - transform.position.x, playe1Position.y - transform.position.y); //finds the direction of the vector
        transform.up = direction2;
    }

    public void Move() //used to move player 2 forword
    {
        transform.Translate(Vector2.up * curSpeed); //moves player long vector
        if (inWall == false)
        {
            curSpeed += acceleration;

            if (curSpeed > maxSpeed && dashed == false)
            {
                curSpeed = maxSpeed;
            }
            Debug.Log("Moving");
        }
        else
        {
            curSpeed -= (acceleration * 2f);
        }
    }   

    public void SlowDown()  // slows player down over time
    {     
        if (curSpeed < 0.001)
        {
            curSpeed = 0;
        }

        if (curSpeed > 0f)
        {           
            transform.Translate(Vector2.up * curSpeed); //moves player long vector

            curSpeed -= acceleration;

            Debug.Log("slowing down!");
        }
        
    }

    public void SlowDownB() // makes player goo backwords then slowly regan speed
    {     
        if (inP2Collider == true) //player push back
        {
            LookAtPlayer1();
            curSpeed = -0.2f;
        }
        
        if (curSpeed < 0f)     // speed incress
        {
            transform.Translate(Vector2.up * curSpeed); //moves player long vector

            curSpeed += (acceleration * 4);             

            Debug.Log("slowing down!");
        }

    }

    void Brake()    // mauly slow player down 3xs more then (slow Down)
    {    
        if (curSpeed > 0f)
        {
            curSpeed -= (acceleration * 3);
        }

        transform.Translate(Vector2.up * curSpeed);

        Debug.Log("Brakeing!");
    }
}
