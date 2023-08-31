using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ChatCellView: MonoBehaviour
{
    public TMP_Text Currenttext;
    public Image CharacterImage;
    public TMP_Text CharacterNameText;
    private PlayerPod playerpod;
    private CharacterPod characterpod;

    private void Start()
    {
        playerpod = PlayerPod.Instance;
        characterpod = CharacterPod.Instance;
        SetupSubscribe();
    }

    private void SetupSubscribe()
    {
        characterpod.CharacterBean.CurrentChatText.Subscribe(newcurrentText => {
            Currenttext.text = newcurrentText;
        }).AddTo(this);
    }

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
    }
}