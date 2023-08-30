using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.Collections.LowLevel.Unsafe;
using System.Linq;

public class CharacterPod : MonoBehaviour
{
    public ReactiveProperty<int> relationshipvalue{ get; private set;}
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
            }

            
            CharacterBeanList.Add(characterBean);
            CharacterBeanList = CharacterBeanList.OrderByDescending(character => character.relationship).Take(3).ToList();
        }
    }
}
