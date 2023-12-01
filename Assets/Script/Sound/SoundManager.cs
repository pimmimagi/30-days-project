using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("AudioSource")]
    [SerializeField] private AudioSource _musicSource, _clickSource, _notificationSource, _ringtoneSource;

    [Header("SliderView")]
    [SerializeField] private SliderView Slider;

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

    public void PlayRingtoneSound()
    {
        _ringtoneSource.Play();
    }

    public void MusicVolume(float value)
    {
        _musicSource.volume = value;
    }

    public void SFXVolume(float value)
    {
        _clickSource.volume = value;
        _notificationSource.volume = value;
        _ringtoneSource.volume = value;
    }

    public void StopRingtoneSound()
    {
        _ringtoneSource.Stop();
    }
  
    public void StopMusicSound()
    {
        _musicSource.Stop();
    }

    public void PlayMusicSound()
    {
        _musicSource.Play();
    }
}
