using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class TimeBox : MonoBehaviour
{
    public Text time;
 
    void Start()
    {
        Lua.RegisterFunction("ShowTimebox", this, SymbolExtensions.GetMethodInfo(() => ShowTimebox(string.Empty)));
    }

    public void ShowTimebox(string message)
    {
        time.text = message;
        gameObject.SetActive(true);
    }
}