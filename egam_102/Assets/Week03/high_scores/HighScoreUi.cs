using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreUi : MonoBehaviour
{
    int score = 0;

    // UI for displaying scores
    public TextMeshProUGUI scoreUi;
    public TextMeshProUGUI highScoreUi;

    // This "key" is used to save the high score to disk
    string highScoreKeyName = "hiscore";

    void Start()
    {
        // Update the score text
        scoreUi.text = "Score: " + score;

        // See if there's a high score on disk
        int hiScore = 0;
        if (PlayerPrefs.HasKey(highScoreKeyName))
        {
            hiScore = PlayerPrefs.GetInt(highScoreKeyName);
        }
        highScoreUi.text = "Hi score: " + hiScore;
    }

    public void AddToScore(int amount)
    {
        // Add to the score
        score += amount;

        // Update the UI
        scoreUi.text = "Score: " + score;

        // See if there's a high score saved
        int hiScore = 0;
        if (PlayerPrefs.HasKey(highScoreKeyName))
        {
            hiScore = PlayerPrefs.GetInt(highScoreKeyName);
        }

        // If the score is bigger, override the value on disk
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(highScoreKeyName, score);

            highScoreUi.text = "Hi score: " + hiScore;
        }
    }

    public void ResetScore()
    {
        // Set the score back to 0
        score = 0;

        // Update the UI
        scoreUi.text = "Score: " + score;
    }

    public void ResetHighScore()
    {
        // We can "forget" the high score by deleting the value from disk
        PlayerPrefs.DeleteKey(highScoreKeyName);

        // Update the UI
        highScoreUi.text = "Hi score: 0";
    }
}
