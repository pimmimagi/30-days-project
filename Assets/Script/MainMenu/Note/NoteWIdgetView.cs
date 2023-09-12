using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class NoteWIdgetView : MonoBehaviour
{
    public GameObject NoteDefaultBox;
    public TMP_Text NoteDefaultText;
    private PlayerPod playerpod;
    public GameObject NoteEditPlayerBox;
    public TMP_InputField NotePlayerChangeTextInputField;
    public Button EditNoteButton;
    public Button SaveNoteButton;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        SetupSubscribe();
        SetupButtonListener();
    }

    private void SetupSubscribe()
    {
        playerpod.NoteText.Subscribe(newNote => {
            NoteDefaultText.text = newNote;
        }).AddTo(this);
    }

    private void SetupButtonListener()
    {
        EditNoteButton.onClick.AddListener(() =>
        {
            NoteDefaultBox.SetActive(false);
            NoteEditPlayerBox.gameObject.SetActive(true);
            ClearText();
        });

        SaveNoteButton.onClick.AddListener(() =>
        {
            NoteEditPlayerBox.gameObject.SetActive(false);
            //StatusPlayerDefaultText.text = StatusPlayerChangeText.text;
            playerpod.UpdateNoteText(NotePlayerChangeTextInputField.text);
            NoteDefaultBox.SetActive(true);
        });
    }

    public void ClearText()
    {
        NoteDefaultText.text = "";
        NotePlayerChangeTextInputField.text = "";
    }
}
