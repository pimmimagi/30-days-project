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
    private PlayerPod playerPod;
    public List<ChatCellView> Day1List;
    public GameObject ChatlistCell;
    public GameObject LockDay2;
    public GameObject LockDay3;
    public GameObject SMSDialogue;


    public void Start()
    {
        playerPod = PlayerPod.Instance;
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
            ChapterTemplateScriptableObject chapter1 = chapterPod.GetChapterByIndex(playerPod.current_date-1);
            Debug.Log(playerPod.current_date - 1);
            LoopCharacters(chapter1);
            Debug.Log("Loop already");
            //ChatlistCell.SetActive(false);

        });
        Day2Button.onClick.AddListener(() =>
        {
            ButtonSetting();
            ChapterTemplateScriptableObject chapter2 = chapterPod.GetChapterByIndex(playerPod.current_date - 1);
            LoopCharacters(chapter2);
            //ChatlistCell.SetActive(false);

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
        Debug.Log("PlayerReadingConversationIndex" + playerPod.PlayerReadingConversationIndex);
        Debug.Log("DataEachConversation.Length" + chapter.DataEachConversation.Length);
        if (playerPod.PlayerReadingConversationIndex  < chapter.DataEachConversation.Length)
        {
            SetChatCellView(chapter.DataEachConversation[playerPod.PlayerReadingConversationIndex].CharacterChat);
            Debug.Log("Set Already");
        }
    }

    public void SetChatCellView(CharacterTemplateScriptableObject character)
    {
        ChatCellView newChatCellView = ChatlistView.CreateChatCell();
        newChatCellView.Bind(characterPod.GetCharacterBeanByID(character.IDCharacter));
        newChatCellView.gameObject.SetActive(true);
    }


    public void SetUnlockChapter()
    {
        Debug.LogError("SetUnlockChapter");

        if (playerPod.current_date == 2)
        {
            LockDay2.SetActive(false);
        }
        
        else if (playerPod.current_date == 3)
        {
            LockDay3.SetActive(false);
        }
    }
}

