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
    private ChatAppPanelPod chatAppPanelPod;
    private SoundManager soundManager;
    public TMP_Text CharacterNameText;


    private void Start()
    {
        SetupButtonListener();
        soundManager = SoundManager.Instance;
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;

    }
 
    private void SetupButtonListener()
    {
        BackChatUIButton.onClick.AddListener(() =>
        {
            characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID).CheckPlayerReadMessageAlready = false;
            characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID).PlayerisReadingThisCharacter = false;
            characterPod.CheckLoadCharacterdata = true;
            chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);
            soundManager.PlayClickSound();
        });
    }

    public void Bind(CharacterBean data)
    {
        CharacterNameText.text = data.characterData.NameText;
    }

  
}
