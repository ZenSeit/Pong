using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    void Start()
    {
        winText.text = GameSession.Instance.winMessage;
    }
}
