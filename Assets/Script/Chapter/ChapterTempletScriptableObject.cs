using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChapterTemplatedata", order = 1)]
public class ChapterTemplateScriptableObject : ScriptableObject
{
    public int Order;
    [System.Serializable]
    public class CharacterAndConversation
    {
        public CharacterTemplateScriptableObject CharacterChat;
        public string Conversation;
    }

    public CharacterAndConversation[] DataEachConversation;
}


    

