using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalendarWidgetView : MonoBehaviour
{
    public GameObject dayPrefab;
    public Transform calendarPanel;

    private int totalDays = 30;
    private DayCellController[] dayCells;

    [SerializeField] private TMP_Text datetext;
    [SerializeField] private TMP_Text daytext;

    private PlayerPod playerPod;

    private void Start()
    {
        playerPod = PlayerPod.Instance;
        InitializeCalendar();
    }

    private void InitializeCalendar()
    {
        SetDateText(playerPod.current_date);
        SetDayText(playerPod.current_day);

        dayCells = new DayCellController[totalDays];

        for (int i = 0; i < totalDays; i++)
        {
            GameObject dayObject = Instantiate(dayPrefab, calendarPanel);
            DayCellController cell = dayObject.GetComponent<DayCellController>();

            if (cell != null)
            {
                cell.SetDayText(i + 1); 
                cell.SetDayMarker(i + 1 == playerPod.current_date);
                

                dayCells[i] = cell;
            }
        }
    }


    public void SetDateText(int datenumber)
    {
        datetext.text = datenumber.ToString("00");
    }

    public void SetDayText(string day)
    {
        daytext.text = day.ToString();
    }
}