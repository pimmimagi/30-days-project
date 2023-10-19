using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class CallingView : MonoBehaviour

 
{
    public CallView CallView;
    public GameObject CallingPanel;
    private CharacterPod characterPod;
    public Button CallingButton;
    public Button HangUpButton;
    private SoundManager soundManager;
    private PlayerPod playerPod;
    private Chapterpod chapterpod;
    public StartNewConversation startCall;
    public GameObject AcceptCallPanel;
    public GameObject ChatUIPanel;
    public GameObject DialoguePanelCall;
    public GameObject CallUI;
    public GameObject CallPanel;
    private void Start()
    {
        characterPod = CharacterPod.Instance;
        soundManager = SoundManager.Instance;
        playerPod = PlayerPod.Instance;
        chapterpod = Chapterpod.Instance;
        Lua.RegisterFunction("SetCallingActive", this, typeof(CallingView).GetMethod("SetCallingActive"));
        SetupButtonListener();

    }

    public void SetCallingActive(string name)
    {
        if(name == "พาย")
        {
            CallView.Bind(characterPod.GetCharacterBeanByID(3));
        }
        if (name == "เอฟ")
        {
            CallView.Bind(characterPod.GetCharacterBeanByID(0));
        }


        SetActive();
    }

    private void SetupButtonListener()
    {
        HangUpButton.onClick.AddListener(() =>
        {
            CallingPanel.SetActive(false);
            soundManager.StopRingtoneSound();
        });
        CallingButton.onClick.AddListener(() =>
        {
            DialogueManager.UseDialogueUI(CallUI);
            CallPanel.SetActive(false);
            AcceptCallPanel.SetActive(true);
            DialoguePanelCall.SetActive(true);
            DialogueLua.SetVariable("NowCalling", true);
            soundManager.StopRingtoneSound();
            //ChatUIPanel.SetActive(false);

            
            //ChapterTemplateScriptableObject chapter = chapterpod.GetChapterByIndex(playerPod.current_date - 1);
            //startCall.StartCall(chapter.DataEachConversation[playerPod.PlayerReadingConversationIndex].Conversation);
            

        });
            
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void SetActive()

    {
        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ => {
            CallingPanel.SetActive(true);
            soundManager.PlayRingtoneSound();

        });


    }
}
