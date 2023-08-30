using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class StatusView : MonoBehaviour
{
    public TMP_Text StatusPlayerDefaultText;
    public PlayerPod playerpod;
    public GameObject StatusEditPlayerBox;
    public TMP_Text StatusPlayerChangeText;
    public Button EditStatusButton;
    public Button SaveStatusButton;

    private void Start()
    {
        SetupSubscribe();
        SetupButtonListener();
    }

    private void SetupSubscribe()
    {
        playerpod.StatusPlayerText.Subscribe(newStatusText => {
            StatusPlayerDefaultText.text = newStatusText;
        }).AddTo(this);
    }

    private void SetupButtonListener()
    {
        EditStatusButton.onClick.AddListener(() =>
        {
            ClearText()
            StatusEditPlayerBox.gameObject.SetActive(true);
        });

        SaveStatusButton.onClick.AddListener(() =>
        {
            StatusEditPlayerBox.gameObject.SetActive(false);
            StatusPlayerDefaultText.text = StatusPlayerChangeText.text;
        });
    }

    public void ClearText()
    {
        if (StatusPlayerDefaultText != null) StatusPlayerDefaultText.text = "";
    }

}
