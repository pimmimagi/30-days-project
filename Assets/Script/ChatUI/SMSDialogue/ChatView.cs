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
    public NotificationCellView notificationCellView;
    public HeaderChatUIView headerChatUIView;
    public ChatlistView chatlistView;



    public void Init()
    {

        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        headerChatUIView.Bind(characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID));

    }

    public void OnConversationLine(Subtitle subtitle)
    {
        if (characterPod.GetCharacterBeanByID(3).PlayerisReadingThisCharacter == true)
        {
            characterPod.UpdateCurrentChatText(3, subtitle.formattedText.text);
            Debug.LogError("Update" + subtitle.formattedText.text);
            Debug.Log("Current text is " + characterPod.GetCharacterBeanByID(3).CurrentChatText);
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                characterPod.UpdatePlayerisReadingThisCharacter(3, false);
                
            }
        }

        if (characterPod.GetCharacterBeanByID(0).PlayerisReadingThisCharacter == true)
        {
            characterPod.UpdateCurrentChatText(0, subtitle.formattedText.text);
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                characterPod.UpdatePlayerisReadingThisCharacter(0, false);
                playerpod.current_date = 2;
                playerpod.UpdateIsplayingValue(false);
            }
        }
        if (characterPod.GetCharacterBeanByID(2).PlayerisReadingThisCharacter == true)
        {
            characterPod.UpdateCurrentChatText(2, subtitle.formattedText.text);


            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessage30DaysGroup.Value = false;
            }
        }
    }

}




