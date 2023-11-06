using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
public class NotificationCellView : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject NotificationPopUp;
    public GameObject NumberOfNotification;

    [Header("Character Data UI")]
    public TMP_Text NotificationText;
    public Image CharacterImage;
    public TMP_Text CharacterNameText;

    [Header("Sound Manager")]
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
    }

    public void SetActiveNotification()
    {
        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ => { 
            NotificationPopUp.SetActive(true);
            Debug.Log("run set active true");
            //soundManager.PlayNotificationSound();
            Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(_ => {
                NotificationPopUp.SetActive(false);
                Debug.Log("run set active false");
            });
        });
    }
}

