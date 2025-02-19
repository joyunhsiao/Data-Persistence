using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{

    public static GameDataManager Instance;
    public string userName;
    public int userScore;
    public string highestUserName;
    public int highestUserScore;

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

    // Start is called before the first frame update
    void Start()
    {
        LoadGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string HighestUserName;
        public int HighestUserScore;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.HighestUserName = userName;
        data.HighestUserScore = userScore;

        string json = JsonUtility.ToJson(data);
      
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestUserName = data.HighestUserName;
            highestUserScore = data.HighestUserScore;
        }
    }
}
