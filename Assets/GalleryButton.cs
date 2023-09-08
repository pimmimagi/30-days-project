using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryButton : MonoBehaviour
{
    // Start is called before the first frame update
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