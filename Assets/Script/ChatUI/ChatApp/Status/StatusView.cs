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
    public AudioSource audioSource;

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
            audioSource.Play();
            StatusPlayerChangeTextInputField.text = StatusPlayerDefaultText.text;
            StatusPlayerDefaultBox.SetActive(false);
            StatusEditPlayerBox.gameObject.SetActive(true);
            EditStatusButton.gameObject.SetActive(false);     
            SaveStatusButton.gameObject.SetActive(true);
        });

        SaveStatusButton.onClick.AddListener(() =>
        {
            audioSource.Play();
            StatusEditPlayerBox.gameObject.SetActive(false);
            playerpod.UpdateStatusText(StatusPlayerChangeTextInputField.text);
            StatusPlayerDefaultBox.SetActive(true);
            EditStatusButton.gameObject.SetActive(true);
            SaveStatusButton.gameObject.SetActive(false);
        });
    }


}
