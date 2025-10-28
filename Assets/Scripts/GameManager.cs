using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text PaddleOneScore;
    [SerializeField] private TMP_Text PaddleTwoScore;

    [SerializeField] private Transform Ball;
    [SerializeField] private Transform PaddleOne;
    [SerializeField] private Transform PaddleTwo;

    private int paddleOneScore = 0;
    private int paddleTwoScore = 0;

    private static GameManager instance;

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

    public void ScorePointToPaddle(PaddleType paddleType)
    {
        if (paddleType == PaddleType.Left)
        {
            paddleTwoScore++;
            PaddleTwoScore.text = paddleTwoScore.ToString();
        }
        else if (paddleType == PaddleType.Right)
        {
            paddleOneScore++;
            PaddleOneScore.text = paddleOneScore.ToString();
        }
        ResetPositions();
    }

    public void ResetPositions()
    {
        PaddleOne.position = new Vector2(PaddleOne.position.x, 0);
        PaddleTwo.position = new Vector2(PaddleTwo.position.x, 0);
        Ball.position = Vector2.zero;
    }
}
