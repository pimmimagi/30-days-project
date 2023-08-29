using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class showBG : MonoBehaviour
{
    public GameObject mansion_night;
    public GameObject mansion_day;

    // public GameObject timeBoxPrefab; 

    void Start()
    {
        Lua.RegisterFunction("SwitchBGtoNight", this, typeof(showBG).GetMethod("SwitchBGtoNight"));
    }

    public void SwitchBGtoNight()
    {
        if (mansion_day)
        {
            mansion_day.SetActive(false);
        }
        if (mansion_night)
        {
            mansion_night.SetActive(true);
        }

    }
}