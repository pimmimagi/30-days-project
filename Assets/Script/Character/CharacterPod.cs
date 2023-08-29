using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.Collections.LowLevel.Unsafe;

public class CharacterPod : MonoBehaviour
{
    public ReactiveProperty<int> relationshipvalue{ get; private set;}
    public CharacterBean CharacterBean { get; private set;}

    public List<CharacterBean> CharacterBeanList;

    public List<CharacterTemplateScriptableObject> CharacterTemplateList;

    public void Initialize(CharacterBean characterBean)
    {
        this.CharacterBean = characterBean;
        this.relationshipvalue = new ReactiveProperty<int>(characterBean.relationship);
        /*foreach (CharacterBean bean in Characterlist)
        {
            Initialize(bean);
        }*/
    }

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
                characterBean.relationship = 5;
            } else if ( data.IDCharacter == 1) 

            {
                characterBean.relationship = 10;
            }
                else if ( data.IDCharacter == 2)
            {
                characterBean.relationship = 2;
            }

            CharacterBeanList.Add(characterBean);
        }
    }
}
