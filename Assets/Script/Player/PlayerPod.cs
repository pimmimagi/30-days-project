using UnityEngine;
using UniRx;

public class PlayerPod : MonoBehaviour
{

    public static PlayerPod Instance { get; private set; }

    [Header("Current Date and Day")]
    public int current_date = 1;
    public string current_day = "Sunday";

    [Header("ReactiveProperty")]
    public ReactiveProperty<string> StatusPlayerText = new ReactiveProperty<string>("อันยอง");
    public ReactiveProperty<string> NoteText = new ReactiveProperty<string>("EnterText");
    public ReactiveProperty<bool> IsPlaying = new ReactiveProperty<bool>(false);
    public ReactiveProperty<bool> ReadAlready = new ReactiveProperty<bool>(false);
    public ReactiveProperty<bool> PlayerReadingMessage30DaysGroup = new ReactiveProperty<bool>(false);

    [Header("Reading Status Bool")]
    public int PlayerReadingID = -1;
    public int PlayerReadingConversationIndex = 2;

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

    public void UpdatePlayerIsReadingID(int newID)
    {
       PlayerReadingID = newID;
    }

    public void UpdateIsplayingValue(bool newValue)
    {
       IsPlaying.Value = newValue;
    }

    public void UpdateNoteText(string newNote)
    {
        NoteText.Value = newNote;
    }

    public void UpdateStatusText(string newStatus)
    {
        StatusPlayerText.Value = newStatus;
    }
 }
