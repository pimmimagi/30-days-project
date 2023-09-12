using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class HeaderChatUIView : MonoBehaviour
{
    public Button BackChatUIButton;
    private CharacterPod characterPod;
    private PlayerPod playerPod;
    public AudioSource clickSound;
    public TMP_Text CharacterNameText;

    private void Start()
    {
        SetupButtonListener();
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
    }
 
    private void SetupButtonListener()
    {
        BackChatUIButton.onClick.AddListener(() =>
        {
            playerPod.SetReadingMessageFalseAll();
            characterPod.CheckLoadCharacterdata = true;
            clickSound.Play();
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Bind(CharacterBean data)
    {
        CharacterNameText.text = data.characterData.NameText;
    }

}
