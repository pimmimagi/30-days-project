using PixelCrushers.DialogueSystem;
using UnityEngine;

public class NPCIChatView : MonoBehaviour
{
    [Header("NPCImageTemplate")]
    [SerializeField] private NPCImageView NPCImageTemplate;

    [Header("NPCChatView")]
    [SerializeField] private NPCImageView npcImageView;

    [Header("Pod")]
    private PlayerPod playerPod;
    private CharacterPod characterPod;

    [Header("Content")]
    public Transform Content;
    //public bool isTemplate = true;

    void Start()
    {
    //    if (isTemplate)
    //        gameObject.SetActive(false);
        playerPod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        Lua.RegisterFunction("CreateNPCImageTemplate", this, SymbolExtensions.GetMethodInfo(() => CreateNPCImageTemplate()));
        npcImageView.Bind(characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID));
    }

    public void CreateNPCImageTemplate()
    {
        NPCImageView newNPCImageTemplate = Instantiate(NPCImageTemplate, transform.parent);
        newNPCImageTemplate.isTemplate = false;
        newNPCImageTemplate.gameObject.SetActive(true);
        newNPCImageTemplate.transform.SetParent(Content);
        npcImageView.Bind(characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID));
    }
}

