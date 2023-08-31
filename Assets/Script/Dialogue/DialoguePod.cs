using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DialoguePod : MonoBehaviour
{
    private PlayerPod playerpod;
    private CharacterPod characterPod;

    private void Start()
    {
        playerpod = PlayerPod.Instance; 
        characterPod = CharacterPod.Instance;
    }

   void OnConversationLine(Subtitle subtitle)
    { 
        Debug.Log("About to show the text: " + subtitle.formattedText.text);
        characterPod.UpdateCurrentChatText(subtitle.formattedText.text);
    }
}

