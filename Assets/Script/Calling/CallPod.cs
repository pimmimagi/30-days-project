using PixelCrushers.DialogueSystem;
using UnityEngine;

public class CallPod : MonoBehaviour
{
    public static CallPod Instance { get; private set; }

    [Header("Calling Bool")]
    [SerializeField] private bool Calling1;
    [SerializeField] private bool Calling2;
    [SerializeField] private bool Calling3;
    [SerializeField] private bool Calling4;

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

    public void GetVariableCalling()
    {
        Calling1 = DialogueLua.GetVariable("Calling 1").AsBool;
        Calling2 = DialogueLua.GetVariable("Calling 2").AsBool;
        Calling3 = DialogueLua.GetVariable("Calling 3").AsBool;
        Calling4 = DialogueLua.GetVariable("Calling 4").AsBool;
    }

    public void SettingCall()
    {
        DialogueLua.SetVariable("Calling 1", Calling1);
        DialogueLua.SetVariable("Calling 2", Calling2);
        DialogueLua.SetVariable("Calling 3", Calling3);
        DialogueLua.SetVariable("Calling 4", Calling4);
    }

    public void SettingCallToFalse()
    {
        DialogueLua.SetVariable("Calling 1", false);
        DialogueLua.SetVariable("Calling 2", false);
        DialogueLua.SetVariable("Calling 3", false);
        DialogueLua.SetVariable("Calling 4", false);
    }


}
