using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryCalCelllView : MonoBehaviour
{
    [Header("CHaracter Call Data UI")]
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text ChapterText;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private Image CharacterImage;

    [Header("Button")]
    [SerializeField] private Button ReplayCallButton;

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        NameText.text = data.characterData.NameText;
    }



}
