using UnityEngine;
using TMPro;

public class DeathCounterUI : MonoBehaviour
{
    public TextMeshProUGUI deathText;

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        deathText.text = "Deaths: " + PlayerDeath.deathCount;
    }
}