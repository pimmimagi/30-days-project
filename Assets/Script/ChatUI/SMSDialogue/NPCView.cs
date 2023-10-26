using UnityEngine;
using UnityEngine.UI;

public class NPCView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button NPCProfileButton;

    [Header("GameObject")]
    [SerializeField] private GameObject NPCPopUpStatus;

    [Header("RelationshipCellView")]
    [SerializeField] private RelationshipCellView NPCPopup;

    [Header("SoundManager")]
    private SoundManager soundManager;

    [Header("Character Name")]
    [SerializeField] private Text NameTextNPC;

    [Header("Pod")]
    private ChatAppPanelPod chatAppPanelPod;
    private CharacterPod characterPod;

    private void Start()
    {
        chatAppPanelPod = ChatAppPanelPod.Instance;
        characterPod = CharacterPod.Instance;
        soundManager = SoundManager.Instance;

        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        NPCProfileButton.onClick.AddListener(() =>
        {
            chatAppPanelPod.ChangeChatState(ChatAppState.PopupProfilePanel);
            soundManager.PlayClickSound();

            if (NameTextNPC.text == "Pie")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(3));
            }
            if (NameTextNPC.text == "เอฟ")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(0));
            }
            NPCPopUpStatus.SetActive(true);
        });
    }
}
