using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HistoryCallView : MonoBehaviour
{
    [Header("Call History Lock Panel")]
    [SerializeField] private GameObject[] LockCallHistory;

    [Header("Pod")]
    private HistoryPod historyPod;
    private CallPod callPod;
    private ChatAppPanelPod chatAppPanelPod;

    [Header("CallingView")]
    [SerializeField] private CallingView callView;

    [Header("Call Dialogue GameObject")]
    [SerializeField] private GameObject CallDialogue;

    [Header("History Call Gameobject")]
    [SerializeField] private GameObject CallHistory;

    [Header("ButtonReplayList")]
    [SerializeField] private Button[] ReplayButtonList;
    
    public void Init()
    {
        historyPod = HistoryPod.Instance;
        callPod = CallPod.Instance;
        chatAppPanelPod = ChatAppPanelPod.Instance;

        SetupButtonListener();
    }
 
    private void SetupButtonListener()
    {
        ReplayButtonList[0].onClick.AddListener(() =>
        {
            DialogueLua.SetVariable("Calling 1", true);
            callView.SetCallingActive("พาย");
            CallHistory.SetActive(false);
            DialogueManager.UseDialogueUI(CallDialogue);
            chatAppPanelPod.ChangeChatState(ChatAppState.AcceptCall);
            DialogueLua.SetVariable("NowCalling", true);
            callPod.GetVariableCalling();
            callPod.Calling1 = true;
            DialogueManager.StartConversation("New Conversation 9");
            callPod.SettingCall();
        });
    }

    private void Update()
    {
        SetUnlockCallHistory();
        Debug.LogError(DialogueLua.GetVariable("Calling 1").AsBool);
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
