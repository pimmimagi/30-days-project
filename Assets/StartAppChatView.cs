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


public class StartAppChatView : MonoBehaviour
{
    public Button StartDateButton1;
    public Button StartDateButton2;
    public Button StartDateButton3;
    public Button StartDateButton4;
    public GameObject PlayingBox;
    public TMP_Text StatusOfDate;
    private PlayerPod playerpod;
    public bool CheckValueDateChange = false;
    [SerializeField] public UnityEvent isPlaying;
    public GameObject CellViewPieGameObject;
    public GameObject CellViewFGameObject;
    public AudioSource NotificationSound;
    public AudioSource ClickSound;
    public NotificationCellView notificationCellView;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        SetupButtonListener();
        SetButtonCurrentDate();
    }
    private void Update()
    {
        SetButtonCurrentDate();
    }
    private void SetupButtonListener()
    {
 
        StartDateButton1.onClick.AddListener(() =>
        {
            //MoveToScene(1);
            //notificationCellView.SetActive();
            SetActive();
            //playerpod.CheckisPlayerClickButton = true;
            playerpod.isplaying = true;
            ClickSound.Play();
        });

        StartDateButton2.onClick.AddListener(() =>
        {
            //MoveToScene(5);
            //Debug.Log("already move");
            SetActive();
            playerpod.isplaying = true;
            ClickSound.Play();
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }


    public void SetButtonCurrentDate()
    {
        AllInactiveButton();

        if (playerpod.isplaying)
        {
            PlayingBox.SetActive(true);
        }
        switch (playerpod.current_date)
        {
            case 1:
                StartDateButton1.gameObject.SetActive(true);
                break;
            case 2:
                StartDateButton2.gameObject.SetActive(true);
                break;
            case 3:
                StartDateButton3.gameObject.SetActive(true);
                break;
            case 4:
                StartDateButton4.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid date value: " + playerpod.current_date);
                break;
        }
    }

    private bool DateChanged()
    {
        return CheckValueDateChange && playerpod.current_date != 1;
    }

    public void AllInactiveButton()
    {
        StartDateButton1.gameObject.SetActive(false);
        StartDateButton2.gameObject.SetActive(false);   
        StartDateButton3.gameObject.SetActive(false);
        StartDateButton4.gameObject.SetActive(false);
        PlayingBox.gameObject.SetActive(false);

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
                
         

            });
        }

    }

}
