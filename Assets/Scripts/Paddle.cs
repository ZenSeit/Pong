using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private PaddleType paddleType;


    [Header("Límites (referencias a las paredes)")]
    [SerializeField] private Transform TopWall;
    [SerializeField] private Transform BottomWall;

    private string axisName;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        axisName = GetAxisName(paddleType);
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxisRaw(axisName) * speed * Time.fixedDeltaTime;

        Vector3 newPosition = transform.position + new Vector3(0, movement, 0);

        float halfHeight = transform.localScale.y / 2f;

        float topLimit = TopWall.position.y - halfHeight;
        float bottomLimit = BottomWall.position.y + halfHeight;

        newPosition.y = Mathf.Clamp(newPosition.y, bottomLimit, topLimit);

        rb.MovePosition(newPosition);
    }

    private string GetAxisName(PaddleType type)
    {
        switch (type)
        {
            case PaddleType.Left:
                return "Vertical1";
            case PaddleType.Right:
                return "Vertical2";
            default:
                return "Vertical";
        }
    }
}


public enum PaddleType
{
    Left,
    Right
}
