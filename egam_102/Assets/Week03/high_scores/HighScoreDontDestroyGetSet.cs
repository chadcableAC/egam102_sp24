using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDontDestroyGetSet : MonoBehaviour
{
    // UI reference
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Find this script in the scene
        HighScoreDontDestroy hiScoreKeeper = FindObjectOfType<HighScoreDontDestroy>();
        if (hiScoreKeeper != null)
        {
            // Update the text to the stored high score
            scoreText.text = hiScoreKeeper.hiScore + "";
        }
    }
}
