using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpProfileWidgetView : MonoBehaviour
{

    private CharacterPod characterPod;
    public Button CloseButton;
    public GameObject InformationPopUp;
    private PlayerPod playerPod;

    private void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        characterPod.LoadCharacterData();
        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        CloseButton.onClick.AddListener(() =>
        {
            InformationPopUp.SetActive(false);
            playerPod.PlayerReadPopUpProfileCharacter = false;

        });
    }
}