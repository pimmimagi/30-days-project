using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource _musicSource, _clickSource, _notificationSource;
    public SliderView Slider;

    private void Start()
    {
        Slider.LoadVolume();
        _musicSource.Play();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayClickSound()
    {
        _clickSource.Play();
    }

    public void PlayNotificationSound()
    {
        _notificationSource.Play();
    }
    public void MusicVolume(float value)
    {
        _musicSource.volume = value;
    }

    public void SFXVolume(float value)
    {
        _clickSource.volume = value;
        _notificationSource.volume = value;
    }
  
}
