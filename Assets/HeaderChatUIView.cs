using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaderChatUIView : MonoBehaviour
{
    public Button BackChatUIButton;

    private void Start()
    {
        SetupButtonListener();
    }
    private void SetupButtonListener()
    {
        BackChatUIButton.onClick.AddListener(() =>
        {
            MoveToScene(4);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
