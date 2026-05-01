using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f; // Adjust this for difficulty
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set a constant velocity to the left
        rb.linearVelocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        // Optional: Destroy the obstacle once it is far off-screen to save memory
        if (transform.position.x < -15f) 
        {
            Destroy(gameObject);
        }
    }
}