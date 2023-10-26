using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;


public class StatusView : MonoBehaviour
{
    [Header("StatusPlayerDefault")]
    [SerializeField] private GameObject StatusPlayerDefaultBox;
    [SerializeField] private TMP_Text StatusPlayerDefaultText;

    [Header("StatusEditPlayer")]
    [SerializeField] private GameObject StatusEditPlayerBox;
    [SerializeField] private TMP_InputField StatusPlayerChangeTextInputField;

    [Header("Button")]
    [SerializeField] private Button EditStatusButton;
    [SerializeField] private Button SaveStatusButton;

    [Header("Pod")]
    private PlayerPod playerpod;
    private SoundManager soundmanager;

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
