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

    private void Start()
    {
        chapterPod = Chapterpod.Instance;
        playerPod = PlayerPod.Instance;
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
            ChapterTemplateScriptableObject chapter = chapterPod.GetChapterByIndex(playerPod.current_date - 1);
            selectchapterView.LoopCharacters(chapter);

        });

        BackButton.onClick.AddListener(() =>
        {
            ContinuePanel.SetActive(false);
            ChatUI.SetActive(false);
            selectchapterView.gameObject.SetActive(false);


        });
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
