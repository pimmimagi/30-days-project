using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeaderChatUIView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button BackChatUIButton;

    [Header("Sound Manager")]
    [SerializeField] private SoundManager soundManager;

    [Header("Character Data UI")]
    [SerializeField] private TMP_Text CharacterNameText;

    [Header("SelectChapter")]
    [SerializeField] private SelectChapterView chapterView;

    [Header("ChatlistView")]
    [SerializeField] private ChatlistView chatlistView;

    [Header("GameObject")]
    [SerializeField] private GameObject chatCellView;

    [Header("Pod")]
    private CharacterPod characterPod;
    private PlayerPod playerPod;
    private ChatAppPanelPod chatAppPanelPod;
    private Chapterpod chapterpod;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        chapterpod = Chapterpod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;

        SetupButtonListener();
    }
 
    private void SetupButtonListener()
    {
        BackChatUIButton.onClick.AddListener(() =>
        {
            BackChatUIOnclick();
        });
    }

    public void BackChatUIOnclick()
    {
        characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID).CheckPlayerReadMessageAlready = false;
        characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID).PlayerisReadingThisCharacter = false;
        characterPod.CheckLoadCharacterdata = true;

        chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);
        chatlistView.DestroyChatCell();
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
        chapterView.LoopCharacters(chapter);
        soundManager.PlayClickSound();
    }

    public void Bind(CharacterBean data)
    {
        CharacterNameText.text = data.characterData.NameText;
    }

    public void UpdateCurrentText()
    {
        
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
        chapterView.LoopCharacters(chapter);

    }
}
