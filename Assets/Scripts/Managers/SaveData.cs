using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string MVP;
    public int highScore;
    public string lastPlayerName;

    public SaveData(GameManager gameManager) 
    {
        MVP = gameManager.MVP;
        highScore = gameManager.highScore;
        lastPlayerName = gameManager.playerName;
    }
}
