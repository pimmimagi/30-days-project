using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button ChatButton;
    [SerializeField] private Button GalleryButton;
    [SerializeField] private Button CallButton;
    [SerializeField] private Button SettingButton;

    [Header("GaneObject")]
    [SerializeField] private GameObject VolumeSettingPanel;
    [SerializeField] private GameObject HistoryCallPanel;
    [SerializeField] private GameObject GalleryPanel;

    [Header("SoundManager")]
    [SerializeField] private SoundManager soundManager;

    [Header("Pod")]
    private ChatAppPanelPod chatAppPanelPod;

    void Start()
    {
        soundManager = SoundManager.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;

        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        ChatButton.onClick.AddListener(() =>
        {
            chatAppPanelPod.ChangeChatState(ChatAppState.SelectChapter);
            soundManager.PlayClickSound();
            MoveToScene(0);
        });
        GalleryButton.onClick.AddListener(() =>
        {
            chatAppPanelPod.ChangeChatState(ChatAppState.GalleryPanel);
            soundManager.PlayClickSound();
            MoveToScene(0);
        });
        CallButton.onClick.AddListener(() =>
        {
            chatAppPanelPod.ChangeChatState(ChatAppState.HistoryCall);
            soundManager.PlayClickSound();
            MoveToScene(0);
        });
        SettingButton.onClick.AddListener(() =>
        {
            VolumeSettingPanel.SetActive(true);
            soundManager.PlayClickSound();
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
