using UnityEngine;
using UnityEngine.UI;

public class PopUpProfileWidgetView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button CloseButton;
    [SerializeField] private Button FullProfilePicButton;

    [Header("Character Data UI")]
    [SerializeField] private Image ProfilePic;
    [SerializeField] private GameObject InformationPopUp;
    [SerializeField] private RelationshipCellView relationshipCellView;

    [Header("Sound Manager")]
    private SoundManager soundManager;

    [Header("Pod")]
    private PlayerPod playerPod;
    private CharacterPod characterPod;

    public void Init()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        soundManager = SoundManager.Instance;

        characterPod.LoadCharacterData();
        relationshipCellView.Bind(characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID));

        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        CloseButton.onClick.AddListener(() =>
        {
            InformationPopUp.SetActive(false);
            soundManager.PlayClickSound();
        });
    }
}