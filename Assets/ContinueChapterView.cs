using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueChapterView : MonoBehaviour
{
    public Button ContinueButton;
    public Button BackButton;
    public GameObject ContinuePanel;
    public GameObject ChatUI;
    public SelectChapterView selectchapterView;
    public SMSConversation smsConversation;
    public ChatlistView chatlistView;
    private Chapterpod chapterPod;
    private PlayerPod playerPod;
    public GameObject SelectedChapterPanel;
    private ChatAppPanelPod chatAppPanelPod;

    private void Start()
    {
        chapterPod = Chapterpod.Instance;
        playerPod = PlayerPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;
        SetupButtonListener();
    }
    private void SetupButtonListener()
    {
        ContinueButton.onClick.AddListener(() =>
        {
            ContinuePanel.SetActive(false);
            smsConversation.StopSMSConversation();
            chatlistView.DestroyChatCell();
            selectchapterView.ButtonSetting();
            playerPod.current_date += 1;
            //selectchapterView.SetUnlockChapter();
            playerPod.PlayerReadingConversationIndex = 0;
            ChapterTemplateScriptableObject chapter = chapterPod.GetChapterByIndex(playerPod.current_date - 1);
            selectchapterView.LoopCharacters(chapter);
            chatAppPanelPod.ChangeChatState(ChatAppState.ChatListPanel);


        });

        BackButton.onClick.AddListener(() =>
        {
            MoveToScene(2);

            ContinuePanel.SetActive(false);
            smsConversation.StopSMSConversation();
            //ChatUI.SetActive(false);
            //selectchapterView.gameObject.SetActive(false);
            playerPod.current_date += 1;
            //selectchapterView.SetUnlockChapter();
            playerPod.PlayerReadingConversationIndex = 0;
            //ChatUI.SetActive(false);
            //SelectedChapterPanel.SetActive(true);
            chatlistView.DestroyChatCell();




        });
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
