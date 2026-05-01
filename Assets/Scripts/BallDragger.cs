using UnityEngine;

public class BallDragger : MonoBehaviour
{
    public float power = 25f;

    private Rigidbody2D rb;
    private Vector2 startPos;

    public LineRenderer line;
    public int points = 30;
    public float timeStep = 0.1f;

    public float gravityStrength = 1.2f;

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

        // 🔥 Use bounce trajectory instead of old loop
        DrawTrajectory(transform.position, force);
    }

    void OnMouseUp()
    {
        Vector2 releasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 drag = startPos - releasePos;
        Vector2 direction = drag.normalized;
        float distance = Mathf.Clamp(drag.magnitude, 0, 3f);

        Vector2 force = direction * distance * power;

        rb.gravityScale = gravityStrength;
        rb.AddForce(force, ForceMode2D.Impulse);

        line.positionCount = 0;
    }

    void DrawTrajectory(Vector2 startPos, Vector2 force)
    {
        Vector2 velocity = force / rb.mass;

        int index = 0;
        Vector2 currentPos = startPos;

        for (int i = 0; i < points; i++)
        {
            float t = timeStep;

            Vector2 nextPos = currentPos
                + velocity * t
                + 0.5f * Physics2D.gravity * gravityStrength * t * t;

            RaycastHit2D hit = Physics2D.Linecast(currentPos, nextPos);

            if (hit.collider != null)
            {
                line.SetPosition(index, hit.point);
                index++;

                // Reflect velocity (bounce)
                velocity = Vector2.Reflect(velocity, hit.normal) * 0.8f;

                // Small offset to prevent sticking
                currentPos = hit.point + hit.normal * 0.02f;
            }
            else
            {
                line.SetPosition(index, nextPos);
                index++;
                currentPos = nextPos;
            }
        }

        line.positionCount = index;
    }
}