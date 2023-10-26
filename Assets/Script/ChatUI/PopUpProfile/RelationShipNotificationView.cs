using PixelCrushers.DialogueSystem;
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
    }
}
