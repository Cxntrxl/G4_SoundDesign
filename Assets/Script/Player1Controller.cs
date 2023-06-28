using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float curSpeed = 1f;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    bool isShildeing;

    public float hitCoolDown = 3f;
    public float timer;

    public GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        curSpeed = 0.07f;
        isShildeing = false;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
      

        if (isShildeing == false)
        {
            if (Input.GetKey(Up))
            {
                transform.Translate(Vector2.up * curSpeed);
                Debug.Log("W presed");

                playerModel.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(Down))
            {
                transform.Translate(Vector2.down * curSpeed);
                Debug.Log("W presed");
                playerModel.transform.eulerAngles = new Vector3(0, 0, 180);
            }

            if (Input.GetKey(Left))
            {
                transform.Translate(Vector2.left * curSpeed);
                Debug.Log("W presed");
                playerModel.transform.eulerAngles = new Vector3(0, 0, 90);

            }

            if (Input.GetKey(Right))
            {
                transform.Translate(Vector2.right * curSpeed);
                Debug.Log("W presed");
                playerModel.transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
    }

    private void Update()
    {       
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        else if (timer < 0)
        {
            timer = 0;
            isShildeing = false;
        }

        if (isShildeing == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isShildeing = true;
                timer = 0.5f;
            }
        }

        if (Input.GetKey(Up) && Input.GetKey(Right)) // faces North east
        {            
            playerModel.transform.eulerAngles = new Vector3(0, 0, -45);
        }

        if (Input.GetKey(Up) && Input.GetKey(Left)) // Faces North West
        {
            playerModel.transform.eulerAngles = new Vector3(0, 0, 45);
        }
        //-----------------------------------------------------------------------------------------

        if (Input.GetKey(Down) && Input.GetKey(Right)) // Faces South east
        {
            playerModel.transform.eulerAngles = new Vector3(0, 0, -135);
        }


        if (Input.GetKey(Down) && Input.GetKey(Left)) // Faces South west
        {
            playerModel.transform.eulerAngles = new Vector3(0, 0, 135);
        }
    }
}
