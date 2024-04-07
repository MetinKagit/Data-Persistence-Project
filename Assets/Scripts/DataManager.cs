using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public TMP_InputField username;
    public string currentPlayerName;
    
    public int bestScore;
    public string bestScoreUsername;
    
    //public String playerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        LoadBestScoreAndUsername();
        username.text = bestScoreUsername;
        DontDestroyOnLoad(gameObject);
        
    }
    
    [System.Serializable]
    class SaveData
    {
        public string bestScoreUsername;
        public int bestScore;
    }
    
    public void SaveBestScoreAndUsername(string username, int score)
    {
        // Load the current best score and username
        LoadBestScoreAndUsername();

        // Only save the score and username if the score is higher than the best score
        if (score > bestScore)
        {
            SaveData data = new SaveData();
            data.bestScoreUsername = username;
            data.bestScore = score;

            string json = JsonUtility.ToJson(data);
            
            File.WriteAllText(Application.persistentDataPath+ "/savefilegamedata.json", json);
        }
    }

    public void LoadBestScoreAndUsername()
    {
        string path = Application.persistentDataPath + "/savefilegamedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            bestScoreUsername = data.bestScoreUsername;
            bestScore = data.bestScore;
        }
    }
}
