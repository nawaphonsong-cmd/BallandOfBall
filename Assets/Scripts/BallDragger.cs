using UnityEngine;

public class BallDragger : MonoBehaviour
{
    public float acceleration = 20f; // This is our 'a'
    private Rigidbody2D rb;
    private float mass; // This is our 'm'

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mass = rb.mass; // Get mass from the Rigidbody component
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) // While left click is held
        {
            // 1. Get Mouse Position in World Space
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // 2. Calculate Direction and Distance
            Vector2 direction = (Vector2)mousePos - rb.position;
            
            // 3. APPLY THE FORMULA: Force = mass * acceleration
            // We use distance to make the pull stronger the further the mouse is
            float distance = direction.magnitude;
            float calculatedForce = mass * (acceleration * distance);

            // 4. Apply the calculated force to the ball
            rb.AddForce(direction.normalized * calculatedForce);
        }
    }
}