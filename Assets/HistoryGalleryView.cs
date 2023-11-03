using PixelCrushers.DialogueSystem;
using UnityEngine;

public class HistoryGalleryView : MonoBehaviour
{
    [Header("Gallery History Lock Panel")]
    [SerializeField] private GameObject[] LockImageHistory;

    [Header("History Pod")]
    private HistoryPod historyPod;
    private PlayerPod playerPod;

    private void Start()
    {
        historyPod = HistoryPod.Instance;
        playerPod = PlayerPod.Instance;
        Lua.RegisterFunction("SetupHistoryImage", this, typeof(HistoryGalleryView).GetMethod("SetupHistoryImage"));
        Lua.RegisterFunction("SetUnlockCallHistory", this, typeof(HistoryGalleryView).GetMethod("SetUnlockCallHistory"));
    }

    public void Init()
    {
       historyPod = HistoryPod.Instance;
       playerPod = PlayerPod.Instance;
    }

    public void SetUnlockCallHistory()
    {
        historyPod.LoadGalleryHistory();
        for (int i = 0; i < historyPod.history.list.Count; i++)
        {
            if (historyPod.HistoryGallery.list[i] == 1)
            {
                LockImageHistory[0].SetActive(false);
            }
            else if (historyPod.HistoryGallery.list[i] == 2)
            {
                LockImageHistory[1].SetActive(false);
            }
        }
    }

    public void SetupHistoryImage()
    {
        historyPod.SaveGalleryHistory(playerPod.PlayerCallingConversation);
        historyPod.LoadGalleryHistory();
        //Debug.Log(historyPod.HistoryGallery.list.Count);
        //historyPod.SaveGalleryHistory(playerPod.PlayerCallingConversation);
        historyPod.LoadGalleryHistory();
        //Debug.Log(historyPod.HistoryGallery.list.Count);
        playerPod.UpdatePlayerCollectImage(playerPod.PlayerCollectImage + 1);
    }
}
