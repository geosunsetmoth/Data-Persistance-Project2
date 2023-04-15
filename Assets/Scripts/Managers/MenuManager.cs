using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public string playerName;

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
        if (nameMesh == null)
        {
            SetNameMesh();
        }

        //Display username
        if (nameMesh != null)
        {
            nameMesh.SetText(playerName);
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

    //Load game scene
    public void GoToScene()
    {
        SceneManager.LoadScene(1);
    }

    //Find TextMeshPro for the Username
    public void SetNameMesh()
    {
        nameText = GameObject.Find("Name Display");
        nameMesh = nameText.GetComponent<TMP_Text>();
    }
}
