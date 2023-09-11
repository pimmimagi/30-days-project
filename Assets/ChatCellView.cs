using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class ChatCellView : MonoBehaviour
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
    public HeaderChatUIView HeaderChatUIView;

    CharacterBean characterData;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterpod = CharacterPod.Instance;
        SetupButtonListener();
        SetupSubscribe();



    }


    public void Bind(CharacterBean data)
    {
        characterData = data;
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
    private void SetupSubscribe()
    {
        playerpod.CheckPlayerReadMessagePie.Subscribe(IsReadingMessagePieAlready => {
            if (IsReadingMessagePieAlready)
            {
                NotificationPie.gameObject.SetActive(false);
            }
            else
            {
                NotificationPie.gameObject.SetActive(true);
            }
        }).AddTo(this);

        playerpod.CheckPlayerReadMessageF.Subscribe(IsReadingMessageFAlready => {
            if (IsReadingMessageFAlready)
            {
                NotificationF.gameObject.SetActive(false);
                NumberofNotification.gameObject.SetActive(false);
            }
            else
            {
                NotificationF.gameObject.SetActive(true);
                NumberofNotification.gameObject.SetActive(true);
            }
        }).AddTo(this);

        playerpod.PlayerReadingMessagePie.Subscribe(IsReadingMessagePie => {
            if (IsReadingMessagePie)
            {
                CharacterBean characterBeenID3 = characterpod.GetCharacterBeanByID(3);
                HeaderChatUIView.Bind(characterBeenID3);
               

            }

        }).AddTo(this);

        playerpod.PlayerReadingMessageF.Subscribe(IsReadingMessageF => {
            if (IsReadingMessageF)
            {
                CharacterBean characterBeenID0 = characterpod.GetCharacterBeanByID(0);
                HeaderChatUIView.Bind(characterBeenID0);
           

            }

        }).AddTo(this);

        playerpod.PlayerReadingMessage30DaysGroup.Subscribe(IsReadingMessage30DaysGroup => {
            if (IsReadingMessage30DaysGroup)
            {
                playerpod.SetReadingMessageFalseAll();

            }

        }).AddTo(this);
    }
    private void SetupButtonListener()
    {
        ChatBoxChatAppButton1.onClick.AddListener(() =>
        {
            playerpod.CheckPlayerReadMessagePie.Value = !playerpod.CheckPlayerReadMessagePie.Value;
            playerpod.PlayerReadingMessagePie.Value = !playerpod.PlayerReadingMessagePie.Value;
        });

        ChatBoxChatAppButton2.onClick.AddListener(() =>
        {
            playerpod.CheckPlayerReadMessageF.Value = !playerpod.CheckPlayerReadMessageF.Value;
            playerpod.PlayerReadingMessageF.Value = !playerpod.PlayerReadingMessageF.Value;
        });

        ButtonImageF.onClick.AddListener(() =>
          {
              // relationshipPanelView.OpenProfilePanel(data.characterData.IDCharacter);
              relationshipCellViewF.Bind(characterpod.GetCharacterBeanByID(0));
              PopUpProfilePanel.SetActive(true);

          });

        ButtonImagePie.onClick.AddListener(() =>
        {
            {
                relationshipCellViewF.Bind(characterpod.GetCharacterBeanByID(3));
                PopUpProfilePanel.SetActive(true);
            }
        });

        //ChatBox30Days.onClick.AddListener(() =>
        //{
        //playerpod.SetStatusPlayerReadindFalse();
        //playerpod.PlayerReadingMessage30DaysGroup = true;
        //smsconversation.StartSMSConversation();
        //MoveToScene(1);
        //});
    }
}
