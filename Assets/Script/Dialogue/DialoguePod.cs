using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Diagnostics.Contracts;
using UniRx;

public class DialoguePod : MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    public NotificationCellView notificationCellView;
    public ChatlistView chatlistView;
    public GameObject ResponseBox;
    public GameObject PlayingBox;


    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;

    }
    public void OnConversationLine(Subtitle subtitle)
    {
        Debug.LogError("Check value of PlayerReadingMessagePie  = " + playerpod.PlayerReadingMessagePie);
        if (playerpod.PlayerReadingMessagePie.Value)
        {
            playerpod.PlayerReadingMessage30DaysGroup.Value = false;
            characterPod.UpdateCurrentChatText(3, subtitle.formattedText.text);
            chatlistView.UpdateChatCellsPie();
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessagePie.Value = false;
                if (playerpod.NumberofNotification == 2)
                {
                    notificationCellView.SetActive();
                    playerpod.NumberofNotification = 3;
                }
                chatlistView.CellViewFGameObject.gameObject.SetActive(true);
            }
        }

        if (playerpod.PlayerReadingMessageF.Value)
        {
            characterPod.UpdateCurrentChatText(0, subtitle.formattedText.text);
            chatlistView.UpdateChatCellF();
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessageF.Value = false;
                playerpod.current_date = 2;
                playerpod.UpdateIsplayingValue(false);
            }
        }
        if (playerpod.PlayerReadingMessage30DaysGroup.Value)
        {
            characterPod.UpdateCurrentChatText(2, subtitle.formattedText.text);
            chatlistView.UpdateChatCellGroup();
           

            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessage30DaysGroup.Value = false;
                //playerpod.PlayerReadingMessageF = false;
                // ResponseBox.SetActive(false);
                //notificationCellView.SetActive();
                //chatlistView.CellViewFGameObject.gameObject.SetActive(true);
                //layerpod.current_date = 2;
            }
        }
    }

 
}

