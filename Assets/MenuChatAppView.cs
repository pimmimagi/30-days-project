using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChatAppView : MonoBehaviour
{
    public Button HomeButton;

    private void Start()
    {
        SetupButtonListener();
    }
    private void SetupButtonListener()
    {
        HomeButton.onClick.AddListener(() =>
        {
            MoveToScene(3);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
