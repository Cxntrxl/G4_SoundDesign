using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSounds : MonoBehaviour
{
    public AudioSource hoverSound;
    public AudioSource clickSound;

    private void Start()
    {
        clickSound = GameObject.Find("btn_clickEvent_audioSource").GetComponent<AudioSource>();
    }

    public void OnButtonHover()
    {
        hoverSound.Play();
    }

    public void OnButtonClick()
    {
        clickSound.Play();
    }
}
