using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menu;
    public GameObject audioPanel;

    public void Start()
    {
        mainMenu.SetActive(true);
        menu.SetActive(false);
        audioPanel.SetActive(false);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel2()
    {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void Back()
    {
        audioPanel.SetActive(false);
        mainMenu.SetActive(true);
        menu.SetActive(false);
    }

    public void Controles()
    {
        audioPanel.SetActive(false);
        mainMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void Audio()
    {
        mainMenu.SetActive(false);
        menu.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
