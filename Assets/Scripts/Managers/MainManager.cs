using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [SerializeField] private Brick BrickPrefab;
    [SerializeField] private int LineCount = 6;
    [SerializeField] private Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    public GameObject RestartButton;
    public GameObject LeaderButton;

    private bool started = false;
    public int points;
    
    public bool isGameOver = false;

    public string playerName = "Kevin Anthony";
    public int playerScore;

    public GameObject nameText;
    public TMP_Text nameMesh;
    public GameObject MVPText;
    public TMP_Text MVPMesh;
    public GameObject highScoreText;
    public TMP_Text highScoreMesh;


    //Instantiate
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nameMesh = nameText.GetComponent<TMP_Text>();
        nameMesh.SetText(GameManager.Instance.playerName);
        MVPMesh = MVPText.GetComponent<TMP_Text>();
        MVPMesh.SetText(GameManager.Instance.MVP);
        highScoreMesh = highScoreText.GetComponent<TMP_Text>();
        highScoreMesh.SetText(GameManager.Instance.highScore.ToString());

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        // Start Game
        if (!started && Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            float randomDirection = Random.Range(-1.0f, 1.0f);
            Vector3 forceDir = new Vector3(randomDirection, 1, 0);
            forceDir.Normalize();

            Ball.transform.SetParent(null);
            Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
        }
    }

    // Manage Points
    void AddPoint(int point)
    {
        points += point;
        ScoreText.text = $"Score: {points}";

        if (points > GameManager.Instance.highScore)
        {
            GameManager.Instance.highScore = points;
            GameManager.Instance.MVP = GameManager.Instance.playerName;
            MVPMesh.SetText(GameManager.Instance.MVP);
            highScoreMesh.SetText(GameManager.Instance.highScore.ToString());
        }
    }

    // Manage GameOver
    public void GameOver()
    {
        isGameOver = true;
        GameOverText.SetActive(true);
        RestartButton.SetActive(true);
        LeaderButton.SetActive(true);
    }

    // Load menu scene
    public void GoToScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
