using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UniRx;
using PixelCrushers.DialogueSystem;

public class ChatAppPanelView : MonoBehaviour
{
    [SerializeField] private ChatAppPanelPod ChatAppPod;
    public ChatlistView chatlistView;
    public PopUpProfileWidgetView popUpProfileWidgetView;
    public HeaderChatUIView headerChatUIView;
    public ChatView chatView;
    public SelectChapterView selectChapterView;
    private CharacterPod characterPod;
    private PlayerPod playerPod;
    private Chapterpod chapterPod;
    public GameObject SelectChapterPanel;
    private void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        chapterPod = Chapterpod.Instance;
        ChatAppPod = ChatAppPanelPod.Instance;
        SetupSubscribe();
    }
    private void SetupSubscribe()
    {
        ChatAppPod.ChatState.Subscribe(state =>
        {
            OnChatStateChange(state);
        }).AddTo(this);
    }

    public void OnChatStateChange(ChatAppState state)
    {
        Debug.Log(state);
        switch (state)
        {
            case ChatAppState.ChatPanel:
                RunChatUIPanel();
                break;
            case ChatAppState.PopupProfilePanel:
                RunPopUpProfilePanel();
                break;
            case ChatAppState.ChatListPanel:
                RunChatlistPanel();
                break;
            case ChatAppState.SelectChapter:
                RunSelecChapter();
                break;
        }
    }

    public void RunChatUIPanel()
    {
        Debug.Log("Run ChatUIPanel");
        chatView.Init();
    }

    public void RunPopUpProfilePanel()
    {
        Debug.Log("Run PopUpProfilePanel");
        popUpProfileWidgetView.Init();
    }

    public void RunChatlistPanel()
    {
        Debug.Log("Run ChatlistPanel");
        chatlistView.Init();
        chatlistView.DestroyChatCell();
        //chatlistView.CreateChatCell();

    }
    public void RunSelecChapter()
    {
        selectChapterView.Init();
        Debug.Log("Run SelecChapter");
        SelectChapterPanel.SetActive(true);
        chatlistView.DestroyChatCell();
        selectChapterView.SetUnlockChapter();
    }

}