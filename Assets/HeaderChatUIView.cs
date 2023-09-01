using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeaderChatUIView : MonoBehaviour
{
    public Button BackChatUIButton;
    private CharacterPod characterPod;

    private void Start()
    {
        SetupButtonListener();
        characterPod = CharacterPod.Instance;
    }
    private void SetupButtonListener()
    {
        BackChatUIButton.onClick.AddListener(() =>
        {
            MoveToScene(4);
            characterPod.CheckLoadCharacterdata = true;
            Debug.Log("Status after click back" + characterPod.CheckLoadCharacterdata);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
