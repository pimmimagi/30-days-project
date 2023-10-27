using PixelCrushers.DialogueSystem;
using UnityEngine;

public class CallPod : MonoBehaviour
{
    public static CallPod Instance { get; private set; }

    [Header("Calling Bool")]
    public bool Calling1;
    public bool Calling2;
    public bool Calling3;
    public bool Calling4;

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
        Lua.RegisterFunction("SettingCallToFalse", this, typeof(CallPod).GetMethod("SettingCallToFalse"));
        Lua.RegisterFunction("GetVariableCalling", this, typeof(CallPod).GetMethod("GetVariableCalling"));
    }

    public void GetVariableCalling()
    {
        Calling1 = DialogueLua.GetVariable("Calling 1").AsBool;
        Calling2 = DialogueLua.GetVariable("Calling 2").AsBool;
        Calling3 = DialogueLua.GetVariable("Calling 3").AsBool;
        Calling4 = DialogueLua.GetVariable("Calling 4").AsBool;
        Debug.Log("Calling1 = " + Calling1);
        Debug.Log("Calling2 = " + Calling2);
        Debug.Log("Calling3 = " + Calling3);
        Debug.Log("Calling4 = " + Calling4);
    }

    public void SettingCall()
    {
        DialogueLua.SetVariable("Calling 1", Calling1);
        DialogueLua.SetVariable("Calling 2", Calling2);
        DialogueLua.SetVariable("Calling 3", Calling3);
        DialogueLua.SetVariable("Calling 4", Calling4);
        Debug.Log("Calling 1 after set : " + DialogueLua.GetVariable("Calling 1").AsBool);
        Debug.Log("Calling 2 after set : " + DialogueLua.GetVariable("Calling 2").AsBool);
        Debug.Log("Calling 3 after set : " + DialogueLua.GetVariable("Calling 3").AsBool);
        Debug.Log("Calling 4 after set : " + DialogueLua.GetVariable("Calling 4").AsBool);
    }

    public void SettingCallToFalse()
    {
        DialogueLua.SetVariable("Calling 1", false);
        DialogueLua.SetVariable("Calling 2", false);
        DialogueLua.SetVariable("Calling 3", false);
        DialogueLua.SetVariable("Calling 4", false);
    }


}
