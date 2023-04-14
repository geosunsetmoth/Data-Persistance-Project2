using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] public static string playerName;
    public GameObject nameText;
    public TMP_Text nameMesh;

    string a = "Valerie";
    string b = "valerie";

    private void Awake()
    {
        //Singleton Pattern
        Instance = this;
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //Fint TextMeshPro for the Username
        nameText = GameObject.Find("Name Display");
        nameMesh = nameText.GetComponent<TMP_Text>();
    }

    void Update()
    {
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

    //Load game
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
