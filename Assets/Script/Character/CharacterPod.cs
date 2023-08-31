using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.Collections.LowLevel.Unsafe;
using System.Linq;

public class CharacterPod : MonoBehaviour

{
    public static CharacterPod Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }


  //  public ReactiveProperty<int> relationshipvalue{ get; private set;}
    public CharacterBean CharacterBean { get; private set;}

    public List<CharacterBean> CharacterBeanList;

    public List<CharacterTemplateScriptableObject> CharacterTemplateList;



    public void LoadCharacterData()
    {
        CharacterBeanList = new List<CharacterBean>();

        foreach (CharacterTemplateScriptableObject data in CharacterTemplateList)
        {
            CharacterBean characterBean = new CharacterBean();
            characterBean.characterData = data;
            characterBean.relationship = 10;

            if ( data.IDCharacter == 0)
            {
                characterBean.relationship = 81;
            } else if ( data.IDCharacter == 1) 

            {
                characterBean.relationship = 48;
            }
                else if ( data.IDCharacter == 2)
            {
                characterBean.relationship = 82;
            } else if (data.IDCharacter == 3)
            {
                characterBean.relationship = 100;
            }
            

            
            CharacterBeanList.Add(characterBean);
            CharacterBeanList = CharacterBeanList.OrderByDescending(character => character.relationship).Take(3).ToList();
        }
    }
    public void UpdateCurrentChatText(string newChatText)
    {
        CharacterBean.CurrentChatText.Value = newChatText;
        Debug.Log("Pod ปัจจุบัน คือ " + newChatText);
    }
}
