using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Relationship : MonoBehaviour
{
    public GameObject Relationshippanel;
    public TMP_Text relationshiptext;
    public AudioSource Popupsoundrelationship;

    void Start()
    {
        Relationshippanel.SetActive(false);
        Lua.RegisterFunction("ChangeRelationshipScore", this, typeof(Relationship).GetMethod("ChangeRelationshipScore"));
    }

    // Update is called once per frame
    public void ChangeRelationshipScore(string NPCname , string score)
    {
        relationshiptext.text = "ค่าความสนิทกับ" + " " + NPCname + " " +"เพิ่มขึ้น" + score  ;
        Relationshippanel.SetActive (true);
        Popupsoundrelationship.Play();
        StartCoroutine(RemoveAfterSeconds(2, Relationshippanel));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
