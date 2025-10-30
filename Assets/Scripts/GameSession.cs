using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;
    public string winMessage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
