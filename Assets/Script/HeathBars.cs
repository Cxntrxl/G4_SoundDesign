using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBars : MonoBehaviour
{
    public Slider p1HelthBar;
    public Slider p2HelthBar;

    private float p1Health;
    private float p2Health;

    public player2Health player2Health;
    public PlayerOneHeath player1Health;

    // Start is called before the first frame update
    void Start()
    {
        player2Health = GameObject.Find("Player2").GetComponent<player2Health>();
        player1Health = GameObject.Find("Player1").GetComponent<PlayerOneHeath>();

        p1Health = player1Health.health;
        p2Health = player2Health.helth;
    }

    // Update is called once per frame
    void Update()
    {
        p1Health = player1Health.health;
        p2Health = player2Health.helth;

        p1HelthBar.value = p1Health;
        p2HelthBar.value = p2Health;
    }
}
