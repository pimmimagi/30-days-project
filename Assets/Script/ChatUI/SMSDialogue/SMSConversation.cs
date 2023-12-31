﻿using UnityEngine;
using PixelCrushers.DialogueSystem;

public class SMSConversation : MonoBehaviour
{
    public SMSDialogueUI mySMSDialogueUI;
    public GameObject CallUI;

    //[ConversationPopup] public string conversation;
    


    public void StartSMSConversation(string Conversation)
    {
       
        // Set the Dialogue UI to use:
        DialogueManager.UseDialogueUI(mySMSDialogueUI.gameObject);
               DialogueLua.SetVariable("Conversation", Conversation);

        // Check if a conversation with this name already has existing data
              if (DialogueLua.DoesVariableExist(mySMSDialogueUI.currentDialogueEntryRecords))
                {
                    // Log already exists, so resume the conversation:
                    mySMSDialogueUI.OnApplyPersistentData();
                }
                else
                {
                    
                    DialogueManager.StartConversation(Conversation);
                }
       
    }

    public void StopSMSConversation()
    {
        mySMSDialogueUI.OnRecordPersistentData();
        DialogueManager.StopConversation();
        DialogueManager.UseDialogueUI(CallUI);
    }
}
