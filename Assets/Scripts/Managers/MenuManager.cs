using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject nameText;
    public TMP_Text nameMesh;

    string a = "Valerie";
    string b = "valerie";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Display player's name
        if (nameMesh == null)
        {
            SetNameMesh();
        }

        else
        {
            nameMesh.SetText(GameManager.Instance.playerName);
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
        GameManager.Instance.playerName = s;
        Debug.Log(GameManager.Instance.playerName);
    }

    //Find TextMeshPro for the Username
    public void SetNameMesh()
    {
        nameText = GameObject.Find("Name Display");
        nameMesh = nameText.GetComponent<TMP_Text>();
    }


    //Load scene
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
