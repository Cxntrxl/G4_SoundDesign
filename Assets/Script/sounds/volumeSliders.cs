using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeSliders : MonoBehaviour
{
    public AudioMixer mixer;
    public string soundType;
    
    public void SetSound(float soundLevel)
    {
        mixer.SetFloat(soundType, soundLevel);
    }
}
