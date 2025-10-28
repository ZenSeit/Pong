using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 8f;
    [SerializeField] private float velocityMultiplierOnPaddleHit = 1.1f;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Launch();
    }

    private void Launch()
    {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(xDirection, yDirection).normalized * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.linearVelocity *= velocityMultiplierOnPaddleHit;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftGoal"))
        {
            GameManager.Instance.ScorePointToPaddle(PaddleType.Right);
        }
        else if (collision.CompareTag("RightGoal"))
        {
            GameManager.Instance.ScorePointToPaddle(PaddleType.Left);
        }
        Launch();
    }
}
