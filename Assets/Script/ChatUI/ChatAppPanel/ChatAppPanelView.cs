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

    [Header("HistoryCallView")]
    [SerializeField] private HistoryCallView historyCallView;

    [Header("SelectChapter")]
    [SerializeField] private SelectChapterView selectChapterView;

    [Header("GameObject")]
    [SerializeField] private GameObject SelectChapterPanel;

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

}