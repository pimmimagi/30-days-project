using PixelCrushers.DialogueSystem;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelationShipNotificationView : MonoBehaviour
{
    [Header("Relationship Data")]
    [SerializeField] private GameObject RelationshipNotificationPanel;
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private TMP_Text Relationshiptext;

    [Header("Sound Manager")]
    private SoundManager soundManager;

    [Header("Pod")]
    private CharacterPod characterPod;

    void Start()
    {
        characterPod = CharacterPod.Instance;
        soundManager = SoundManager.Instance;

        RelationshipNotificationPanel.SetActive(false);
        Lua.RegisterFunction("UpdateRelationshipScore", this, typeof(RelationShipNotificationView).GetMethod("UpdateRelationshipScore"));
        Lua.RegisterFunction("DecreaseRelationshipScore", this, typeof(RelationShipNotificationView).GetMethod("DecreaseRelationshipScore"));
    }

    public void UpdateRelationshipScore(string NPCname, string score)
    {
        soundManager.PlayNotificationSound();
        NameText.text = NPCname;
        BindImageWithNameNPC(NPCname);
        Relationshiptext.text = "ค่าความสนิทกับ" + " " + NPCname + " " + "เพิ่มขึ้น  + " + score;
        RelationshipNotificationPanel.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(2, RelationshipNotificationPanel));
    }

    public void DecreaseRelationshipScore(string NPCname, string score)
    {
        soundManager.PlayNotificationSound();
        NameText.text = NPCname;
        BindImageWithNameNPC(NPCname);
        Relationshiptext.text = "ค่าความสนิทกับ" + " " + NPCname + " " + "ลดลง  + " + score;
        RelationshipNotificationPanel.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(2, RelationshipNotificationPanel));
    }

    public void BindImageWithNameNPC(string NPCname)
    {
        if (NPCname == "เอฟ")
        {
            CharacterImage.sprite = characterPod.GetCharacterBeanByID(0).characterData.ProfileSprite;
        }
        if (NPCname == "พาย")
        {
            CharacterImage.sprite = characterPod.GetCharacterBeanByID(3).characterData.ProfileSprite;
        }
        if (NPCname == "Poom")
        {
            CharacterImage.sprite = characterPod.GetCharacterBeanByID(2).characterData.ProfileSprite;
        }
        if (NPCname == "ปุณญ์")
        {
            CharacterImage.sprite = characterPod.GetCharacterBeanByID(4).characterData.ProfileSprite;
        }
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}


