using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField]
    private GameObject sparks;

    private GameObject Attacks;

    [SerializeField]
    private Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        // makes it so if an attack hits a wall it stops and is no longer active
        if (other.gameObject.name == ("stab attack") || other.gameObject.name == ("Closed Sprite Shape"))
        {
            Debug.Log("hit");
            spawnPoint = other.transform.position;         
            Instantiate(sparks, spawnPoint, transform.rotation); // makes a particle as visaule feedback
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        // makes it so if an attack hits a wall it stops and is no longer active
        if (other.gameObject.name == ("stab attack") || other.gameObject.name == ("Closed Sprite Shape"))
        {
            Debug.Log("hit");
            spawnPoint = other.transform.position;
            Instantiate(sparks, spawnPoint, transform.rotation); // makes a particle as visaule feedback
            Destroy(other.gameObject);
        }
    }
}
