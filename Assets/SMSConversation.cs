using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Doozy.Runtime.Nody;

public class SMSConversation : MonoBehaviour
{
    public SMSDialogueUI mySMSDialogueUI;

    [ConversationPopup] public string conversation;

    public void StartSMSConversation()
    {
        // Set the Dialogue UI to use:
        DialogueManager.UseDialogueUI(mySMSDialogueUI.gameObject);
                DialogueLua.SetVariable("Conversation", conversation);
     
        // Check if a conversation with this name already has existing data:
              if (DialogueLua.DoesVariableExist(mySMSDialogueUI.currentDialogueEntryRecords))
                {
                    // Log already exists, so resume the conversation:
                    mySMSDialogueUI.OnApplyPersistentData();
                }
                else
                {
                    // Log doesn't exist, so start the conversation for the first time:
                    DialogueManager.StartConversation(conversation);
                }
       
    }

    public void StopSMSConversation()
    {
        mySMSDialogueUI.OnRecordPersistentData();
        DialogueManager.StopConversation();
        Debug.LogError("Conversation has stop");
    }
}
