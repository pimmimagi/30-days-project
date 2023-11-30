using System.Collections.Generic;
using UnityEngine;

public class ChatlistView : MonoBehaviour
{
    [Header("ChatCellView")]
    [SerializeField] private ChatCellView ChatlistCellView;

    [Header("SelectChapterView")]
    [SerializeField] private SelectChapterView SelectChapterView;

    [Header("HeaderChatUIView")]
    [SerializeField] private HeaderChatUIView headerChatUIView;

    [Header("GameObject")]
    [SerializeField] private GameObject PopUpProfilePanel;
    [SerializeField] private GameObject ChatCellPrefab;

    [Header("InstantiatedChatCells List")]
    private List<GameObject> instantiatedChatCells = new List<GameObject>();

    [Header("Pod")]
    private CharacterPod characterPod;

    public void Init()
    {
        characterPod = CharacterPod.Instance;
        characterPod.LoadCharacterData();
        Debug.LogError(characterPod.GetCharacterBeanByID(4));
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
    
   



