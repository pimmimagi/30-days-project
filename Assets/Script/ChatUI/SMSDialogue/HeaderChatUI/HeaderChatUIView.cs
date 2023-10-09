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
    private Chapterpod chapterpod;
    private SoundManager soundManager;
    public TMP_Text CharacterNameText;
    public SelectChapterView chapterView;
    public ChatlistView chatlistView;
    public GameObject chatCellView;


    private void Start()
    {
        SetupButtonListener();
        soundManager = SoundManager.Instance;
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        chapterpod = Chapterpod.Instance;
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
            //chatlistView.DestroyChatCell();
            //chatCellView.SetActive(true);
            ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
            chapterView.LoopCharacters(chapter);
            //chatCellView.SetActive(false);
            //chatlistView.CreateChatCell();
            soundManager.PlayClickSound();
        });
    }

    public void Bind(CharacterBean data)
    {
        CharacterNameText.text = data.characterData.NameText;
    }

    public void UpdateCurrentText()
    {
        
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
        chapterView.LoopCharacters(chapter);

    }
}
