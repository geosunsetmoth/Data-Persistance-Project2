using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName = "Kevin Anthony";
    public string MVP;
    public int highScore;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        //Singleton Pattern
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

    public void Save()
    {
        SaveManager.SaveGame(this);
    }

    public void Load()
    {
        SaveData data = SaveManager.LoadSave();

        playerName = data.lastPlayerName;
        MVP = data.MVP;
        highScore = data.highScore;
    }
}
