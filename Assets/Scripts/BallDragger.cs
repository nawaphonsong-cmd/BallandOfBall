using UnityEngine;

public class BallDragger : MonoBehaviour
{
    public float acceleration = 20f; // This is our 'a'
    private Rigidbody2D rb;
    private float mass; // This is our 'm'

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mass = rb.mass;
    }

    void Update()
    {
        // When mouse is released → turn gravity back on
        if (Input.GetMouseButtonUp(0))
        {
            rb.gravityScale = 2f; // you can tweak this (1–3 is good)
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) // While holding mouse
        {
            // Turn OFF gravity while dragging
            rb.gravityScale = 0f;

            // 1. Get Mouse Position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // 2. Direction
            Vector2 direction = (Vector2)mousePos - rb.position;

            // 3. F = m * a (scaled by distance)
            float distance = direction.magnitude;
            float calculatedForce = mass * (acceleration * distance);

            // 4. Apply force
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(direction.normalized * calculatedForce);
        }
    }
}