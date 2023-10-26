using System.Collections.Generic;
using UnityEngine;

public class HistoryPod : MonoBehaviour
{
    public static HistoryPod Instance { get; private set; }

    public SerializableList<int> history = new SerializableList<int>();

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
        Debug.Log(saveJson);
        PlayerPrefs.SetString("SaveHistory", saveJson);
    }

    public void LoadHistory() 
    {
        string save =  PlayerPrefs.GetString("SaveHistory");

         history = JsonUtility.FromJson<SerializableList<int>>(save);
        //Debug.Log(history.list.Count);
    }


}


[System.Serializable]
public class SerializableList<T>
{
    public List<T> list = new List<T>();
}