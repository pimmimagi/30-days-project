using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class TextAndImageSubtitlePanel : PixelCrushers.DialogueSystem.Wrappers.StandardUISubtitlePanel
{
    public Image imageInChat;
    public override void SetContent(Subtitle subtitle)
    {
        if (subtitle == null) return;
        Debug.LogError(subtitle.formattedText.text);
        currentSubtitle = subtitle;
        lastActorID = subtitle.speakerInfo.id;
        CheckSubtitleAnimator(subtitle);
        if (!onlyShowNPCPortraits || subtitle.speakerInfo.isNPC)
        {
            if (portraitImage != null)
            {
                var sprite = subtitle.GetSpeakerPortrait();
                SetPortraitImage(sprite);
            }
            portraitActorName = subtitle.speakerInfo.nameInDatabase;
            if (portraitName.text != subtitle.speakerInfo.Name)
            {
                portraitName.text = subtitle.speakerInfo.Name;
                UITools.SendTextChangeMessage(portraitName);
            }
        }
        if (subtitle.formattedText.text.Contains("#Image_1"))
        {
            imageInChat.gameObject.SetActive(true);
            subtitleText.gameObject.SetActive(false);
            Addressables.LoadAssetAsync<Sprite>("123").Completed += (task) => {
                imageInChat.rectTransform.sizeDelta = new Vector2(20, 20);
                imageInChat.sprite = task.Result;
            };
        }
        else
        {
            if (waitForOpen && panelState != PanelState.Open)
            {
                DialogueManager.instance.StartCoroutine(SetSubtitleTextContentAfterOpen(subtitle));
            }
            else
            {
                SetSubtitleTextContent(subtitle);
            }
        }
        frameLastSetContent = Time.frameCount;
    }
}
