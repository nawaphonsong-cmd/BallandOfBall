using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}