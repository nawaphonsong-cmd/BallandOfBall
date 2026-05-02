using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public static int deathCount = 0;
    public static bool hasDied = false;

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("DeadlyBox"))
    {
       deathCount++;
       hasDied = true;

       MusicManager.instance.PlayGameOver();

       Invoke("ReloadScene", 1f); // delay so music plays
    }
}
void ReloadScene()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
    );
}
    
    


}

