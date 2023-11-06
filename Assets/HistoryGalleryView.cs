using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class HistoryGalleryView : MonoBehaviour
{
    [Header("Gallery History Lock Panel")]
    [SerializeField] private GameObject[] LockImageHistory;

    [Header("Gallery Button List")]
    [SerializeField] private Button[] ButtonImageList;

    [Header("Full Image List")]
    [SerializeField] private GameObject[] FullImagelist;

    [Header("FullImagePanel")]
    [SerializeField] private GameObject FullImagePanel;

    [Header("Pod")]
    private HistoryPod historyPod;
    private PlayerPod playerPod;

    private void Start()
    {
        historyPod = HistoryPod.Instance;
        playerPod = PlayerPod.Instance;
        Lua.RegisterFunction("SetupHistoryImage", this, typeof(HistoryGalleryView).GetMethod("SetupHistoryImage"));
        Lua.RegisterFunction("SetUnlockGalleryHistory", this, typeof(HistoryGalleryView).GetMethod("SetUnlockGalleryHistory"));
        SetupButtonListener();
    }

    private void Update()
    {
        SetupButtonListener();
    }

    public void Init()
    {
       historyPod = HistoryPod.Instance;
       playerPod = PlayerPod.Instance;
    }

    public void SetUnlockGalleryHistory()
    {
        Debug.Log("Run SetUnlockGalleryHistory");
        historyPod.LoadGalleryHistory();

        for (int i = 0; i < historyPod.HistoryGallery.list.Count; i++)
        {
            Debug.Log(historyPod.HistoryGallery.list.Count);
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
        Debug.Log("Run HistoryImage");
        historyPod.SaveGalleryHistory(playerPod.PlayerCallingConversation);
        historyPod.LoadGalleryHistory();
        historyPod.LoadGalleryHistory();
        playerPod.UpdatePlayerCollectImage(playerPod.PlayerCollectImage + 1);
    }

    private void SetupButtonListener()
    { 
        ButtonImageList[0].onClick.AddListener(() =>
        {
            SetInactiveImage();
            FullImagelist[0].SetActive(true);
            FullImagePanel.SetActive(true);
        });

        ButtonImageList[1].onClick.AddListener(() =>
        {
            SetInactiveImage();
            FullImagelist[1].SetActive(true);
            FullImagePanel.SetActive(true);
        });
    }

    public void SetInactiveImage()
    {
      for (int i = 0; i < FullImagelist.Length; i++)
        {
            FullImagelist[i].SetActive(false);
        }
    }
}
