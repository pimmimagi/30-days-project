using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallView : MonoBehaviour
{
    [Header("Character Data Calling UI")]
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image CharacterProfile;

    [Header("Character Data AcceptCall UI")]
    [SerializeField] private TMP_Text NameTextAcceptCall;
    [SerializeField] private Image CharacterProfileAcceptCall;
    [SerializeField] private TMP_Text NPCNameTextAcceptCall;

    public void Bind(CharacterBean data)
    {
        NameText.text = data.characterData.NameText;
        CharacterProfile.sprite = data.characterData.ProfileSprite;

        NameTextAcceptCall.text = data.characterData.NameText;
        CharacterProfileAcceptCall.sprite = data.characterData.ProfileSprite;
        NPCNameTextAcceptCall.text = data.characterData.NameText;
    }
}

