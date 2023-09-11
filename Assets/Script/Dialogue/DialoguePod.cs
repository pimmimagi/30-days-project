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
    public GameObject ENDChapter;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        foreach (Actor actor in DialogueManager.masterDatabase.actors)
        {
            Debug.Log("Actor " + actor.Name);
        }
    }
    public void OnConversationLine(Subtitle subtitle)
    {
        Debug.Log("Received text from dialogue: " + subtitle.formattedText.text);

        if (playerpod.PlayerReadingMessagePie.Value)
        {
            playerpod.PlayerReadingMessage30DaysGroup.Value = false;
            Debug.LogError("Update Pie");
            characterPod.UpdateCurrentChatText(3, subtitle.formattedText.text);
            chatlistView.UpdateChatCellsPie();
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessagePie.Value = false;
                // ResponseBox.SetActive(false);
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
            Debug.LogError("Update F");
            characterPod.UpdateCurrentChatText(0, subtitle.formattedText.text);
            chatlistView.UpdateChatCellF();
            if (!DialogueManager.currentConversationState.hasAnyResponses)
            {
                playerpod.PlayerReadingMessageF.Value = false;
                // ResponseBox.SetActive(false);
                //notificationCellView.SetActive();
                //chatlistView.CellViewFGameObject.gameObject.SetActive(true);
                playerpod.current_date = 2;
                playerpod.IsPlaying.Value = !playerpod.IsPlaying.Value; 
            }
        }
        if (playerpod.PlayerReadingMessage30DaysGroup.Value)
        {
            Debug.LogError("Update Chat Group");
            characterPod.UpdateCurrentChatText(2, subtitle.formattedText.text);
            Debug.LogError(characterPod.GetCharacterBeanByID(2).CurrentChatText);
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
    //public void EndChapter()
   // {
     //   if (playerpod.isplaying == false)
      //  {
      //      ENDChapter.SetActive(true);
      //  }
     //   ENDChapter.SetActive(false);
  //  }

 
}

