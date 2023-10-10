using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class AcceptCallView : MonoBehaviour
{
    private float timeDuration = 0;
    private float timer;
    [SerializeField]
    private TMP_Text firstMinute;
    [SerializeField]
    private TMP_Text secondMinute;
    [SerializeField]
    private TMP_Text separator;
    [SerializeField]
    private TMP_Text firstSecond;
    [SerializeField]
    private TMP_Text secondSecond;
    public CallingView callingView;
    private Chapterpod chapterpod;
    public SMSConversation SMSconversation;
    private PlayerPod playerPod;
    private void Start()
    {
        UpdateTimerDisplay(timer);
        playerPod = PlayerPod.Instance;
        chapterpod = Chapterpod.Instance;
        StartSubtile();
    }
    private void ResetTimer()
    {
        timer = timeDuration;
    }

    private void Update()
    {

      UpdateTimerDisplay(timer);
      timer += Time.deltaTime;

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

    public void StartSubtile()
    {
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
        SMSconversation.StartSMSConversation(chapter.DataEachConversation[playerPod.PlayerReadingConversationIndex].Conversation);
    }
    }


