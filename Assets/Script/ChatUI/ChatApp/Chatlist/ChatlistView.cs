using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChatlistView : MonoBehaviour
{
    public ChatCellView ChatlistCellViewPie;
    //public ChatCellView ChatlistCellViewF;
    //public ChatCellView ChatlistCellGroup;
    //public GameObject CellViewFGameObject;
   // public GameObject CellViewPieGameObect;
   // public GameObject CellView30DaysGroupObject;
    public HeaderChatUIView headerChatUIView;
    private bool StartFirstTime = true;
    [SerializeField] private CharacterPod characterPod;
    private PlayerPod playerPod;
    public GameObject PopUpProfilePanel;
    private List<GameObject> instantiatedChatCells = new List<GameObject>();
    public GameObject ChatCellPrefab;


    public void Init()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        characterPod.LoadCharacterData();
        //UpdateChatCellsPie();
        //UpdateChatCellF();
        //UpdateChatCellGroup();
        
    }
     //TODO Refactor 
    public void UpdateChatCellsPie()
    { 
        CharacterBean characterBeenID3 = characterPod.GetCharacterBeanByID(3);
        
        ChatlistCellViewPie.Bind(characterBeenID3);
        //ChatlistCellViewPie.SetNotificationChat();
    }
    public void UpdateChatCellF()
    {
        CharacterBean characterBeanID0 = characterPod.GetCharacterBeanByID(0);
        //ChatlistCellViewF.Bind(characterBeanID0);
        //ChatlistCellViewF.SetNotificationChat();
    }

    public void UpdateChatCellGroup()
    {
        CharacterBean characterBeanID2 = characterPod.GetCharacterBeanByID(2);
        //ChatlistCellGroup.Bind(characterBeanID2);
       // ChatlistCellGroup.SetNotificationChat();
    }

    public ChatCellView CreateChatCell()
    {
        GameObject newChatCellView = Instantiate(ChatCellPrefab, transform);
        ChatCellView chatCellViewComponent = newChatCellView.GetComponent<ChatCellView>();

        if (chatCellViewComponent != null)
        {
            instantiatedChatCells.Add(newChatCellView);
        }
        else
        {
            Destroy(newChatCellView);
            return null;
        }
        return chatCellViewComponent;
    }

    public void DestroyChatCell()
    {
        foreach (GameObject chatCell in instantiatedChatCells)
        {
            Destroy(chatCell);
        }
        instantiatedChatCells.Clear();
    }
}
    
   



