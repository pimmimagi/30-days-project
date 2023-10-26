using TMPro;
using UnityEngine;

public class CalendarWidgetView : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject dayPrefab;

    [Header("Calendar Transform")]
    [SerializeField] private Transform calendarPanel;

    [Header("Total Day and DayCells")]
    private int totalDays = 30;
    private DayCellController[] dayCells;

    [Header("Date and Day Text")]
    [SerializeField] private TMP_Text datetext;
    [SerializeField] private TMP_Text daytext;

    [Header("Pod")]
    private PlayerPod playerPod;

    private void Update()
    {
        DateAndDay(playerPod.current_date);
    }

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

    public void DateAndDay(int currentdate)
    {
        if (currentdate % 7 == 1)
         {
            playerPod.current_day = "Sunday";
        }
        if (currentdate % 7 == 2)
        {
            playerPod.current_day = "Monday";
        }
        if (currentdate % 7 == 3)
        {
            playerPod.current_day = "Tuesday";
        }
        if (currentdate % 7 == 4)
        {
            playerPod.current_day = "Wednesday";
        }
        if (currentdate % 7 == 5)
        {
            playerPod.current_day = "Thursday";
        }
        if (currentdate % 7 == 6)
        {
            playerPod.current_day = "Friday";
        }
        if (currentdate % 7 == 7)
        {
            playerPod.current_day = "Saturday";
        }
    }
}

