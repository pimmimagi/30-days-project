using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallView : MonoBehaviour
{
    [Header("Character Data UI")]
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image CharacterProfile;

    public void Bind(CharacterBean data)
    {
        NameText.text = data.characterData.NameText;
        CharacterProfile.sprite = data.characterData.ProfileSprite;
    }
}

