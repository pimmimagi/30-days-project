using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToChatApp : MonoBehaviour
{
    public AudioSource audioSource;
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
