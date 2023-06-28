using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBars : MonoBehaviour
{
    public Player2Controller player2Controller;
    public PlayerOneAttacks player1Attacks;

    public Slider player1CoolDown;
    public Slider player2CoolDown;

    private float p1CoolDown;
    private float p2CoolDown;

    // Start is called before the first frame update
    void Start()
    {
        p1CoolDown = player1Attacks.timer;
        p2CoolDown = player2Controller.dashTimer;
    }

    // Update is called once per frame
    void Update()
    {
        p1CoolDown = 2 - player1Attacks.timer;
        p2CoolDown = 5 - player2Controller.timer;

        player1CoolDown.value = p1CoolDown;
        player2CoolDown.value = p2CoolDown;
    }
}
