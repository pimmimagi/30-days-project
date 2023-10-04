using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;


public class StatusView : MonoBehaviour
{
    public GameObject StatusPlayerDefaultBox;
    public TMP_Text StatusPlayerDefaultText;
    private PlayerPod playerpod;
    private SoundManager soundmanager;
    public GameObject StatusEditPlayerBox;
    public TMP_InputField StatusPlayerChangeTextInputField;
    public Button EditStatusButton;
    public Button SaveStatusButton;
    

    private void Start()
    {
        soundmanager = SoundManager.Instance;
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
            StatusPlayerChangeTextInputField.text = StatusPlayerDefaultText.text;
            OnClickStatusButton(false);
        });

        SaveStatusButton.onClick.AddListener(() =>
        {
            playerpod.UpdateStatusText(StatusPlayerChangeTextInputField.text);
            OnClickStatusButton(true);
        });
    }

    private void OnClickStatusButton(bool changeToEdit)
    {
        soundmanager.PlayClickSound();
        StatusEditPlayerBox.gameObject.SetActive(!changeToEdit);
        StatusPlayerDefaultBox.SetActive(changeToEdit);
        EditStatusButton.gameObject.SetActive(changeToEdit);
        SaveStatusButton.gameObject.SetActive(!changeToEdit);
    }
}
