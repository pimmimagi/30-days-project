using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using Doozy.Runtime.Nody;

public class StartNewConversation : MonoBehaviour
{
    public GameObject CallPanel;

    //[ConversationPopup] public string conversation;



    public void StartCall(string Conversation)
    {

        // Set the Dialogue UI to use:
        DialogueManager.UseDialogueUI(CallPanel);
        DialogueLua.SetVariable("Conversation", Conversation);

        // Check if a conversation with this name already has existing data
     
        DialogueManager.StartConversation(Conversation);
        

    }
}
