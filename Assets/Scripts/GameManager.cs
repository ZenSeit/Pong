using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform Ball;
    [SerializeField] private Transform PaddleOne;
    [SerializeField] private Transform PaddleTwo;
    [SerializeField] private int scoreToWin = 3;

    [Header("UI")]
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject UIUser;

    private bool isPaused = false;
    private int paddleOneScore = 0;
    private int paddleTwoScore = 0;

    public static event Action<PaddleType, int> OnScoreChanged;
    public static event Action<PaddleType> OnPlayerWin;

    private static GameManager instance;

    private void Start()
    {
        ResetPositions();
        ResetScore();
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();
            }
            return instance;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
        UIUser.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
        UIUser.SetActive(true);
    }

    public void ScorePointToPaddle(PaddleType paddleType)
    {
        if (paddleType == PaddleType.Left)
        {
            paddleTwoScore++;
            OnScoreChanged?.Invoke(paddleType, paddleTwoScore);
        }
        else
        {
            paddleOneScore++;
            OnScoreChanged?.Invoke(paddleType, paddleOneScore);
        }

        if (paddleTwoScore >= scoreToWin)
            OnPlayerWin?.Invoke(PaddleType.Left);
        else if (paddleOneScore >= scoreToWin)
            OnPlayerWin?.Invoke(PaddleType.Right);
        else
            ResetPositions();
    }

    public void ResetPositions()
    {
        if (PaddleOne && PaddleTwo && Ball)
        {
            PaddleOne.position = new Vector2(PaddleOne.position.x, 0);
            PaddleTwo.position = new Vector2(PaddleTwo.position.x, 0);
            Ball.position = Vector2.zero;
        }
        else
        {
            Debug.LogWarning("Some references are missing when resetting positions");
        }
    }

    public void ResetScore()
    {
        paddleOneScore = 0;
        paddleTwoScore = 0;
        OnScoreChanged?.Invoke(PaddleType.Left, paddleOneScore);
        OnScoreChanged?.Invoke(PaddleType.Right, paddleTwoScore);
    }
}
