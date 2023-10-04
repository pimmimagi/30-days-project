﻿using System.Collections;
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
    public ReactiveProperty<bool> IsPlaying = new ReactiveProperty<bool>(false);
    public ReactiveProperty<bool> ReadAlready = new ReactiveProperty<bool>(false);
    public ReactiveProperty<bool> PlayerReadingMessage30DaysGroup = new ReactiveProperty<bool>(false);
    public int PlayerReadingID = -1;
    public int NumberofNotification = 2;

    private void Update()
    {
        DateAndDay(current_date);
    }

    public void UpdatePlayerIsReadingID(int newID)
    {
       PlayerReadingID = newID;
    }
    public void UpdateIsplayingValue(bool newValue)
    {
       IsPlaying.Value = newValue;
    }
    public void UpdateNoteText(string newNote)
    {
        NoteText.Value = newNote;
    }
    public void UpdateStatusText(string newStatus)
    {
        StatusPlayerText.Value = newStatus;
    }

    //TODO  ย้ายไปอยู่ View
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
