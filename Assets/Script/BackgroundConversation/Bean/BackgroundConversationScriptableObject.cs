using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BackgroundConversationData", order = 1)]
public class BackgroundConversationScriptableObject : ScriptableObject
{
    public BackgroundConversationState backgroundConversationState;
    public Sprite backgroundSprite;
}