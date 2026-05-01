using UnityEngine;

public class Block : MonoBehaviour
{
    public int health = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health--;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}