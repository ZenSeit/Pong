using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUser : MonoBehaviour
{
    [SerializeField] private TMP_Text paddleLeft;
    [SerializeField] private TMP_Text paddleRight;

    void OnEnable()
    {
        GameManager.OnScoreChanged += UpdateScore;
        GameManager.OnPlayerWin += ShowWinner;
    }

    void OnDisable()
    {
        GameManager.OnScoreChanged -= UpdateScore;
        GameManager.OnPlayerWin -= ShowWinner;
    }

    private void UpdateScore(PaddleType paddleType, int newScore)
    {
        if (paddleType == PaddleType.Left)
        {
            paddleLeft.text = newScore.ToString();
        }
        else if (paddleType == PaddleType.Right)
        {
            paddleRight.text = newScore.ToString();
        }
    }

    private void ShowWinner(PaddleType paddleType)
    {
        string winner = paddleType == PaddleType.Left ? "Left Paddle Wins!" : "Right Paddle Wins!";
        GameSession.Instance.winMessage = winner;
        SceneManager.LoadScene("WinScene");
    }


}
