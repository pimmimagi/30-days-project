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
            
            if (data.IDCharacter == 0)
            {
                characterBean.relationship = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("Frelationship").asInt;
            }
            else if (data.IDCharacter == 1)
            {
                characterBean.relationship = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("Ninrelationship").asInt;
            }
            else if (data.IDCharacter == 2)
            {
                characterBean.relationship = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("Poomrelationship").asInt;
            }
            else if (data.IDCharacter == 3)
            {
                characterBean.relationship = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("Pierelationship").asInt;
            }
            CharacterBeanList.Add(characterBean);
          
        }


        //  CharacterBean = characterBean;
        CharacterBeanList = CharacterBeanList.OrderByDescending(character => character.relationship).Take(3).ToList();
        CheckLoadCharacterdata = true;

    }
    public void UpdateCurrentChatText(int characterID, string newChatText)
    {
        var targetBean = GetCharacterBeanByID(characterID);
       
            if (targetBean != null && targetBean.CurrentChatText != newChatText)
            {
                targetBean.CurrentChatText = newChatText;

            }
        
    }

    public void UpdateCheckPlayerReadMessageAlready(int characterID, bool newValue)
    {
        var targetBean = GetCharacterBeanByID(characterID);
        if (targetBean != null)
        {
            targetBean.CheckPlayerReadMessageAlready = newValue;
        }
    }

    public void UpdatePlayerisReadingThisCharacter(int characterID, bool newValue)
    {
        var targetBean = GetCharacterBeanByID(characterID);
        if (targetBean != null)
        {
            targetBean.PlayerisReadingThisCharacter = newValue;
        }
    }

    public CharacterBean GetCharacterBeanByID(int id)
    {
        return CharacterBeanList.FirstOrDefault(bean => bean.characterData.IDCharacter == id);
    }
}
