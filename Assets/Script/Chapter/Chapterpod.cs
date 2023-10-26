using System.Collections.Generic;
using UnityEngine;

public class Chapterpod : MonoBehaviour
{
    public static Chapterpod Instance { get; private set; }

    [Header("Pod")]
    private PlayerPod playerPod;

    [Header("ChapterTemplateScriptableObject")]
    public List<ChapterTemplateScriptableObject> ChapterTemplateList;

    [Header("ChapterBeanList")]
    public List<ChapterBean> ChapterBeanList;

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

    private void Start()
    {
        playerPod = PlayerPod.Instance;
    }

    public int CurrentChapterID()
    {
        return playerPod.PlayerReadingID;
    }

    public void LoadChapterData()
    {
        ChapterBeanList = new List<ChapterBean>();

        foreach (ChapterTemplateScriptableObject data in ChapterTemplateList)
        {
            ChapterBean ChapterBean = new ChapterBean();
            ChapterBean.ChapterData = data;
            ChapterBeanList.Add(ChapterBean);
        }
    }

    public ChapterTemplateScriptableObject GetChapterByIndex(int index)
    {
        if (index >= 0 && index < ChapterTemplateList.Count)
        {
            return ChapterTemplateList[index];
        }
        else
        {
            Debug.LogError($"Chapter index {index} out of bounds.");
            return null;
        }
    }
}
