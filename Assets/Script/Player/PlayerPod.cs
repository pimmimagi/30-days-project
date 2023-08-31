using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPod : MonoBehaviour
{

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

    public int current_date = 15;
    public string current_day = "Sunday";
    public ReactiveProperty<string> StatusPlayerText = new ReactiveProperty<string>("อันยอง");

    public void UpdateStatusText(string newStatus)
    {
        StatusPlayerText.Value = newStatus;
    }


}