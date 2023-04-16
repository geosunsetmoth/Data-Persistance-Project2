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
    public GameObject errorText;

    string a = "Valerie";
    string b = "valerie";

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
        if (s.Length <= 100)
        {
            errorText.SetActive(false);
            GameManager.Instance.playerName = s;
            Debug.Log(GameManager.Instance.playerName);
        }

        else
        {
            errorText.SetActive(true);
        }
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
