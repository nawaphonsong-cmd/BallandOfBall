using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 2f;
    public float width = 20f; // The width of your background image in Unity units

    void Update()
    {
        // Move to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // If the image is fully off-screen to the left, move it to the right of the other image
        if (transform.position.x <= -width)
        {
            transform.position = new Vector3(width, transform.position.y, transform.position.z);
        }
    }
}