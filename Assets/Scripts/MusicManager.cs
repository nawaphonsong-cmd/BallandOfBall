using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource audioSource;
    public AudioClip gameplayMusic;
    public AudioClip gameOverMusic;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayGameplay();
    }

    public void PlayGameplay()
    {
        audioSource.clip = gameplayMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        StartCoroutine(FadeTo(gameOverMusic));
    }

    IEnumerator FadeTo(AudioClip newClip)
    {
        // Fade out
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * 2;
            yield return null;
        }

        // Switch track
        audioSource.clip = newClip;
        audioSource.loop = false;
        audioSource.Play();

        // Fade in
        while (audioSource.volume < 0.4f)
        {
            audioSource.volume += Time.deltaTime * 2;
            yield return null;
        }
    }
}