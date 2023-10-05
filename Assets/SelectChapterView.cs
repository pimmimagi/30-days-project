using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChapterView : MonoBehaviour
{
    public Button Day1Button;
    public Button Day2Button;
    public GameObject SelectChapterPanel;
    public GameObject ChatAppPanel;
    public GameObject ChatCellGameObject;
    public ChatCellView ChatCellView;
    public ChatlistView ChatlistView;
    private Chapterpod chapterPod;
    private CharacterPod characterPod;
    private ChatAppPanelPod chatAppPanelPod;
    public List<ChatCellView> Day1List;
    public GameObject ChatlistCell;


    public void Start()
    {
        chapterPod = Chapterpod.Instance;
        characterPod = CharacterPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;
        SetupButtonListener();

    }


    private void SetupButtonListener()
    {    
       
        Day1Button.onClick.AddListener(() =>
        {
            ButtonSetting();
            ChapterTemplateScriptableObject chapter1 = chapterPod.GetChapterByIndex(0);
            LoopCharacters(chapter1);
            ChatlistCell.SetActive(false);

        });
        Day2Button.onClick.AddListener(() =>
        {
            ButtonSetting();
            ChapterTemplateScriptableObject chapter2 = chapterPod.GetChapterByIndex(1);
            LoopCharacters(chapter2);
            ChatlistCell.SetActive(false);

        });
    }

    public void ButtonSetting()
    {
        SelectChapterPanel.SetActive(false);
        ChatAppPanel.SetActive(true);
        chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);
    }
    public void LoopCharacters(ChapterTemplateScriptableObject chapter)
    {
        foreach (var characterAndConversation in chapter.DataEachConversation)
        {
            SetChatCellView(characterAndConversation.CharacterChat);
        }
    }

    public void SetChatCellView(CharacterTemplateScriptableObject character)
    {
        ChatCellView newChatCellView = ChatlistView.CreateChatCell();
        newChatCellView.Bind(characterPod.GetCharacterBeanByID(character.IDCharacter));
        Debug.Log(character.IDCharacter);
        newChatCellView.gameObject.SetActive(true);
    }

}

