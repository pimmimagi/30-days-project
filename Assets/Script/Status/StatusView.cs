using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class StatusView : MonoBehaviour
{
    public GameObject StatusPlayerDefaultBox;
    public TMP_Text StatusPlayerDefaultText;
    private PlayerPod playerpod;
    public GameObject StatusEditPlayerBox;
    public TMP_InputField StatusPlayerChangeTextInputField;
    public Button EditStatusButton;
    public Button SaveStatusButton;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
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
            StatusPlayerDefaultBox.SetActive(false);
            StatusEditPlayerBox.gameObject.SetActive(true);
            ClearText();
        });

        SaveStatusButton.onClick.AddListener(() =>
        {
            StatusEditPlayerBox.gameObject.SetActive(false);
            //StatusPlayerDefaultText.text = StatusPlayerChangeText.text;
            playerpod.UpdateStatusText(StatusPlayerChangeTextInputField.text);
            StatusPlayerDefaultBox.SetActive(true);
        });
    }

    public void ClearText()
    {
        StatusPlayerDefaultText.text = "";
        StatusPlayerChangeTextInputField.text = "";
    }
}
