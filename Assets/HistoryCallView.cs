using UnityEngine;

public class HistoryCallView : MonoBehaviour
{
    [Header("Call History Lock Panel")]
    [SerializeField] private GameObject[] LockCallHistory;

    [Header("Pod")]
    [SerializeField] private CallPod callPod;
    [SerializeField] private HistoryPod historyPod;

    private void Start()
    {
        callPod = CallPod.Instance;
        historyPod = HistoryPod.Instance;
    }

    private void Update()
    {
        SetUnlockCallHistory();
    }

    public void SetUnlockCallHistory()
    {
        historyPod.LoadHistory();
        for (int i = 0; i < historyPod.history.list.Count; i++) {
            if (historyPod.history.list[i] == 1)
            {
                LockCallHistory[0].SetActive(false);
            }
        }
    }
}
