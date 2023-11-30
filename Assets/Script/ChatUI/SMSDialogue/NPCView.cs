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
            if (NameTextNPC.text == "Poom")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(2));
            }
            if (NameTextNPC.text == "PyunAWish")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(4));
            }
            if (NameTextNPC.text == "ภาระรีมภรีม")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(6));
            }
            NPCPopUpStatus.SetActive(true);
        });
    }
}
