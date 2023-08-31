using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatlistView : MonoBehaviour
{
    public ChatCellView ChatlistCellViewPie;
    public CharacterPod characterPod;

    private void Start()
    {
        characterPod = CharacterPod.Instance;
        characterPod.LoadCharacterData();
        if (characterPod.CharacterBean.characterData.IDCharacter == 3)
            {
                ChatlistCellViewPie.Bind(characterPod.CharacterBean);
            }
        }
    }

