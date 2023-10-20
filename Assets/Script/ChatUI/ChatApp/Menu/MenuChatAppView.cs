using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChatAppView : MonoBehaviour
{
    public Button HomeButton;
    public Button BackToChatAppButton;
    private SoundManager soundManager;
    private ChatAppPanelPod chatAppPanelPod;
    private PlayerPod playerPod;
    public GameObject ChatStartPanel;
    public GameObject SelectChapterPanel;
    public ChatlistView chatlistView;
    public GameObject chatCellView;

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
            chatlistView.DestroyChatCell();
            soundManager.PlayClickSound();
            ChatStartPanel.gameObject.SetActive(false);
            SelectChapterPanel.gameObject.SetActive(true);
            chatAppPanelPod.ChangeChatState(ChatAppState.SelectChapter); 
            playerPod.UpdateIsplayingValue(false);
            
            
            //chatCellView.gameObject.SetActive(true);





        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
