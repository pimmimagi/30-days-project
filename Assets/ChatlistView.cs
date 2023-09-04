using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatlistView : MonoBehaviour
{
    public ChatCellView ChatlistCellViewPie;
    public ChatCellView ChatlistCellViewF;
    public GameObject CellViewFGameObject;
    public GameObject CellViewPieGameObject;
    public CharacterPod characterPod;
    public PlayerPod playerPod;


    private void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
       // Debug.Log("Status before ChangeLoadCharacter : " + characterPod.CheckLoadCharacterdata);
        characterPod.LoadCharacterData();
       // Debug.Log("Status after ChangeLoadCharacter : " +  characterPod.CheckLoadCharacterdata);
        CharacterBean characterBeenID3 = characterPod.GetCharacterBeanByID(3);
        CharacterBean characterBeanID0 = characterPod.GetCharacterBeanByID(0);
        
       ChatlistCellViewPie.Bind(characterBeenID3);
       ChatlistCellViewF.Bind(characterBeanID0);

        if(playerPod.current_date == 2)
        {
            characterBeanID0.CurrentChatText =  "ฮัลโหล";
            CellViewFGameObject.SetActive(true);
            ChatlistCellViewF.Currenttext.text = characterBeanID0.CurrentChatText;

        }
    }
}

