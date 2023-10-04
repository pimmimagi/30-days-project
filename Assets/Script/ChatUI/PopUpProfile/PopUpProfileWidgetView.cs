using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpProfileWidgetView : MonoBehaviour
{

    private CharacterPod characterPod;
    public Button CloseButton;
    public Button FullProfilePicButton;
    public Image ProfilePic;
    public GameObject InformationPopUp;
    private PlayerPod playerPod;
    private SoundManager soundManager;
    public RelationshipCellView relationshipCellView;



    public void Init()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        soundManager = SoundManager.Instance;
        characterPod.LoadCharacterData();
        SetupButtonListener();
        relationshipCellView.Bind(characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID));
        
       
    }
    public void BindPic(CharacterBean data)
    {
        ProfilePic.sprite = data.characterData.ProfileSprite;
    }

    private void SetupButtonListener()
    {
        CloseButton.onClick.AddListener(() =>
        {
            InformationPopUp.SetActive(false);
            soundManager.PlayClickSound();

        });
    }
}