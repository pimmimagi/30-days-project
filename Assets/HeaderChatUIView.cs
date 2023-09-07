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
        SetUpBind();
   
        

    }
    private void Update()
    {
        SetUpBind();
    }
    private void SetupButtonListener()
    {
        BackChatUIButton.onClick.AddListener(() =>
        {
            //MoveToScene(6);
            playerPod.ReadAlready = false;
            playerPod.SetReadingMessageFalseAll();
            characterPod.CheckLoadCharacterdata = true;
            clickSound.Play();
            Debug.Log("Sound has play");
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

    public void SetUpBind()
    {
        CharacterBean characterBeenID3 = characterPod.GetCharacterBeanByID(3);
        CharacterBean characterBeanID0 = characterPod.GetCharacterBeanByID(0);
        if (playerPod.PlayerReadingMessagePie == true)
        {
            Bind(characterBeenID3);
        }
        Debug.LogError("Status F : " + playerPod.PlayerReadingMessageF);
        if (playerPod.PlayerReadingMessageF == true)
        {
            Bind(characterBeanID0);
        }
    }
}
