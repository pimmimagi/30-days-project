using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundclick : MonoBehaviour
{
    public static Soundclick Instance { get; private set; }

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

    public AudioSource AudioSource;

    public void PlaySound()
    {
        AudioSource.Play();
    }
}

