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
    [SerializeField] public Image[] HeartImage;
    
    public CharacterPod characterPod;
    public CharacterBean characterBean;


    public void Bind(CharacterBean data)
    {

        for (int i = 0; i < HeartImage.Length; i++)
        {
           HeartImage[i].gameObject.SetActive(false);
        }
        CharacterImage.sprite = data.characterData.ProfileSprite;
        NameText.text = data.characterData.NameText;

        if (data.relationship >= 0 && data.relationship <=20)
        {
            {
                HeartImage[0].gameObject.SetActive(true);
            }
        }
        else if (data.relationship >= 21 && data.relationship <= 40)
        {
            {
                HeartImage[0].gameObject.SetActive(true);
                HeartImage[1].gameObject.SetActive(true);
            }
        }
        else if (data.relationship >= 41 && data.relationship <= 60)
        {
            {
                HeartImage[0].gameObject.SetActive(true);
                HeartImage[1].gameObject.SetActive(true);
                HeartImage[2].gameObject.SetActive(true);
            }
        }
        else if (data.relationship >= 61 && data.relationship <= 99)
        {
            {
                HeartImage[0].gameObject.SetActive(true);
                HeartImage[1].gameObject.SetActive(true);
                HeartImage[2].gameObject.SetActive(true);
                HeartImage[3].gameObject.SetActive(true);
            }
        }
        else if (data.relationship == 100)
        {
            {
                HeartImage[0].gameObject.SetActive(true);
                HeartImage[1].gameObject.SetActive(true);
                HeartImage[2].gameObject.SetActive(true);
                HeartImage[3].gameObject.SetActive(true);
                HeartImage[4].gameObject.SetActive(true);
            }
        }
    }

}
