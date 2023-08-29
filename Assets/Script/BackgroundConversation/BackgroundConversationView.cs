using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using PixelCrushers.DialogueSystem;

public class BackgroundConversationView : MonoBehaviour
{
    [Header("Background GameObject")]
    [SerializeField] private Image conversationBackgroundImage;

    [SerializeField] private Button mansionDayButton;
    [SerializeField] private Button mansionNightButton;

    [Header("Background Conversation Pod")]
    [SerializeField] private BackgroundConversationPod backgroundConversationPod;

    void Start()
    {
        SetupSubscribe();
        Lua.RegisterFunction("ChangeBackgroundConversationState", this, typeof(BackgroundConversationPod).GetMethod("ChangeBackgroundConversationState"));
        //SetupButtonListener();
    }

    private void SetupSubscribe()
    {
        backgroundConversationPod.backgroundConversationState.Subscribe(state =>
        {
            ChangeBackgroundConversation(GetCurrentBackground(state));
        }).AddTo(this);
    }

    private void SetupButtonListener()
    {
        mansionDayButton.onClick.AddListener(() =>
        {
            backgroundConversationPod.ChangeBackgroundConversationState(BackgroundConversationState.Mansion_Day);
        });

        mansionNightButton.onClick.AddListener(() =>
        {
            backgroundConversationPod.ChangeBackgroundConversationState(BackgroundConversationState.Mansion_Night);
        });
    }

    private void ChangeBackgroundConversation(Sprite backgroundSprite)
    {
        conversationBackgroundImage.sprite = backgroundSprite;
    }

    public Sprite GetCurrentBackground(BackgroundConversationState state)
    {
        for (int i = 0; i < backgroundConversationPod.backgroundConversaionBeanList.Count; i++)
        {
            if (backgroundConversationPod.backgroundConversaionBeanList[i].backgroundConversationState == state)
                return backgroundConversationPod.backgroundConversaionBeanList[i].backgroundSprite;
        }

        return backgroundConversationPod.backgroundConversaionBeanList[0].backgroundSprite;
    }
}
