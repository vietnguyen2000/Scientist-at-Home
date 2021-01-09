using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager
{
    public class PlayerData
    {
        public int level;
        public float timeWinGame1;
        public float timeWinGame2;
        public float timeWinGame3;
    }
    // Start is called before the first frame update
    public PlayerData SavedData { get; set; }
    private SaveLoadManager(){
        path = Application.persistentDataPath + "player_data.json";
        SavedData = new PlayerData();
        if (File.Exists(path))
            ReadSavedData();
        else
            WriteDefaultData();
    }
    private static SaveLoadManager instance = null;
    public static SaveLoadManager Instance{
        get{
            if (instance == null)  
            {  
                instance = new SaveLoadManager();  
            }  
            return instance;  
        }
    }
    string path;
    public void WriteDefaultData()
    {
        SavedData.level = 1;
    }
    public void WriteNewPlayerData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(SavedData));
    }
    public void ReadSavedData()
    {
        SavedData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));
    }
    public void PassNewLevel()
    {
        SavedData.level +=1;
        WriteNewPlayerData();
    }
}
