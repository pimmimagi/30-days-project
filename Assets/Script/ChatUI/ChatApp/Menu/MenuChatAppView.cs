using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChatAppView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button BackToChatAppButton;

    [Header("Sound Manager")]
    private SoundManager soundManager;

    [Header("GameObject")]
    [SerializeField] private GameObject ChatStartPanel;
    [SerializeField] private GameObject SelectChapterPanel;
    [SerializeField] private GameObject chatCellView;

    [Header("ChatlistView")]
    [SerializeField] private ChatlistView chatlistView;

    [Header("Pod")]
    private ChatAppPanelPod chatAppPanelPod;
    private PlayerPod playerPod;

    private void Start()
    {
        chatAppPanelPod = ChatAppPanelPod.Instance;
        soundManager = SoundManager.Instance;
        playerPod = PlayerPod.Instance;

        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        HomeButton.onClick.AddListener(() =>
        {
            soundManager.PlayClickSound();                                                                                                                                                                                                                 
            MoveToScene(2);
        });

        BackToChatAppButton.onClick.AddListener(() =>
        {
            BackToChatAppOnClick();
        });
    }

    public void BackToChatAppOnClick()
    {
        chatlistView.DestroyChatCell();
        soundManager.PlayClickSound();
        ChatStartPanel.gameObject.SetActive(false);
        SelectChapterPanel.gameObject.SetActive(true);
        chatAppPanelPod.ChangeChatState(ChatAppState.SelectChapter);
        playerPod.UpdateIsplayingValue(false);
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
