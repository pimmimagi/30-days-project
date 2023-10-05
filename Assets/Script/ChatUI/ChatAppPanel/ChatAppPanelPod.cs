using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ChatAppPanelPod : MonoBehaviour
{
    public static ChatAppPanelPod Instance { get; private set; }

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
    public ReactiveProperty<ChatAppState> ChatState = new ReactiveProperty<ChatAppState>(ChatAppState.SelectChapter);

    public void ChangeChatState(ChatAppState newState)
    {
        Debug.Log(newState);
        ChatState.Value = newState;
    }
}
