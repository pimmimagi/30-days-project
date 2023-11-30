using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NotificationView : MonoBehaviour
{
    [Header("NotificationCellView")]
    [SerializeField] private NotificationCellView NotificationPopUp;

    [Header("Pod")]
    private CharacterPod characterpod;
    private PlayerPod playerpod;

    private void Start()
    {
        characterpod = CharacterPod.Instance;
        playerpod = PlayerPod.Instance;

        characterpod.LoadCharacterData();
        Lua.RegisterFunction("NotificationCharacter", this, typeof(NotificationView).GetMethod("NotificationCharacter"));
    }

    public void NotificationCharacter(string Name)
    {
        if (Name == "เอฟ")
        {
            CharacterBean characterBeanID0 = characterpod.GetCharacterBeanByID(0);
            NotificationPopUp.Bind(characterBeanID0);
        }
        if (Name == "พาย")
        {
            CharacterBean characterBeanID3 = characterpod.GetCharacterBeanByID(3);
            NotificationPopUp.Bind(characterBeanID3);
        }

        if (Name == "ภูมิ")
        {
            CharacterBean characterBeanID2 = characterpod.GetCharacterBeanByID(2);
            NotificationPopUp.Bind(characterBeanID2);
        }

        if (Name == "ปุณญ์")
        {
            CharacterBean characterBeanID4 = characterpod.GetCharacterBeanByID(4);
            NotificationPopUp.Bind(characterBeanID4);
        }

        if (Name == "กลุ่มศาลา")
        {
            CharacterBean characterBeanID5 = characterpod.GetCharacterBeanByID(5);
            NotificationPopUp.Bind(characterBeanID5);
        }

        if (characterpod.GetCharacterBeanByID(playerpod.PlayerReadingID).PlayerisReadingThisCharacter == true)
        {
            NotificationPopUp.SetActiveNotification();
        }
    }
}

