using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterTemplateData", order = 1)]
public class CharacterTemplateScriptableObject : ScriptableObject
{
    public int IDCharacter;
    public string NameText;
    public Sprite ProfileSprite;
}