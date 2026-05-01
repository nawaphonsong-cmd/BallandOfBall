using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int next = SceneManager.GetActiveScene().buildIndex + 1;

            Debug.Log("Go to next scene: " + next); // เช็คว่าเข้าไหม

            if (next < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(next);
            }
            else
            {
                Debug.Log("Last Level");
            }
        }
    }
}