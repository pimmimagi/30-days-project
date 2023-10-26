using UnityEngine;

public class RelationshipWidgetView : MonoBehaviour
{
    [Header("RelationshipCellView")]   
    [SerializeField] private RelationshipCellView relationshipCellView1;
    [SerializeField] private RelationshipCellView relationshipCellView2;
    [SerializeField] private RelationshipCellView relationshipCellView3;

    [Header("Pod")]
    private CharacterPod characterPod;

    private void Start()
    {
        characterPod = CharacterPod.Instance;
        characterPod.LoadCharacterData();

        relationshipCellView1.Bind(characterPod.CharacterBeanList[0]);
        relationshipCellView2.Bind(characterPod.CharacterBeanList[1]);
        relationshipCellView3.Bind(characterPod.CharacterBeanList[2]);
    }
}
