using UniRx;
using UnityEngine;

public class ChatAppPanelPod : MonoBehaviour
{
    public static ChatAppPanelPod Instance { get; private set; }

    public ReactiveProperty<ChatAppState> ChatState = new ReactiveProperty<ChatAppState>(ChatAppState.SelectChapter);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeChatState(ChatAppState newState)
    {
        ChatState.Value = newState;
    }
}
