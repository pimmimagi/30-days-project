using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Diagnostics.Contracts;

public class DialoguePod : MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    public NotificationCellView notificationCellView;
    public ChatlistView chatlistView;
    public GameObject ResponseBox;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
    }

    public void OnConversationLine(Subtitle subtitle)
    {
        Debug.Log("Received text from dialogue: " + subtitle.formattedText.text);

        if (playerpod.PlayerReadingMessagePie)
        {
            Debug.LogError("Update Pie");
            characterPod.UpdateCurrentChatText(3, subtitle.formattedText.text);
            chatlistView.UpdateChatCellsPie();
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessagePie = false;
               // ResponseBox.SetActive(false);
                notificationCellView.SetActive();
                chatlistView.CellViewFGameObject.gameObject.SetActive(true);
            }
        }

        if (playerpod.PlayerReadingMessageF)
        {
            Debug.LogError("Update F");
            characterPod.UpdateCurrentChatText(0, subtitle.formattedText.text);
            chatlistView.UpdateChatCellF();
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessageF = false;
                // ResponseBox.SetActive(false);
                //notificationCellView.SetActive();
                //chatlistView.CellViewFGameObject.gameObject.SetActive(true);
                playerpod.current_date = 2;
            }
        }
    }

    public void EndConversation1()
    {
        playerpod.PlayerReadingMessagePie = false;
        ResponseBox.SetActive(false);


        // notificationCellView.NotificationPopUp.gameObject.SetActive(true);
        if (playerpod.PlayerReadChat1 == false)
        {
            notificationCellView.SetActive();
            playerpod.PlayerReadChat1 = true;
        }
        //notificationCellView.NumberOfNotification.gameObject.SetActive(true);
        Debug.Log("current date is = " + playerpod.current_date);
        Debug.Log("current text of index 0 is" + characterPod.GetCharacterBeanByID(0).CurrentChatText);
        Debug.Log("current text of index 3 is" + characterPod.GetCharacterBeanByID(3).CurrentChatText);
        chatlistView.CellViewFGameObject.gameObject.SetActive(true);
    }
    public void OnConversationEnd(Transform actor)
    {
        Debug.Log("THE CONVERSATION ENDED!!!");
    }
}

