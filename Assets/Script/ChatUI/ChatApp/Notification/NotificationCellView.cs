using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
public class NotificationCellView : MonoBehaviour
{
    public GameObject NotificationPopUp;
    public GameObject NumberOfNotification;
    public TMP_Text NotificationText;
    public Image CharacterImage;
    public TMP_Text CharacterNameText;
    private CharacterPod characterpod;
    public AudioSource NotiSound;

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
    }

    public void SetActive()

    {
        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ => { 
        NotificationPopUp.SetActive(true);
            NotiSound.Play();
            NumberOfNotification.SetActive(true);
            Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(_ => {
                NotificationPopUp.SetActive(false);

            });

        });

        
    }
}
