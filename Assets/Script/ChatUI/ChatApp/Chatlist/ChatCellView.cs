using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatCellView : MonoBehaviour
{
    public TMP_Text Currenttext;
    public Image CharacterImage;
    public TMP_Text CharacterNameText;
    private PlayerPod playerpod;
    private CharacterPod characterpod;
    private ChatAppPanelPod chatAppPanelPod;
    private Chapterpod chapterpod;
    private SoundManager soundManager;
    public Button ChatBoxChatAppButton;
    public Image Notification;
    //public GameObject NumberofNotification;
    public Button ButtonImage;
   // public PopUpProfileWidgetView PopupProfile;
    //public GameObject PopUpProfilePanel;
    public SMSConversation SMSconversation;
   

    CharacterBean characterData;

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
        characterData = data;
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
        Currenttext.text = data.CurrentChatText;
        Debug.LogError("Update current text : " + Currenttext.text);
        Debug.LogError("data.CurrentChatText : " + data.CurrentChatText);
        SetupButtonListener(data.characterData.IDCharacter);
    }

    public void BindOnlyName(CharacterBean data)
    {
        Currenttext.text = data.CurrentChatText;
    }

    private void SetupButtonListener(int characterID)
    {
        ChatBoxChatAppButton.onClick.AddListener(() =>
        {
            playerpod.UpdatePlayerIsReadingID(characterID);
            chatAppPanelPod.ChangeChatState(ChatAppState.ChatPanel);
            ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerpod.current_date - 1);
            SMSconversation.StartSMSConversation(chapter.DataEachConversation[playerpod.PlayerReadingConversationIndex].Conversation);
            characterpod.UpdateCheckPlayerReadMessageAlready(playerpod.PlayerReadingID, true);
            SetNotificationChat();
            characterpod.UpdatePlayerisReadingThisCharacter(playerpod.PlayerReadingID, true);
            

        });

        ButtonImage.onClick.AddListener(() =>
          {
              soundManager.PlayClickSound();
              playerpod.UpdatePlayerIsReadingID(characterID);
              chatAppPanelPod.ChangeChatState(ChatAppState.PopupProfilePanel);
              //PopUpProfilePanel.SetActive(true);

          });

    }

    public void SetNotificationChat()
    {
        CharacterBean characterBean = characterpod.GetCharacterBeanByID(playerpod.PlayerReadingID);
        Notification.gameObject.SetActive(!characterBean.CheckPlayerReadMessageAlready);

    }
}
