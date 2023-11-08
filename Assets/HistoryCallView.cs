using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class HistoryCallView : MonoBehaviour
{
    [Header("Call History Lock Panel")]
    [SerializeField] private GameObject[] LockCallHistory;

    [Header("Pod")]
    private HistoryPod historyPod;
    private CallPod callPod;
    private ChatAppPanelPod chatAppPanelPod;
    private CharacterPod characterPod;

    [Header("CallingView")]
    [SerializeField] private CallView callView;

    [Header("Call Dialogue GameObject")]
    [SerializeField] private GameObject CallDialogue;

    [Header("History Call Gameobject")]
    [SerializeField] private GameObject CallHistory;

    [Header("ButtonReplayList")]
    [SerializeField] private Button[] ReplayButtonList;

    [Header("Calling Panel")]
    [SerializeField] private GameObject CallingPanel;

    [Header("AcceptCallVIew")]
    [SerializeField] private AcceptCallView acceptCallView;
    
    public void Init()
    {
        historyPod = HistoryPod.Instance;
        callPod = CallPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;
        characterPod = CharacterPod.Instance;

        SetupButtonListener();
    }
 
    private void SetupButtonListener()
    {
        ReplayButtonList[0].onClick.RemoveAllListeners();
        ReplayButtonList[0].onClick.AddListener(() =>
        {
            //DialogueLua.SetVariable("Calling 1", true);
            callView.Bind(characterPod.GetCharacterBeanByID(3));
            callPod.Calling1 = true;
            SettingReplayButton();
            Debug.Log("finisshed SetupButtonListener");
        });
    }

    public void SettingReplayButton()
    {
        DialogueManager.UseDialogueUI(CallDialogue);
        chatAppPanelPod.ChangeChatState(ChatAppState.AcceptCall);
        DialogueManager.StartConversation("New Conversation 9");
        acceptCallView.CheckHistory = true;
        CallHistory.SetActive(false);
        DialogueLua.SetVariable("NowCalling", true);
        callPod.GetVariableCalling();
        //DialogueManager.StartConversation("New Conversation 9");
        //callPod.SettingCall();
    }

    private void Update()
    {
        SetUnlockCallHistory();
    }

    public void SetUnlockCallHistory()
    {
        historyPod.LoadHistory();
        for (int i = 0; i < historyPod.history.list.Count; i++) {
            if (historyPod.history.list[i] == 1)
            {
                LockCallHistory[0].SetActive(false);
            }
            else if (historyPod.history.list[i] == 2)
            {
                LockCallHistory[1].SetActive(false);
            }
        }
    }
}
