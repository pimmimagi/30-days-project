using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class NPCImageView : MonoBehaviour
{
    [Header("NPC UI Data")]
    [SerializeField] private Image CharacterImage;
    [SerializeField] private Text CharacterNameText;

    [Header("Pod")]
    private PlayerPod playerPod;
    private CharacterPod characterPod;

    [Header("IsTemplate boolean")]
    public bool isTemplate = true;

    void Start()
    {
        if(isTemplate)
        gameObject.SetActive(false);
        playerPod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance; 
    }

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
    }

 
}
