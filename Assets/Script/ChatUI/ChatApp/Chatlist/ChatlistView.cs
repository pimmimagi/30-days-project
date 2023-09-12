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
    public ChatCellView ChatlistCellGroup;
    public GameObject CellViewFGameObject;
    public GameObject CellViewPieGameObject;
    public GameObject CellView30DaysGroupObject;
    private CharacterPod characterPod;
    private PlayerPod playerPod;


    private void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        characterPod.LoadCharacterData();
        UpdateChatCellsPie();
        UpdateChatCellF();
        UpdateChatCellGroup();
    }
    private void Update()
    {
        UpdateChatCellsPie();
        UpdateChatCellF();
        UpdateChatCellGroup();
    }
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

    public void UpdateChatCellGroup()
    {
        CharacterBean characterBeanID2 = characterPod.GetCharacterBeanByID(2);
        ChatlistCellGroup.Bind(characterBeanID2);
    }
}
    
   



