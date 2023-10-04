using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChapterTemplatedata", order = 1)]
public class ChapterTemplateScriptableObject : ScriptableObject
{
    public int Order;
    public CharacterTemplateScriptableObject[] CharacterChat;
    public string[] Conversation;
}
    

