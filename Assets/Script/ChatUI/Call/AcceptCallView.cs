using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UniRx;

public class AcceptCallView : MonoBehaviour
{
    [Header("Time")]
    private float timer;
    [SerializeField] private TMP_Text firstMinute;
    [SerializeField] private TMP_Text secondMinute;
    [SerializeField] private TMP_Text separator;
    [SerializeField] private TMP_Text firstSecond;
    [SerializeField] private TMP_Text secondSecond;

    [Header("CallView")]
    [SerializeField] private CallView CallView;

    [Header("IDisposable")]
    public IDisposable callTimeCountDisposable;

    [Header("GameObject")]
    [SerializeField] private GameObject SMSDialogueUI;

    [Header("Pod")]
    private CallPod callPod;
    private ChatAppPanelPod chatAppPanelPod;

    [Header("History Check")]
    public bool CheckHistory = false;

    [Header("History Panel")]
    [SerializeField] private GameObject HistoryPanel;
      
    public void Init()
    {
        UpdateTimerDisplay(timer);
        callPod = CallPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;

        Lua.RegisterFunction("MoveToScene", this, typeof(AcceptCallView).GetMethod("MoveToScene"));
        callPod.SettingCall();
        callTimeCountDisposable = Observable.EveryUpdate().Subscribe(everyUpdate =>
        {
            UpdateTimerDisplay(timer);
            timer += Time.deltaTime;
        }).AddTo(this);
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void OnConversationLine(Subtitle subtitle)
    {
        if (!DialogueManager.currentConversationState.hasAnyResponses)
        {
            if (CheckHistory == false)
            {
                callTimeCountDisposable?.Dispose();
                DialogueManager.UseDialogueUI(SMSDialogueUI);
                chatAppPanelPod.ChangeChatState(ChatAppState.ChatPanel);
            }
            else
            {
                callTimeCountDisposable?.Dispose();
                HistoryPanel.SetActive(true);
                chatAppPanelPod.ChangeChatState(ChatAppState.HistoryCall);
            }
        }
    }
}


