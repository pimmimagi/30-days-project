using UniRx;

public class CharacterBean
{
    public CharacterTemplateScriptableObject characterData;
    public int relationship;
    public ReactiveProperty<string> CurrentChatText = new ReactiveProperty<string>("");
}
