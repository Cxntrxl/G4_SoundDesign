using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;                                                                     // coulaats the angle betwen the mouse and the game oject
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = mousePosition;
    }
}
