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
    private PlayerPod playerpod;

    private void Start()
    {
        characterpod = CharacterPod.Instance;
        playerpod = PlayerPod.Instance;
        characterpod.LoadCharacterData();
        CharacterBean characterBeanID0 = characterpod.GetCharacterBeanByID(0);
        CharacterBean characterBeanID3 = characterpod.GetCharacterBeanByID(3);
        NotificationCondition();
        
    }

    private void Update()
    {
        NotificationCondition();
    }

    public void NotificationCondition()
    {
        CharacterBean characterBeanID0 = characterpod.GetCharacterBeanByID(0);
        CharacterBean characterBeanID3 = characterpod.GetCharacterBeanByID(3);
        if (playerpod.NumberofNotification == 0)
        {
            NotificationPopUp.Bind(characterBeanID3);
            playerpod.NumberofNotification = playerpod.NumberofNotification + 1;
        }
        if (playerpod.NumberofNotification == 1)
        {
            NotificationPopUp.Bind(characterBeanID0);
            playerpod.NumberofNotification = playerpod.NumberofNotification + 1;
        }
    }


}

