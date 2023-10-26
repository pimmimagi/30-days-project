using TMPro;
using UnityEngine;

public class DayCellController : MonoBehaviour
{
    [SerializeField] private TMP_Text daytext;
    [SerializeField] private GameObject daymarker;

    public void SetDayText(int daynumber)
    {
        daytext.text = daynumber.ToString("00");
    }

    public void SetDayMarker(bool isActive) 
    { 
        daymarker.SetActive(isActive);
    }
}
