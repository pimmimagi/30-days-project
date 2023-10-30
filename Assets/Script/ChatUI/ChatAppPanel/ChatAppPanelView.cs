using UnityEngine;
using UniRx;

public class ChatAppPanelView : MonoBehaviour
{
    [Header("ChatListView")]
    [SerializeField] private ChatlistView chatlistView;

    [Header("PopUpProfile")]
    [SerializeField] private PopUpProfileWidgetView popUpProfileWidgetView;

    [Header("HeaderChatUI")]
    [SerializeField] private HeaderChatUIView headerChatUIView;

    [Header("ChatView")]
    [SerializeField] private ChatView chatView;

    [Header("AcceptCallView")]
    [SerializeField] private AcceptCallView acceptCallView;

    [Header("SelectChapter")]
    [SerializeField] private SelectChapterView selectChapterView;

    [Header("HistoryCallView")]
    [SerializeField] private HistoryCallView historyCallView;

    [Header("GameObject")]
    [SerializeField] private GameObject SelectChapterPanel;
    [SerializeField] private GameObject HistoryPanel;

    [Header("Pod")]
    private ChatAppPanelPod ChatAppPod;

    private void Start()
    {
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
            case ChatAppState.AcceptCall:
                RunAcceptCall();
                break;
            case ChatAppState.HistoryCall:
                RunHistoryCall();
                break;
            case ChatAppState.GalleryPanel:
                RunGallery();
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
        chatlistView.DestroyChatCell();
    }

    public void RunSelecChapter()
    {
        selectChapterView.Init();
        SelectChapterPanel.SetActive(true);
        chatlistView.DestroyChatCell();
        selectChapterView.SetUnlockChapter();
    }

    public void RunAcceptCall()
    {
        acceptCallView.Init();
    }

    public void RunHistoryCall()
    {
        historyCallView.Init();
        SelectChapterPanel.SetActive(false);
        HistoryPanel.SetActive(true);
    }

    public void RunGallery()
    {

    }
}