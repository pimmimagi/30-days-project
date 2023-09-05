using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPod : MonoBehaviour { 

    public static PlayerPod Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int current_date = 1;
    public string current_day = "Sunday";
    public ReactiveProperty<string> StatusPlayerText = new ReactiveProperty<string>("อันยอง");
    public bool isplaying = false;
    public bool CheckPlayerReadMessagePie = false;
    public bool CheckPlayerReadMessageF = false;
    public bool PlayerReadingMessagePie = false;
    public bool PlayerReadingMessageF = false;
    public bool ReadAlready = false;

    public void UpdateStatusText(string newStatus)
    {
        StatusPlayerText.Value = newStatus;
    }
}