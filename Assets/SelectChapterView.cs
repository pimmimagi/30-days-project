using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SelectChapterView : MonoBehaviour
{
    public Button Day1Button;
    public Button Day2Button;
    public GameObject SelectChapterPanel;
    public GameObject ChatAppPanel;
    public GameObject ChatCellGameObject;
    public ChatCellView ChatCellView;
    public ChatlistView chatlistView;
    private Chapterpod chapterPod;
    private CharacterPod characterPod;
    private ChatAppPanelPod chatAppPanelPod;
    private PlayerPod playerPod;
    public List<ChatCellView> Day1List;
    public GameObject ChatlistCell;
    public GameObject LockDay2;
    public GameObject LockDay3;
    public Button PlayDay1;
    public GameObject SMSDialogue;


    public void Init()
    {
        playerPod = PlayerPod.Instance;
        chapterPod = Chapterpod.Instance;
        characterPod = CharacterPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;
        SetupButtonListener();
        SetupSubscribe();

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
            //chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);
            //ChatlistCell.SetActive(false);


        });
        Day2Button.onClick.AddListener(() =>
        {
            chatlistView.DestroyChatCell();
            ButtonSetting();
            ChapterTemplateScriptableObject chapter2 = chapterPod.GetChapterByIndex(playerPod.current_date - 1);
            LoopCharacters(chapter2);
            SMSDialogue.SetActive(true);
            //ChatlistCell.SetActive(false);

        });

        PlayDay1.onClick.AddListener(() =>
        {
            SelectChapterPanel.SetActive(false);
            ChatAppPanel.SetActive(true);
        });

     }
    

    private void SetupSubscribe()
    {
        playerPod.IsPlaying.Subscribe(Isplaying =>
        {
            if (Isplaying)
            {
               //PlayDay1.gameObject.SetActive(true);
            }
            else
            {
                //PlayDay1.gameObject.SetActive(false);

            }
        }).AddTo(this);
    }



    public void ButtonSetting()
    {
        SelectChapterPanel.SetActive(false);
        ChatAppPanel.SetActive(true);
        //chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);
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
        Debug.LogError("Create New Chat");
        newChatCellView.Bind(characterPod.GetCharacterBeanByID(character.IDCharacter));
        newChatCellView.gameObject.SetActive(true);
    }


    public void SetUnlockChapter()
    {
        Debug.Log(playerPod.current_date);
        if (playerPod.current_date == 2)
        {
            LockDay2.SetActive(false);
        }
        
        else if (playerPod.current_date == 3)
        {
            LockDay3.SetActive(false);
        }
        else
        {
            Debug.Log("Is day 1");
        }
    }
}

