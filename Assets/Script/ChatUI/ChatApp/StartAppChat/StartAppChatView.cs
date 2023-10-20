using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using System;


public class StartAppChatView : MonoBehaviour
{
    private const float DELAY_CHAT_OPEN = 0.8f;
    public Button StartDateButton;
    public GameObject PlayingBox;
    public TMP_Text StatusOfDate;
    private PlayerPod playerpod;
    public bool CheckValueDateChange = false;
    public GameObject CellViewPieGameObject;
    public GameObject CellViewFGameObject;
    public GameObject CellViewGroup30Days;
    public NotificationCellView notificationCellView;
    private CharacterPod characterPod;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        playerpod = PlayerPod.Instance;
        characterPod = CharacterPod.Instance;
        SetupButtonListener();
     
      
    }


    private void SetupButtonListener()
    {

        StartDateButton.onClick.AddListener(() =>
        {
            SetChatCellAllInactive();
            SetActive();
            playerpod.IsPlaying.Value = !playerpod.IsPlaying.Value;
            soundManager.PlayClickSound();
            });

    } 

    //TODO Change to Auto 
    public void SetActive()

    {
        if (playerpod.current_date == 1)
        {
            Observable.Timer(TimeSpan.FromSeconds(DELAY_CHAT_OPEN)).Subscribe(_ =>
            {
                CellViewPieGameObject.SetActive(true);
                soundManager.PlayNotificationSound();

            });
        }
        if (playerpod.current_date == 2)
        {
            Observable.Timer(TimeSpan.FromSeconds(DELAY_CHAT_OPEN)).Subscribe(_ =>
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
