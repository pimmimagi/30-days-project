using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipCellView : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image CharacterImage;
    [SerializeField] public Image[] HeartImage;

    public CharacterBean characterBean;

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        NameText.text = data.characterData.NameText;
        for (int i = 0; i < HeartImage.Length; i++)
        {
            HeartImage[i].gameObject.SetActive(false);
        }

        if (data.relationship == 100)
        {
            HeartImage[0].gameObject.SetActive(true);
            HeartImage[1].gameObject.SetActive(true);
            HeartImage[2].gameObject.SetActive(true);
            HeartImage[3].gameObject.SetActive(true);
            HeartImage[4].gameObject.SetActive(true);
        }
        else if (data.relationship >= 80)
        {
            HeartImage[0].gameObject.SetActive(true);
            HeartImage[1].gameObject.SetActive(true);
            HeartImage[2].gameObject.SetActive(true);
            HeartImage[3].gameObject.SetActive(true);
        }
        else if (data.relationship >= 60)
        {
            HeartImage[0].gameObject.SetActive(true);
            HeartImage[1].gameObject.SetActive(true);
            HeartImage[2].gameObject.SetActive(true);
        }
        else if (data.relationship >= 40)
        {
            HeartImage[0].gameObject.SetActive(true);
            HeartImage[1].gameObject.SetActive(true);
        }
        else if (data.relationship >=20)
        {
            HeartImage[0].gameObject.SetActive(true);
        }
    }
}
