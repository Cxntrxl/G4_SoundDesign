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

    public AudioSource P1_CooldownComplete;
    public AudioSource P2_CooldownComplete;
    public bool P1_CooldownPlayed = true;
    public bool P2_CooldownPlayed = true;

    private float p1CoolDown;
    private float p2CoolDown;

    // Start is called before the first frame update
    void Start()
    {
        P1_CooldownComplete = GameObject.Find("UI_P1_CooldownComplete_audioSource").GetComponent<AudioSource>();
        P2_CooldownComplete = GameObject.Find("UI_P2_CooldownComplete_audioSource").GetComponent<AudioSource>();

        player2Controller = GameObject.Find("Player2").GetComponent<Player2Controller>();
        player1Attacks = GameObject.Find("Player1").GetComponent<PlayerOneAttacks>();

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

        if (p1CoolDown == 2 && !P1_CooldownPlayed)
        {
            P1_CooldownComplete.Play();
            P1_CooldownPlayed = true;
        }
        else if (p1CoolDown != 2)
        {
            P1_CooldownPlayed = false;
        }

        if (p2CoolDown == 5 && !P2_CooldownPlayed)
        {
            P2_CooldownComplete.Play();
            P2_CooldownPlayed = true;
        }
        else if (p2CoolDown != 5)
        {
            P2_CooldownPlayed = false;
        }
    }
}
