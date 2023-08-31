using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatBoxChatAppView : MonoBehaviour
{
    public Button ChatBoxChatAppButton;

    private void Start()
    {
        SetupButtonListener();
    }
    private void SetupButtonListener()
    {
        ChatBoxChatAppButton.onClick.AddListener(() =>
        {
            MoveToScene(1);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
