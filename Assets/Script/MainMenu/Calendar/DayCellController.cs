using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DayCellController : MonoBehaviour
{
    // Start is called before the first frame update

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
