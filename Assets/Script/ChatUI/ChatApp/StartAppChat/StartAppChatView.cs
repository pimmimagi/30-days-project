using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using UniRx;
using System;
using PixelCrushers.DialogueSystem;


public class StartAppChatView : MonoBehaviour
{
    public Button StartDateButton;
    public GameObject PlayingBox;
    public TMP_Text StatusOfDate;
    private PlayerPod playerpod;
    public bool CheckValueDateChange = false;
    public GameObject CellViewPieGameObject;
    public GameObject CellViewFGameObject;
    public GameObject CellViewGroup30Days;
    public AudioSource NotificationSound;
    public AudioSource ClickSound;
    public NotificationCellView notificationCellView;
    private CharacterPod characterPod;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        SetupButtonListener();
        SetupSubscribe();
      
    }

    private void SetupSubscribe()
    {
        playerpod.IsPlaying.Subscribe(Isplaying => {
            if (Isplaying)
            {
                PlayingBox.SetActive(true);
            }
            else
            {
                PlayingBox.SetActive(false);
            }
        }).AddTo(this);
    }
    private void SetupButtonListener()
    {

        StartDateButton.onClick.AddListener(() =>
        {
            SetChatCellAllInactive();
            SetActive();
            playerpod.IsPlaying.Value = !playerpod.IsPlaying.Value;
            ClickSound.Play();
            int Chapterday = playerpod.current_date + 1;
            StatusOfDate.text = "Day" + Chapterday;
            });

    } 


    public void SetActive()

    {
        if (playerpod.current_date == 1)
        {
            Observable.Timer(TimeSpan.FromSeconds(0.8)).Subscribe(_ =>
            {
                CellViewPieGameObject.SetActive(true);
                NotificationSound.Play();

            });
        }
        if (playerpod.current_date == 2)
        {
            Observable.Timer(TimeSpan.FromSeconds(0.8)).Subscribe(_ =>
            {
                CellViewFGameObject.SetActive(false);
                CellViewPieGameObject.SetActive(false);
                CellViewGroup30Days.gameObject.SetActive(true);


            });
        }

    }

    public void SetChatCellAllInactive()
    {
        CellViewFGameObject.SetActive(false);
        CellViewPieGameObject.SetActive(false);
        CellViewGroup30Days.gameObject.SetActive(false);
    }

}
