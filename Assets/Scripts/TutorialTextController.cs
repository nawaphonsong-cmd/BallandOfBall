using UnityEngine;
using TMPro;

public class TutorialTextController : MonoBehaviour
{
    public GameObject tutorialText1; // "This is you"
    public GameObject tutorialText2; // "try hitting these boxes"
    public TextMeshProUGUI sarcasticText;

    void Start()
    {
        if (PlayerDeath.hasDied)
        {
            // Hide tutorial
            tutorialText1.SetActive(false);
            tutorialText2.SetActive(false);

            // Show sarcasm
            sarcasticText.gameObject.SetActive(true);
            sarcasticText.text = "Trusting strangers, aren't we?";
        }
        else
        {
            // First time
            tutorialText1.SetActive(true);
            tutorialText2.SetActive(true);

            sarcasticText.gameObject.SetActive(false);
        }
    }
}