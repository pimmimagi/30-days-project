using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Diagnostics.Contracts;
using UniRx;

public class ChatView: MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    private Chapterpod chapterpod;
    public NotificationCellView notificationCellView;
    public HeaderChatUIView headerChatUIView;
    public ChatlistView chatlistView;
    public SelectChapterView SelectChapterView;


    public void Init()
    {
        Debug.Log("Init");
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        chapterpod = Chapterpod.Instance;
        headerChatUIView.Bind(characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID));

    }

    public void OnConversationLine(Subtitle subtitle)
    {
        Debug.Log(this.playerpod);
        Debug.Log(playerpod.PlayerReadingID);
        Debug.Log(characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID));
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
        if (playerpod.PlayerReadingConversationIndex <= chapter.DataEachConversation.Length)
        {
            playerpod.PlayerReadingConversationIndex += 1;
            SelectChapterView.LoopCharacters(chapter);
        }
        else
        {
            Debug.Log("Index out of bound");
            playerpod.PlayerReadingConversationIndex = 0;

        }
    }



}




