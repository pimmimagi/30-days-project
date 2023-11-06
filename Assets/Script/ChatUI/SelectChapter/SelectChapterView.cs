using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChapterView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button Day1Button;
    [SerializeField] private Button Day2Button;
    [SerializeField] private Button PlayDay1;

    [Header("GameObject")]
    [SerializeField] private GameObject SelectChapterPanel;
    [SerializeField] private GameObject ChatAppPanel;
    [SerializeField] private GameObject ChatCellGameObject;
    [SerializeField] private GameObject ChatlistCell;
    [SerializeField] private GameObject LockDay2;
    [SerializeField] private GameObject LockDay3;
    [SerializeField] private GameObject SMSDialogue;
    [SerializeField] private GameObject HistoryPanel;

    [Header("ChatCellView")]
    [SerializeField] private ChatCellView ChatCellView;

    [Header("ChatListView")]
    [SerializeField] private ChatlistView chatlistView;

    [Header("DayList")]
    [SerializeField] private List<ChatCellView> Day1List;

    [Header("Pod")]
    private Chapterpod chapterPod;
    private CharacterPod characterPod;
    private ChatAppPanelPod chatAppPanelPod;
    private PlayerPod playerPod;

    public void Init()
    {
        playerPod = PlayerPod.Instance;
        chapterPod = Chapterpod.Instance;
        characterPod = CharacterPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;
        
        SetupButtonListener();
    }

    private void Update()
    {
        SetUnlockChapter();
    }

    private void SetupButtonListener()
    {    
        Day1Button.onClick.AddListener(() =>
        {
            chatlistView.DestroyChatCell();
            ButtonSetting();
            ChapterTemplateScriptableObject chapter1 = chapterPod.GetChapterByIndex(playerPod.current_date - 1);
            LoopCharacters(chapter1);
            playerPod.UpdateIsplayingValue(true);
        });

        Day2Button.onClick.AddListener(() =>
        {
            chatlistView.DestroyChatCell();
            ButtonSetting();
            ChapterTemplateScriptableObject chapter2 = chapterPod.GetChapterByIndex(playerPod.current_date - 1);
            LoopCharacters(chapter2);
            SMSDialogue.SetActive(true);
        });

        PlayDay1.onClick.AddListener(() =>
        {
            SelectChapterPanel.SetActive(false);
            ChatAppPanel.SetActive(true);
        });
     }

    public void ButtonSetting()
    {
        HistoryPanel.SetActive(false);
        SelectChapterPanel.SetActive(false);
        ChatAppPanel.SetActive(true);
        chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);
    }

    public void LoopCharacters(ChapterTemplateScriptableObject chapter)
    {
        if (playerPod.PlayerReadingConversationIndex  < chapter.DataEachConversation.Length)
        {
               SetChatCellView(chapter.DataEachConversation[playerPod.PlayerReadingConversationIndex].CharacterChat);
        }
    }

    public void SetChatCellView(CharacterTemplateScriptableObject character)
    {
        ChatCellView newChatCellView = chatlistView.CreateChatCell();
        newChatCellView.Bind(characterPod.GetCharacterBeanByID(character.IDCharacter));
        newChatCellView.gameObject.SetActive(true);
    }

    public void SetUnlockChapter()
    {
        if (playerPod.current_date == 2)
        {
            LockDay2.SetActive(false);
        }
        if (playerPod.current_date == 3)
        {
            LockDay3.SetActive(false);
        }
    }
}

