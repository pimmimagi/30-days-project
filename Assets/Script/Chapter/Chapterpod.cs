using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Chapterpod : MonoBehaviour
{
    public static Chapterpod Instance { get; private set; }

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

    private PlayerPod playerPod;
    private int CurrentChapter;
    public List<ChapterTemplateScriptableObject> ChapterTemplateList;
    public List<ChapterBean> ChapterBeanList;
    private void Start()
    {
        
        playerPod = PlayerPod.Instance;
        Debug.Log(GetChapterByIndex(0).DataEachConversation.Length);
        Debug.Log(GetChapterByIndex(1).DataEachConversation.Length);
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
