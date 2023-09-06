using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialoguePod : MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    public NotificationCellView notificationCellView;
    public ChatlistView chatlistView;

    private void Start()
    {
        playerpod = PlayerPod.Instance; 
        characterPod = CharacterPod.Instance;
    }

    void OnConversationLine(Subtitle subtitle)
    {
        Debug.Log("Received text from dialogue: " + subtitle.formattedText.text);

        if (playerpod.PlayerReadingMessagePie )
        {
            Debug.LogError("Update Pie");
            characterPod.UpdateCurrentChatText(3, subtitle.formattedText.text);
            chatlistView.UpdateChatCellsPie();
        }
        
        if (playerpod.PlayerReadingMessageF )
        {
            Debug.LogError("Update F");
            characterPod.UpdateCurrentChatText(0, subtitle.formattedText.text);
            chatlistView.UpdateChatCellF();
        }

        if (subtitle.formattedText.text == "อิอิ" && playerpod.current_date == 1)
        {
            playerpod.current_date += 1;
            playerpod.isplaying = false;
            playerpod.PlayerReadingMessagePie = false;
           
           // notificationCellView.NotificationPopUp.gameObject.SetActive(true);
            notificationCellView.SetActive();
            //notificationCellView.NumberOfNotification.gameObject.SetActive(true);
            Debug.Log("current date is = " + playerpod.current_date);
            Debug.Log("current text of index 0 is" + characterPod.GetCharacterBeanByID(0).CurrentChatText);
            Debug.Log("current text of index 3 is" + characterPod.GetCharacterBeanByID(3).CurrentChatText);

            if (playerpod.current_date == 2)
            {
                chatlistView.CellViewFGameObject.gameObject.SetActive(true);
                //characterBeanID0.CurrentChatText = "ฮัลโหล";
               // CellViewFGameObject.SetActive(true);
                Debug.Log("Set active already");
                //ChatlistCellViewF.Currenttext.text = characterBeanID0.CurrentChatText;

            }
        }
        else if (subtitle.formattedText.text == "มึงจำอะไรไม่ได้เลยหรอ")
        {
            playerpod.current_date += 1;
            playerpod.isplaying = false;
        }
    }

}

