using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoxManagement : MonoBehaviour

{
    public GameObject TimeboxPrefab;


    void Start()
    {
        Lua.RegisterFunction("ShowMessage", this, SymbolExtensions.GetMethodInfo(() => ShowMessage(string.Empty)));
    }

    public TimeBox CreateTimebox ()
    {
        GameObject newTimeBox = Instantiate(TimeboxPrefab, transform.parent); 
        TimeBox TimeboxComponent  = newTimeBox.GetComponent<TimeBox>();

        if (TimeboxComponent == null)
        {
            Destroy(newTimeBox);
            return null;
        } return TimeboxComponent;
    } 
    
    public void ShowMessage (string message)
    {
        TimeBox newTimebox  = CreateTimebox();
        if (newTimebox != null)
        {
            Debug.Log(message);
            newTimebox.ShowTimebox(message);
        }
    }

}
