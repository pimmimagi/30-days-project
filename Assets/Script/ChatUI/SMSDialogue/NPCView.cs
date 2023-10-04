using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using TMPro;
using UniRx.Triggers;

public class NPCView : MonoBehaviour
{
    public Button NPCProfileButton;
    public GameObject NPCPopUpStatus;
    public RelationshipCellView NPCPopup;
    private ChatAppPanelPod chatAppPanelPod;
    private CharacterPod characterPod;
    private SoundManager soundManager;
    public Text NameTextNPC;
    public StandardUISubtitlePanel StandardUISubtitlePanel;
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

            //StandardUISubtitlePanel.currentSubtitle.speakerInfo.id

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
