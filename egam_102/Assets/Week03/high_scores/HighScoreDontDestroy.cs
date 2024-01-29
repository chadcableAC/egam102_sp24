using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDontDestroy : MonoBehaviour
{
    public int hiScore = 0;

    void Start()
    {
        // Don't destory the game object we're attached to
        DontDestroyOnLoad(gameObject);
    }

    public void TrySetHighScore(int newScore)
    {
        // Update the hi score if the new score is bigger
        if (newScore > hiScore)
        {
            hiScore = newScore;
        }
    }
}
