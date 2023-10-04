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
    private void Start()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
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
        chatView.Init();
    }

    public void RunPopUpProfilePanel()
    {
        popUpProfileWidgetView.Init();
    }

    public void RunChatlistPanel()
    {
        chatlistView.Init();
    }
    public void RunSelecChapter()
    {
        //selectChapterView.Init();
    }
}