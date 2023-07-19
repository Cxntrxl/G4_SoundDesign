using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpMenu : MonoBehaviour
{
    Scene scene;
    string sceneName;
    public bool menu = true;
    public bool gameOver = false; 
    public bool p1W = false;
    public bool p2W = false;
    public GameObject popMenu;
    public GameObject winMenu;
    public Text winText;

    public AudioSource UI_CallPause;
    public AudioSource UI_ClosePause;
    
    private void Start()
    {
        UI_CallPause = GameObject.Find("UI_CallPause_audioSource").GetComponent<AudioSource>();
        UI_ClosePause = GameObject.Find("UI_ClosePause_audioSource").GetComponent<AudioSource>();
        Time.timeScale = 1;
        menu = false;
        gameOver = false;
        p1W = false;
        p2W = false;
        popMenu.SetActive(false);
        winMenu.SetActive(false);
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    private void Update()
    {
        // makes the menu appers and stop time when is does
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu == false)
            {
                UI_CallPause.Play();
                Time.timeScale = 0;
                menu = true;
                popMenu.SetActive(true);
            }
            else
            {
                UI_ClosePause.Play();
                Time.timeScale = 1;
                menu = false;
                popMenu.SetActive(false);
            }          
        }

        // checks witch player is the win when a player dies and changes the win text appropetly 
        if (GameObject.Find("Player1") == null )
        {
           gameOver = true;
           p2W=true;
            Debug.Log("P2 Wins!");
        }
        else if (GameObject.Find("Player2") == null)
        {
            gameOver= true;
            p1W=true;
            Debug.Log("P1 Wins!");
        }

        if (gameOver == true)
        {
            winMenu.SetActive(true);
        }

        if (p1W == true)
        {
            winText.text = ("Player 1 Wins!");
        }
        else if (p2W == true)
        {
            winText.text = ("Player 2 Wins!");
        }
    }

    // fid the secan that is currntly louded
    public void MainMenuButton()
    {
        if (sceneName == ("Level (Open)"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (sceneName == ("Level 2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

        if (sceneName == ("Level 3"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }

        if (sceneName == ("Level 4"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
    }

    // relouds the Scene
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // deactavats the menu and starts the game again
    public void Continue()
    {
        Time.timeScale = 1;
        menu = false;
        popMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
