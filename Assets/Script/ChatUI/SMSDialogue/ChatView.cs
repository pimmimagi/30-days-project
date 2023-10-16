using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Diagnostics.Contracts;
using UniRx;
using System;

public class ChatView: MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    private Chapterpod chapterpod;
    public NotificationCellView notificationCellView;
    public HeaderChatUIView headerChatUIView;
    public ChatlistView chatlistView;
    public SelectChapterView SelectChapterView;
    public GameObject ContinuePanel;


    public void Init()
    {
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        chapterpod = Chapterpod.Instance;
        headerChatUIView.Bind(characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID));

    }

    public void OnConversationLine(Subtitle subtitle)
    {
        if (characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID).PlayerisReadingThisCharacter == true)
        {
            characterPod.UpdateCurrentChatText(playerpod.PlayerReadingID, subtitle.formattedText.text);
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                CheckEndOfConversation();
                characterPod.UpdatePlayerisReadingThisCharacter(playerpod.PlayerReadingID, false);
            }
        }

    }

    public void CheckEndOfConversation()
    {
     
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerpod.current_date - 1);
        if (playerpod.PlayerReadingConversationIndex == chapter.DataEachConversation.Length - 1)
        {
            Debug.Log("Run if");
            playerpod.current_date += 1;
            playerpod.PlayerReadingConversationIndex = 0;
            SetContinueActive();
  
        }
        else if (playerpod.PlayerReadingConversationIndex < chapter.DataEachConversation.Length - 1)
        {
            Debug.LogError(playerpod.PlayerReadingConversationIndex);
            Debug.LogError(chapter.DataEachConversation.Length - 1);
            playerpod.PlayerReadingConversationIndex += 1;
            SelectChapterView.LoopCharacters(chapter);
            Debug.Log("Run else if");
        }
        characterPod.UpdateCurrentChatText(playerpod.PlayerReadingID, "คุณมีข้อความใหม่");
    }

    public void SetContinueActive()

    {
        Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(_ => {
            ContinuePanel.SetActive(true);
          

        });


    }

}




