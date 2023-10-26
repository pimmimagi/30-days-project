using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatCellView : MonoBehaviour
{
    [Header("Character Data UI")]
    [SerializeField] private TMP_Text Currenttext;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private TMP_Text CharacterNameText;
    [SerializeField] private Image Notification;

    [Header("Sound Manager")]
    private SoundManager soundManager;

    [Header("Button")]
    [SerializeField] private Button ChatBoxChatAppButton;
    [SerializeField] private Button ButtonImage;

    [Header("SMSConversation")]
    [SerializeField] private SMSConversation SMSconversation;

    [Header("HeaderChatUI")]
    [SerializeField] private HeaderChatUIView headerChatUIView;

    [Header("GameObject")]
    [SerializeField] private GameObject EndPanel;

    [Header("Pod")]
    private PlayerPod playerpod;
    private CharacterPod characterpod;
    private ChatAppPanelPod chatAppPanelPod;
    private Chapterpod chapterpod;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterpod = CharacterPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;
        chapterpod = Chapterpod.Instance;
        soundManager = SoundManager.Instance;
    }

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
        Currenttext.text = data.CurrentChatText;

        SetupButtonListener(data.characterData.IDCharacter);
    }

    private void SetupButtonListener(int characterID)
    {
        ChatBoxChatAppButton.onClick.AddListener(() =>
        {
            ChatBoxOnclick(characterID);
        });

        ButtonImage.onClick.AddListener(() =>
        {
            soundManager.PlayClickSound();
            playerpod.UpdatePlayerIsReadingID(characterID);
            chatAppPanelPod.ChangeChatState(ChatAppState.PopupProfilePanel);
        });
    }

    public void ChatBoxOnclick(int characterID)
    {
        playerpod.UpdatePlayerIsReadingID(characterID);
        chatAppPanelPod.ChangeChatState(ChatAppState.ChatPanel);

        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerpod.current_date - 1);
        headerChatUIView.Bind(characterpod.GetCharacterBeanByID(playerpod.PlayerReadingID));
        SMSconversation.StartSMSConversation(chapter.DataEachConversation[playerpod.PlayerReadingConversationIndex].Conversation);

        characterpod.UpdateCheckPlayerReadMessageAlready(playerpod.PlayerReadingID, true);
        SetNotificationChat();
        EndPanel.SetActive(false);
        characterpod.UpdatePlayerisReadingThisCharacter(playerpod.PlayerReadingID, true);
    }

    public void SetNotificationChat()
    {
        CharacterBean characterBean = characterpod.GetCharacterBeanByID(playerpod.PlayerReadingID);
        Notification.gameObject.SetActive(!characterBean.CheckPlayerReadMessageAlready);
    }
}
