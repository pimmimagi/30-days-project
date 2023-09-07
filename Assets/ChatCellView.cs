using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class ChatCellView: MonoBehaviour
{
    public TMP_Text Currenttext;
    public Image CharacterImage;
    public TMP_Text CharacterNameText;
    private PlayerPod playerpod;
    private CharacterPod characterpod;
    public Button ChatBoxChatAppButton1;
    public Button ChatBoxChatAppButton2;
    public Image NotificationPie;
    public Image NotificationF;
    public GameObject NumberofNotification;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterpod = CharacterPod.Instance;
        SetupButtonListener();
        SetNotification();
    }

    private void Update()
    {
        SetNotification();
    }
    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
        Currenttext.text = data.CurrentChatText;
        Debug.Log("current text is binding to : " + data.CurrentChatText);
    }
    private void SetupButtonListener()
    {
        ChatBoxChatAppButton1.onClick.AddListener(() =>
        {
            //playerpod.SetStatusPlayerReadindFalse();
            playerpod.CheckPlayerReadMessagePie = true;
            playerpod.PlayerReadingMessagePie = true;
            //MoveToScene(1);
        });

        ChatBoxChatAppButton2.onClick.AddListener(() =>
        {
           // playerpod.SetStatusPlayerReadindFalse();
           // Debug.LogError(playerpod.PlayerReadingMessagePie);
            playerpod.CheckPlayerReadMessageF = true;
            playerpod.PlayerReadingMessageF = true;
            //MoveToScene(5);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void SetNotification()
    {
        if (playerpod.CheckPlayerReadMessagePie)
        {
            NotificationPie.gameObject.SetActive(false);
        }
        if (playerpod.CheckPlayerReadMessageF)
        {
            NotificationF.gameObject.SetActive(false);
            NumberofNotification.gameObject.SetActive(false);

        }
    }
}
