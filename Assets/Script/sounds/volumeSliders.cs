using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSliders : MonoBehaviour
{
    public AudioMixer mixer;
    public string soundType;

    private void Start()
    {
        float soundLevel;
        mixer.GetFloat(soundType, out soundLevel);
        this.GetComponent<Slider>().value = soundLevel;
    }

    public void SetSound(float soundLevel)
    {
        mixer.SetFloat(soundType, soundLevel);
    }
}
