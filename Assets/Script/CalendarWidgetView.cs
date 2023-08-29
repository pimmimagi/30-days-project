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

    public PlayerPod playerPod;

    private void Start()
    {
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

                if (i+1 == playerPod.current_date)
                {
                    cell.SetDayMarker(true);
                }
                else
                {
                    cell.SetDayMarker(false);
                }

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
