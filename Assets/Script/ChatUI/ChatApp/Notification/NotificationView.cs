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
        Lua.RegisterFunction("NotificationCharacter", this, typeof(NotificationView).GetMethod("NotificationCharacter"));

        characterpod = CharacterPod.Instance;
        playerpod = PlayerPod.Instance;

        characterpod.LoadCharacterData();
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

        if (characterpod.GetCharacterBeanByID(playerpod.PlayerReadingID).PlayerisReadingThisCharacter == true)
        {
            NotificationPopUp.SetActive();
        }
    }
}

