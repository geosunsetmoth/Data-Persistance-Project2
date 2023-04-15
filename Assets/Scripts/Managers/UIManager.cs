using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public string playerName = "Kevin Anthony";
    public int playerScore;

    public GameObject nameText;
    public TMP_Text nameMesh;

    string a = "Valerie";
    string b = "valerie";


    void Update()
    {
        if (nameMesh == null)
        {
            SetNameMesh();
        }

        //Display username
        if (nameMesh != null)
        {
            nameMesh.SetText(playerName);
        }

        //Gets the user score
        if (MainManager.Instance != null)
        {
            playerScore = MainManager.Instance.points;
        }
    }

    public void ReadName(string s)
    {
        //Easter egg for Valerie
        if (s == a || s == b)
        {
            s = "Fairy Mermaid Kitten Princess";
        }

        //Set playerName variable
        playerName = s;
        Debug.Log(playerName);
    }

    //Find TextMeshPro for the Username
    public void SetNameMesh()
    {
        nameText = GameObject.Find("Name Display");
        nameMesh = nameText.GetComponent<TMP_Text>();
    }
}
