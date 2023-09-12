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
    private CharacterPod characterPod;
    public Text NameTextNPC;

    private void Start()
    {
        characterPod = CharacterPod.Instance;
        SetupButtonListener();
    }
    private void SetupButtonListener()
    {
        NPCProfileButton.onClick.AddListener(() =>
        {
            if(NameTextNPC.text == "Pie")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(3));
                NPCPopUpStatus.SetActive(true);
            }
            
            if(NameTextNPC.text == "เอฟ")
            {
                NPCPopup.Bind(characterPod.GetCharacterBeanByID(0));
                NPCPopUpStatus.SetActive(true);
            }


        });
    }

}
