using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class RelationShipNotificationView : MonoBehaviour
{

    public GameObject RelationshipNotificationPanel;
    public TMP_Text NameText;
    public Image CharacterImage;
    public TMP_Text Relationshiptext;
    private CharacterPod characterPod;
    private PlayerPod playerPod;


    void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        RelationshipNotificationPanel.SetActive(false);
        Lua.RegisterFunction("UpdateRelationshipScore", this, typeof(RelationShipNotificationView).GetMethod("UpdateRelationshipScore"));
    }

    public void UpdateRelationshipScore(string NPCname, string score)
    {
        NameText.text = NPCname;
        BindImageWithNameNPC(NPCname);
        Relationshiptext.text = "ค่าความสนิทกับ" + " " + NPCname + " " + "เพิ่มขึ้น  + " + score;
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
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
