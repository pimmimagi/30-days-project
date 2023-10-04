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
    private void LoopCharacters(ChapterTemplateScriptableObject chapter)
    {
        foreach (CharacterTemplateScriptableObject character in chapter.CharacterChat)
        {
            //Debug.Log(character);
            SetChatCellView(character);

        }
    }

    private void SetChatCellView(CharacterTemplateScriptableObject character)
    {
        switch (character.IDCharacter)
        {
            case 0:
                ChatCellView newChatCellView = ChatlistView.CreateChatCell();
                Debug.Log("Run Case 0");
                newChatCellView.Bind(characterPod.GetCharacterBeanByID(0));
                break;
            case 1:
                ChatCellView newChatCellView2 = ChatlistView.CreateChatCell();
                Debug.Log("Run Case 1");
                newChatCellView2.Bind(characterPod.GetCharacterBeanByID(1));
                break;
            case 2:
                Debug.Log("Run Case 2");
                ChatCellView newChatCellView3 = ChatlistView.CreateChatCell();
                newChatCellView3.Bind(characterPod.GetCharacterBeanByID(2));
                break;
            case 3:
                Debug.Log("Run Case 3");
                ChatCellView newChatCellView4 = ChatlistView.CreateChatCell();
                newChatCellView4.Bind(characterPod.GetCharacterBeanByID(3));
                break;
            
        }
    }

       
    }

