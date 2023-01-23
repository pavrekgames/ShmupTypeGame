using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Vector2 startPlayerPosition;
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Canvas HudCanvas;
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject enemies;
    public bool isGameEnd = false;

    [Header("TextMesh")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesCountText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI lastScoreText;

    [Header("HUD Values")]
    public static int score = 0;
    public static int bestScore = 0;
    public static int livesCount = 3;

    [Header("Time")]
    [SerializeField] private float time = 300f;
    private string minutes;
    private string seconds;

    private void Awake()
    {
        gameObject.GetComponent<SaveLoadScore>().LoadData();
        bestScoreText.text = bestScore.ToString();
        lastScoreText.text = score.ToString();
        startPlayerPosition = playerPosition.transform.position;
        Time.timeScale = 0;
    }

    void Update()
    {
        StartGame();
        UpdateHud();
        Timer();
        GameOver();
    }

    void Timer()
    {
        time -= Time.deltaTime * 1f;
    }

    void UpdateHud()
    {
        minutes = ((int)time / 60).ToString();
        seconds = (time % 60).ToString("f0");

        scoreText.text = score.ToString();
        livesCountText.text = livesCount.ToString();
        timeText.text = minutes + ":" + seconds;
    }

    void StartGame()
    {
        if (Input.anyKeyDown && startCanvas.enabled == true)
        {
            Time.timeScale = 1;
            startCanvas.enabled = false;
            isGameEnd = false;
            score = 0;
            livesCount = 3;
            time = 300f;
            playerPosition.transform.position = startPlayerPosition;
            HudCanvas.enabled = true;
        }
    }

    void GameOver()
    {
        if((livesCount <= 0 || time <= 0) && isGameEnd == false)
        {
            isGameEnd = true;
            Time.timeScale = 0;
            startCanvas.enabled = true;
            HudCanvas.enabled = false;

            CheckAndSetBestScore();
            DestroyAllBulletsAndEnemies();

            gameObject.GetComponent<SaveLoadScore>().SaveData();

        }
    }

    void DestroyAllBulletsAndEnemies()
    {
        for (int i = bullets.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(bullets.transform.GetChild(i).gameObject);
        }

        for (int i = enemies.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(enemies.transform.GetChild(i).gameObject);
        }
    }

    void CheckAndSetBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
        }

        bestScoreText.text = bestScore.ToString();
        lastScoreText.text = score.ToString();
    }
}
