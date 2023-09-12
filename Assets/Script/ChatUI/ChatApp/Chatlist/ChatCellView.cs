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
    public Button ChatBoxChatAppButton;
    public Image Notification;
    public GameObject NumberofNotification;
    public Button ButtonImage;
    public RelationshipCellView relationshipCellView;
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
    }

    public void BindOnlyName(CharacterBean data)
    {
        Currenttext.text = data.CurrentChatText;
    }
    private void SetupSubscribe()
    {
        

    }
    private void SetupButtonListener()
    {
        ChatBoxChatAppButton.onClick.AddListener(() =>
        {
            playerpod.CheckPlayerReadMessagePie.Value = !playerpod.CheckPlayerReadMessagePie.Value;
           // playerpod.PlayerReadingMessagePie.Value = !playerpod.PlayerReadingMessagePie.Value;
        });

        ButtonImage.onClick.AddListener(() =>
          {
              relationshipCellViewF.Bind(characterpod.GetCharacterBeanByID(0));
              PopUpProfilePanel.SetActive(true);

          });

    }
}
