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
    public Button ChatBox30Days;
    public Image NotificationPie;
    public Image NotificationF;
    public GameObject NumberofNotification;
    public Button ButtonImageF;
    public Button ButtonImagePie;
    public RelationshipCellView relationshipCellViewF;
    public GameObject PopUpProfilePanel;
    public SMSConversation smsconversation;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterpod = CharacterPod.Instance;
        SetupButtonListener();
        if (playerpod.PlayerReadPopUpProfileCharacter == false)
        {
            SetNotification();
        }
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

    public void BindOnlyName(CharacterBean data)
    {
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
            //smsconversation.StartSMSConversation();
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
        ButtonImageF.onClick.AddListener(() =>
        {
            if (playerpod.PlayerReadPopUpProfileCharacter == false)
            {
                relationshipCellViewF.Bind(characterpod.GetCharacterBeanByID(0));
                PopUpProfilePanel.SetActive(true);
                playerpod.PlayerReadPopUpProfileCharacter = true;
            }
     
            //MoveToScene(5);
        });

        ButtonImagePie.onClick.AddListener(() =>
        {
            if (playerpod.PlayerReadPopUpProfileCharacter == false)
            {
                relationshipCellViewF.Bind(characterpod.GetCharacterBeanByID(3));
                PopUpProfilePanel.SetActive(true);
                playerpod.PlayerReadPopUpProfileCharacter = true;
            }
        });

        //ChatBox30Days.onClick.AddListener(() =>
        //{
            //playerpod.SetStatusPlayerReadindFalse();
            playerpod.PlayerReadingMessage30DaysGroup = true;
            //smsconversation.StartSMSConversation();
            //MoveToScene(1);
        //});
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
    public void SetPlayerReadingMessageGroup()
    {
        playerpod.PlayerReadingMessage30DaysGroup = true;
    }
}
