using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChatlistView : MonoBehaviour
{
    public ChatCellView ChatlistCellViewPie;
    public ChatCellView ChatlistCellViewF;
    public GameObject CellViewFGameObject;
    public GameObject CellViewPieGameObject;
    private CharacterPod characterPod;
    private PlayerPod playerPod;


    private void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        // Debug.Log("Status before ChangeLoadCharacter : " + characterPod.CheckLoadCharacterdata);
        characterPod.LoadCharacterData();
        // Debug.Log("Status after ChangeLoadCharacter : " +  characterPod.CheckLoadCharacterdata);
        UpdateChatCellsPie(); // Update chat cells once at the start.
    }

    // Call this method whenever there's a new message or when the chat cell becomes active/visible.
    public void UpdateChatCellsPie()
    {
        CharacterBean characterBeenID3 = characterPod.GetCharacterBeanByID(3);
        ChatlistCellViewPie.Bind(characterBeenID3);
    }
    public void UpdateChatCellF()
    {
        CharacterBean characterBeanID0 = characterPod.GetCharacterBeanByID(0);
        ChatlistCellViewF.Bind(characterBeanID0);
    }
}
    
   
/*
        if(playerPod.current_date == 2)
        {
            characterBeanID0.CurrentChatText =  "ฮัลโหล";
            CellViewFGameObject.SetActive(true);
            Debug.Log("Set active already");
            ChatlistCellViewF.Currenttext.text = characterBeanID0.CurrentChatText;

        }
    }*/


