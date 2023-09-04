using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialoguePod : MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    public NotificationCellView notificationCellView;

    private void Start()
    {
        playerpod = PlayerPod.Instance; 
        characterPod = CharacterPod.Instance;
    }

    void OnConversationLine(Subtitle subtitle)
    {
        Debug.Log("Received text from dialogue: " + subtitle.formattedText.text);
        characterPod.UpdateCurrentChatText(3, subtitle.formattedText.text);
        if (subtitle.formattedText.text == "อิอิ")
        {
            playerpod.current_date += 1;
            playerpod.isplaying = false;
            //notificationCellView.NotificationPopUp.gameObject.SetActive(true);
            notificationCellView.SetActive();
           // notificationCellView.NumberOfNotification.gameObject.SetActive(true);
            Debug.Log("current date is = " + playerpod.current_date);
            Debug.Log("current text of index 0 is" + characterPod.GetCharacterBeanByID(0).CurrentChatText);
            Debug.Log("current text of index 3 is" + characterPod.GetCharacterBeanByID(3).CurrentChatText);
        }
        else if (subtitle.formattedText.text == "มึงจำอะไรไม่ได้เลยหรอ")
        {
            playerpod.current_date += 1;
            playerpod.isplaying = false;
        }
    }

}

