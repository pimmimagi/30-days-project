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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CharacterBean CharacterBean { get; private set;}

    public List<CharacterBean> CharacterBeanList;

    public List<CharacterTemplateScriptableObject> CharacterTemplateList;
    
    public bool CheckLoadCharacterdata = false;



    public void LoadCharacterData()
    {

        if (CheckLoadCharacterdata)
        {
            return;
        }
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
            CharacterBean = characterBean;
            CharacterBeanList = CharacterBeanList.OrderByDescending(character => character.relationship).Take(3).ToList();
            CheckLoadCharacterdata = true;
        }
    }
    public void UpdateCurrentChatText(int characterID, string newChatText)
    {
        var targetBean = GetCharacterBeanByID(characterID);
        if (targetBean != null)
        {
            if (targetBean.CurrentChatText != newChatText)
            {
                targetBean.CurrentChatText = newChatText;
             
            }
        }
    }


    public CharacterBean GetCharacterBeanByID(int id)
    {
        return CharacterBeanList.FirstOrDefault(bean => bean.characterData.IDCharacter == id);
    }
}
