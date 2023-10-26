using PixelCrushers.DialogueSystem;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CallingView : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject AcceptCallPanel;
    [SerializeField] private GameObject ChatUIPanel;
    [SerializeField] private GameObject DialoguePanelCall;
    [SerializeField] private GameObject CallUI;
    [SerializeField] private GameObject CallPanel;
    [SerializeField] private GameObject CallingPanel;

    [Header("CallView")]
    [SerializeField] private CallView callView;

    [Header("Button")]
    [SerializeField] private Button CallingButton;
    [SerializeField] private Button HangUpButton;

    [Header("StartNewConversation Script")]
    [SerializeField] private StartNewConversation startCall;

    [Header("Sound Manager")]
    private SoundManager soundManager;

    [Header("Pod")]
    private CharacterPod characterPod;
    private HistoryPod historyPod;
    private PlayerPod playerPod;
 
    private void Start()
    {
        historyPod = HistoryPod.Instance;
        soundManager = SoundManager.Instance;
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;

        Lua.RegisterFunction("SetCallingActive", this, typeof(CallingView).GetMethod("SetCallingActive"));

        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        HangUpButton.onClick.AddListener(() =>
        {
            CallingPanel.SetActive(false);
            soundManager.StopRingtoneSound();
            PlayerPrefs.DeleteAll();
        });

        CallingButton.onClick.AddListener(() =>
        {
            DialogueManager.UseDialogueUI(CallUI);
            CallPanel.SetActive(false);
            AcceptCallPanel.SetActive(true);
            DialoguePanelCall.SetActive(true);
            DialogueLua.SetVariable("NowCalling", true);
            soundManager.StopRingtoneSound();
            historyPod.SaveHistory(1);
            playerPod.PlayerCallingConversation = +1;
            historyPod.LoadHistory();

        });
    }

    public void SetCallingActive(string name)
    {
        if (name == "พาย")
        {
            callView.Bind(characterPod.GetCharacterBeanByID(3));
        }
        if (name == "เอฟ")
        {
            callView.Bind(characterPod.GetCharacterBeanByID(0));
        }

        SetActive();
    }

    public void SetActive()
    {
        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ => {
            CallingPanel.SetActive(true);
            soundManager.PlayRingtoneSound();
        });
    }
}
