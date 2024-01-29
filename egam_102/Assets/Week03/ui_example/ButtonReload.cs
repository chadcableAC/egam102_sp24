using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonReload : MonoBehaviour
{
    public Button ourButton;

    private void Start()
    {
        // When the button is clicked, it will call the function WhenButtonPressed()
        ourButton.onClick.AddListener(WhenButtonPressed);
    }

    public void WhenButtonPressed()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
