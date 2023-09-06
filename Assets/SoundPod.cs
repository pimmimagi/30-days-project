using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPod : MonoBehaviour
{
    public AudioSource audioSorce;
    public void PlaySound()
    {
        audioSorce.Play();
    }
}
