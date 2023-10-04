using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipWidgetView : MonoBehaviour
{   
    public RelationshipCellView relationshipCellView1;
    public RelationshipCellView relationshipCellView2;
    public RelationshipCellView relationshipCellView3;
    public CharacterPod characterPod;

    private void Awake()
    {
        characterPod.LoadCharacterData();
    }
    private void Start()
    {
        relationshipCellView1.Bind(characterPod.CharacterBeanList[0]);
        relationshipCellView2.Bind(characterPod.CharacterBeanList[1]);
        relationshipCellView3.Bind(characterPod.CharacterBeanList[2]);

    }
}
