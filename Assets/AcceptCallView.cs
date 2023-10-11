using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private Chapterpod chapterpod;
    private CharacterPod characterPod;
    //public StartNewConversation newConversation;
    private PlayerPod playerPod;
    public TMP_Text NameText;
    public Image CharacterProfile;
    public TMP_Text NPCNameText;
    private void Start()
    {
        UpdateTimerDisplay(timer);
        playerPod = PlayerPod.Instance;
        chapterpod = Chapterpod.Instance;
        characterPod = CharacterPod.Instance;
        Lua.RegisterFunction("MoveToScene", this, typeof(AcceptCallView).GetMethod("MoveToScene"));
        //StartSubtile();
        Bind(characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID));
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

    public void Bind(CharacterBean data)
    {
        NameText.text = data.characterData.NameText;
        CharacterProfile.sprite = data.characterData.ProfileSprite;
        NPCNameText.text = data.characterData.NameText;
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
        Debug.LogError("Player is Reading ID " + playerPod.PlayerReadingID);
        Debug.LogError("Player is Reading index" + playerPod.PlayerReadingConversationIndex);
        //Debug.LogError("Player read conversation : " + chapter.DataEachConversation[playerPod.PlayerReadingConversationIndex].Conversation);
        ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
        //newConversation.StartMyConversation(chapter.DataEachConversation[playerPod.PlayerReadingConversationIndex].Conversation);

    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void OnConversationLine(Subtitle subtitle)
    {
        Debug.Log(subtitle);
        if (!DialogueManager.currentConversationState.hasAnyResponses)
        {
            MoveToScene(0);
        }
    }
}


