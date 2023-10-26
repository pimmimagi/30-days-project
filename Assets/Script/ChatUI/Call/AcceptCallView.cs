using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    [Header("Character Data UI")]
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image CharacterProfile;
    [SerializeField] private TMP_Text NPCNameText;

    [Header("CallView")]
    [SerializeField] private CallView CallView;

    [Header("Pod")]
    private CharacterPod characterPod;
    private CallPod callPod;
    private PlayerPod playerPod;

    [Header("IDisposable")]
    public IDisposable callTimeCountDisposable;

    private void Start()
    {
        UpdateTimerDisplay(timer);

        playerPod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        callPod = CallPod.Instance;

        Lua.RegisterFunction("MoveToScene", this, typeof(AcceptCallView).GetMethod("MoveToScene"));
        Bind(characterPod.GetCharacterBeanByID(playerPod.PlayerReadingID));
        callPod.SettingCall();
        DialogueLua.SetVariable("Poomrelationship",30);
    }

    public void Bind(CharacterBean data)
    {
        NameText.text = data.characterData.NameText;
        CharacterProfile.sprite = data.characterData.ProfileSprite;
        NPCNameText.text = data.characterData.NameText;

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
            callTimeCountDisposable?.Dispose();
        }
    }
}


