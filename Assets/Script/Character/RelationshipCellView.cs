using Doozy.Runtime.UIManager.Triggers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipCellView : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image CharacterImage;

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        NameText.text = data.characterData.NameText;
    }

}
