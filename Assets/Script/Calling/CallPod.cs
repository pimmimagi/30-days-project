using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPod : MonoBehaviour
{
    public static CallPod Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Lua.RegisterFunction("SettingCall", this, typeof(CallPod).GetMethod("SettingCal"));
        Lua.RegisterFunction("SettingCallToFalse", this, typeof(CallPod).GetMethod("SettingCal"));
        Lua.RegisterFunction("GetVariableCalling", this, typeof(CallPod).GetMethod("GetVariableCalling"));

    }
    public bool Calling1;
    public bool Calling2;
    public bool Calling3;
    public bool Calling4;

    public void GetVariableCalling()
    {
        Calling1 = DialogueLua.GetVariable("Calling 1").AsBool;
        Calling2 = DialogueLua.GetVariable("Calling 2").AsBool;
        Calling3 = DialogueLua.GetVariable("Calling 3").AsBool;
        Calling4 = DialogueLua.GetVariable("Calling 4").AsBool;
        Debug.LogError("Calling 1 is " + Calling1);
        Debug.LogError("Calling 2 is " + Calling2);
        Debug.LogError("Calling 3 is " + Calling3);
        Debug.LogError("Calling 4 is " + Calling4);

    }

    public void SettingCall()
    {
        Debug.LogError("Calling 1 is " + Calling1);
        Debug.LogError("Calling 2 is " + Calling2);
        Debug.LogError("Calling 3 is " + Calling3);
        Debug.LogError("Calling 4 is " + Calling4);
        Debug.Log("In dialogue system calling 1 is " + DialogueLua.GetVariable("Calling 1").AsBool);
        Debug.Log("In dialogue system calling 2 is " + DialogueLua.GetVariable("Calling 2").AsBool);
        Debug.Log("In dialogue system calling 3 is " + DialogueLua.GetVariable("Calling 3").AsBool);
        Debug.Log("In dialogue system calling 4 is " + DialogueLua.GetVariable("Calling 4").AsBool);
        DialogueLua.SetVariable("Calling 1", Calling1);
        DialogueLua.SetVariable("Calling 2", Calling2);
        DialogueLua.SetVariable("Calling 3", Calling3);
        DialogueLua.SetVariable("Calling 4", Calling4);
        Debug.Log("In dialogue system calling 1 is " + DialogueLua.GetVariable("Calling 1").AsBool);
        Debug.Log("In dialogue system calling 2 is " + DialogueLua.GetVariable("Calling 2").AsBool);
        Debug.Log("In dialogue system calling 3 is " + DialogueLua.GetVariable("Calling 3").AsBool);
        Debug.Log("In dialogue system calling 4 is " + DialogueLua.GetVariable("Calling 4").AsBool);


    }

    public void SettingCallToFalse()
    {
        DialogueLua.SetVariable("Calling 1", false);
        DialogueLua.SetVariable("Calling 2", false);
        DialogueLua.SetVariable("Calling 3", false);
        DialogueLua.SetVariable("Calling 4", false);
    }


}
