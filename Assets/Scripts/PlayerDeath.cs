using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public static int deathCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadlyBox"))
        {
            deathCount++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}