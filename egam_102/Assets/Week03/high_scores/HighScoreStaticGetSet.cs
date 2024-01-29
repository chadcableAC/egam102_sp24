using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreStaticGetSet : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Directly access the variable by the class name
        // (When working with statics, we don't need an object reference)
        scoreText.text = HighScoreStatic.hiScore + "";
    }
}
