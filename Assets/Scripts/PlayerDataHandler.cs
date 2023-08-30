using System.IO;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler Instance;

    public int BestPlayerScore;
    public string BestPlayerName;
    public string CurrentPlayer;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void SaveBestScore(int score, string name)
    {
        BestScoreData data = new();

        if (score > BestPlayerScore)
        {
            BestPlayerScore = score;
            BestPlayerName = name;

        }

        CurrentPlayer = name;
        data.BestScore = BestPlayerScore;
        data.BestPlayer = BestPlayerName;
        data.PreviousPlayer = CurrentPlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);

            BestPlayerScore = data.BestScore;
            BestPlayerName = data.BestPlayer;
            CurrentPlayer = data.PreviousPlayer;
        }
    }


    [System.Serializable]
    class BestScoreData
    {
        public int BestScore;
        public string BestPlayer;
        public string PreviousPlayer;
    }
}
