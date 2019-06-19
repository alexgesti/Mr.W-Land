using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeOptions : MonoBehaviour 
{
    public AudioMixer audioMusic;
    public AudioMixer audioEffects;

    public void SetVolume(float Volume)
	{
		audioMusic.SetFloat ("Volume", Volume);
	}

    public void SetEffects(float Effects)
    {
        audioEffects.SetFloat ("Volume", Effects);
    }
}
