using System.Collections.Generic;
using UnityEngine;

public class HistoryPod : MonoBehaviour
{
    public static HistoryPod Instance { get; private set; }

    public SerializableList<int> history = new SerializableList<int>();
    public SerializableList<int> HistoryGallery = new SerializableList<int>();

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

    public void SaveHistory(int Callnumber)
    {
        history.list.Add(Callnumber);
        string saveJson = JsonUtility.ToJson(history);
        PlayerPrefs.SetString("SaveHistory", saveJson);
    }

    public void LoadHistory() 
    {
        string save =  PlayerPrefs.GetString("SaveHistory");

         history = JsonUtility.FromJson<SerializableList<int>>(save);
    }

    public void SaveGalleryHistory(int ImageNumber)
    {
        HistoryGallery.list.Add(ImageNumber);
        string saveJson = JsonUtility.ToJson(HistoryGallery);
        PlayerPrefs.SetString("SaveGalleryHistory", saveJson);
    }

    public void LoadGalleryHistory()
    {
        string save = PlayerPrefs.GetString("SaveGalleryHistory");

        HistoryGallery = JsonUtility.FromJson<SerializableList<int>>(save);
    }
}

[System.Serializable]
public class SerializableList<T>
{
    public List<T> list = new List<T>();
}