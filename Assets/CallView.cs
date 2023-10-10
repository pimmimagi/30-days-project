using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallView : MonoBehaviour
{
    public TMP_Text NameText;
    public Image CharacterProfile;
    public TMP_Text NameTextAcceptCall;
    public Image CharacterProfileAcceptCall;
    public TMP_Text NPCNameText;

    public void Bind(CharacterBean data)
    {
        NameText.text = data.characterData.NameText;
        CharacterProfile.sprite = data.characterData.ProfileSprite;
        NameTextAcceptCall.text = data.characterData.NameText;
        CharacterProfileAcceptCall.sprite = data.characterData.ProfileSprite;
        NPCNameText.text = data.characterData.NameText;
    }
}

