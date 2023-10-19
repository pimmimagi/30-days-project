using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Doozy.Runtime.Nody;

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
        Debug.LogError("End Conversation");
        mySMSDialogueUI.OnRecordPersistentData();
        DialogueManager.StopConversation();
        DialogueManager.UseDialogueUI(CallUI);
    }
}
