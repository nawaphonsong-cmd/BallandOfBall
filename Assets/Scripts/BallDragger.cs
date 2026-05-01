using UnityEngine;

public class BallDragger : MonoBehaviour
{
    public float power = 25f;

    private Rigidbody2D rb;
    private Vector2 startPos;

    public LineRenderer line;
    public int points = 20;
    public float timeStep = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    void OnMouseDown()
    {
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;

        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        line.positionCount = points;
    }

    void OnMouseDrag()
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 drag = startPos - currentPos;
        Vector2 direction = drag.normalized;
        float distance = Mathf.Clamp(drag.magnitude, 0, 3f);

        Vector2 force = direction * distance * power;

        for (int i = 0; i < points; i++)
        {
            float t = i * timeStep;

            Vector2 pos = (Vector2)transform.position
                + (force / rb.mass) * t
                + 0.5f * Physics2D.gravity * 1.2f * t * t;

            line.SetPosition(i, pos);
        }
    }

    void OnMouseUp()
    {
        Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 drag = startPos - releasePos;
        Vector2 direction = drag.normalized;
        float distance = Mathf.Clamp(drag.magnitude, 0, 3f);

        Vector2 force = direction * distance * power;

        rb.gravityScale = 1.2f;
        rb.AddForce(force, ForceMode2D.Impulse);

        line.positionCount = 0;
    }
}