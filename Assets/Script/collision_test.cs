using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_test : MonoBehaviour
{
    public bool inCollider = false;

    public void OnCollisionEnter2D(Collision2D col) // detects when entering a collider
    {
        inCollider = true;
;   }

    void OnCollisionStay2D(Collision2D collision) // detects when in a collier
    {
        Debug.Log("in collishon");
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        inCollider = false;
    }
}
