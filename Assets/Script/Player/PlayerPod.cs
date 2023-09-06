using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPod : MonoBehaviour
{

    public static PlayerPod Instance { get; private set; }

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

    public int current_date = 1;
    public string current_day = "Sunday";
    public ReactiveProperty<string> StatusPlayerText = new ReactiveProperty<string>("อันยอง");
    public ReactiveProperty<string> NoteText = new ReactiveProperty<string>("EnterText");
    public bool isplaying = false;
    public bool CheckPlayerReadMessagePie = true;
    public bool CheckPlayerReadMessageF = false;
    public bool PlayerReadingMessagePie = true;
    public bool PlayerReadingMessageF = false;
    public bool ReadAlready = false;

    private void Update()
    {
        DateAndDay(current_date);
    }

    public void UpdateNoteText(string newNote)
    {
        NoteText.Value = newNote;
    }
    public void UpdateStatusText(string newStatus)
    {
        StatusPlayerText.Value = newStatus;
    }
    public void UpdatePlayerReadMessagePie()
    {
        PlayerReadingMessagePie = true;
    }

    public void UpdatePlayerReadMessageF()
    {
        PlayerReadingMessageF = true;
    }

    public void SetReadingMessageFalseAll()
    {
        PlayerReadingMessagePie = false;
        PlayerReadingMessageF = false;
    }

    public void SetReadAlreadyTrue()
    {
        ReadAlready = true;
    }

    public void CheckPlayerReadMessagePietoTrue()
    {
        CheckPlayerReadMessagePie = true;
    }

    public void CheckPlayerReadMessageFtoTrue()
    {
        CheckPlayerReadMessageF = true;
    }
    public void DateAndDay(int currentdate)
    {
        if (currentdate % 7 == 1)
        {
            current_day = "Sunday";
        }
        if (currentdate % 7 == 2)
        {
            current_day = "Monday";
        }
        if (currentdate % 7 == 3)
        {
            current_day = "Tuesday";
        }
        if (currentdate % 7 == 4)
        {
            current_day = "Wednesday";
        }
        if (currentdate % 7 == 5)
        {
            current_day = "Thursday";
        }
        if (currentdate % 7 == 6)
        {
            current_day = "Friday";
        }
        if (currentdate % 7 == 7)
        {
            current_day = "Saturday";
        }
    }
    }
