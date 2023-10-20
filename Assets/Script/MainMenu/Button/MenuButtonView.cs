using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonView : MonoBehaviour
{
    public Button ChatButton;
    public Button GalleryButton;
    public Button CallButton;
    public Button SettingButton;
    public GameObject VolumeSettingPanel;
    private SoundManager soundManager;
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
            soundManager.PlayClickSound();
        });
        CallButton.onClick.AddListener(() =>
        {
            soundManager.PlayClickSound();
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
