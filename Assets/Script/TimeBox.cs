using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class TimeBox : MonoBehaviour
{
    public Text time;
    
   // public GameObject timeBoxPrefab; 

    void Start()
    {
        Lua.RegisterFunction("ShowTimebox", this, SymbolExtensions.GetMethodInfo(() => ShowTimebox(string.Empty)));
    }

    public void ShowTimebox(string message)
    {

       // if (message == null)
      //  {
        time.text = message;
        gameObject.SetActive(true);
            
       // }
    }
}