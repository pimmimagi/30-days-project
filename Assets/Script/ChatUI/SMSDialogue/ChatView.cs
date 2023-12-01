using UnityEngine;
using PixelCrushers.DialogueSystem;
using UniRx;
using System;

public class ChatView: MonoBehaviour
{
    [Header("NotificationCellView")]
    [SerializeField] private NotificationCellView notificationCellView;

    [Header("HeaderChatUIView")]
    [SerializeField] private HeaderChatUIView headerChatUIView;

    [Header("ChatlistView")]
    [SerializeField] private ChatlistView chatlistView;

    [Header("SelectChapterView")]
    [SerializeField] private SelectChapterView SelectChapterView;

    [Header("GameObject")]
    [SerializeField] private GameObject ContinuePanel;
    [SerializeField] private GameObject EndPanel;
    [SerializeField] private GameObject RespondButton;

    [Header("IsCalling Boolean")]
    [SerializeField] private bool Iscalling;

    [Header("Pod")]
    private PlayerPod playerpod;
    private CharacterPod characterPod;
    private Chapterpod chapterpod;

    private void Awake()
    {
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        chapterpod = Chapterpod.Instance;

        headerChatUIView.Bind(characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID));
    }

    private void Start()
    {
        Lua.RegisterFunction("CheckEndOfConversationforLuaCode", this, typeof(ChatView).GetMethod("CheckEndOfConversationforLuaCode"));
        Lua.RegisterFunction("SetEndAndContinueButtonActive", this, typeof(ChatView).GetMethod("SetEndAndContinueButtonActive"));
    }

    public void Init()
    {
        headerChatUIView.Bind(characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID));
    }

    public void OnConversationLine(Subtitle subtitle)
    {
        Iscalling = DialogueLua.GetVariable("NowCalling").AsBool;
        if (characterPod.GetCharacterBeanByID(playerpod.PlayerReadingID).PlayerisReadingThisCharacter == true)
        {
            Debug.Log("Is Calling = " + Iscalling);
            if (Iscalling == false)
            {
                characterPod.UpdateCurrentChatText(playerpod.PlayerReadingID, subtitle.formattedText.text);
                if (!DialogueManager.currentConversationState.hasAnyResponses)
                {
                    CheckEndOfConversation();
                    characterPod.UpdatePlayerisReadingThisCharacter(playerpod.PlayerReadingID, false);
                }
            }
            else if(Iscalling == true)
            {
                if (!DialogueManager.currentConversationState.hasAnyResponses)
                {
                    CheckEndOfConversation();
                    characterPod.UpdatePlayerisReadingThisCharacter(playerpod.PlayerReadingID, false);
                    Iscalling = false;
                }
            }
        }

    }

    public void CheckEndOfConversation()
    {
        Debug.LogError("Run CheckEndOfConversation");
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerpod.current_date - 1);
        Iscalling = DialogueLua.GetVariable("NowCalling").AsBool;
        Debug.LogError("(CheckEnd) index ที่ :" + playerpod.PlayerReadingConversationIndex);
        Debug.LogError("(CheckEnd) ความยาว chapter :" + chapter.DataEachConversation.Length);

        if (Iscalling == true)
        {
            DialogueLua.SetVariable("NowCalling", false);
        }
        else if (playerpod.PlayerReadingConversationIndex == chapter.DataEachConversation.Length - 1)
        {
            Debug.LogError("(CheckEnd) เท่ากัน");
            RespondButton.SetActive(false);
            SetEndActive();
            SetContinueActive();
        }
        else if (playerpod.PlayerReadingConversationIndex < chapter.DataEachConversation.Length - 1)
        {
            Debug.LogError("(CheckEnd) น้อยกว่า");
            playerpod.PlayerReadingConversationIndex += 1;
        }
    }

    public void SetContinueActive()
    {
        Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ => {
            ContinuePanel.SetActive(true);
        });
    }

    public void SetEndActive()
    {
        Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(_ => {
            EndPanel.SetActive(true);
        });
    }

    public void CheckEndOfConversationforLuaCode()
    {
        Debug.Log("เข้าาาาา");
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerpod.current_date - 1);
        Iscalling = DialogueLua.GetVariable("NowCalling").AsBool;

        if (Iscalling == true)
        {
            DialogueLua.SetVariable("NowCalling", false);
        }
        else if (playerpod.PlayerReadingConversationIndex == chapter.DataEachConversation.Length - 1)
        {
            RespondButton.SetActive(false);
        }
        else if (playerpod.PlayerReadingConversationIndex < chapter.DataEachConversation.Length - 1)
        {
            playerpod.PlayerReadingConversationIndex += 1;
        }
        characterPod.UpdatePlayerisReadingThisCharacter(playerpod.PlayerReadingID, false);
    }

    public void SetEndAndContinueButtonActive()
    {
        SetEndActive();
        SetContinueActive();
    }
}




