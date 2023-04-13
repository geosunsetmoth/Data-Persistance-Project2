using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private string playerName;
    public TMP_Text nameDisplay; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nameDisplay != null)
        {
            nameDisplay.SetText(playerName);
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReadName(string s)
    {
        playerName = s;
        Debug.Log(playerName);
    }
}
