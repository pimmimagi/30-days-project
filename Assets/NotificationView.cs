using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class NotificationView : MonoBehaviour
{

    public NotificationCellView NotificationPopUp;
    private CharacterPod characterpod;

    private void Start()
    {
        characterpod = CharacterPod.Instance;
        characterpod.LoadCharacterData();
        CharacterBean characterBeenID0 = characterpod.GetCharacterBeanByID(0);
        NotificationPopUp.Bind(characterBeenID0);
    }


}

