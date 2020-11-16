using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager
{
    private SaveData saveData;

    public int[] GetOpenLevel => saveData.openLevel;
    public int[] GetCompleteLevel => saveData.completeLevel;
    public bool IsFirstGameStar => PlayerPrefs.HasKey("data");

    public SaveDataManager()
    {
        LoadData();
    }
    
    public void SaveOpenLevel(int index)
    {
        var listOpen = new List<int>(saveData.openLevel);
        if (listOpen.Contains(index + 1)) return;
        listOpen.Add(index + 1);
        saveData.openLevel = listOpen.ToArray();
    }

    public void SaveCompleteLevel(int index)
    {
        var listComplete = new List<int>(saveData.completeLevel);
        listComplete.Add(index);
        saveData.completeLevel = listComplete.ToArray();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("data", json);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("data"))
        {
            string json = PlayerPrefs.GetString("data");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else saveData = new SaveData();
    }
}