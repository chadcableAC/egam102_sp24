using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveNumber : MonoBehaviour
{
    // Buttons for save/load
    public Button buttonSave;
    public Button buttonLoad;

    // Text display
    public TextMeshProUGUI textNumber;
    
    // Text input
    public TMP_InputField input;

    // PlayerPref values
    public int saveSlot = 0;
    string saveName = "number";

    // Start is called before the first frame update
    void Start()
    {
        // Now these buttons will call "Save" and "Load" when clicked
        buttonSave.onClick.AddListener(Save);
        buttonLoad.onClick.AddListener(Load);

        // Load the current value
        Load();
    }

    public void Save()
    {
        // Turn the string into an int
        int value = int.Parse(input.text);
        PlayerPrefs.SetInt(GetSaveKey(saveSlot, saveName), value);

        // Set the text to the int value
        textNumber.text = value + "";
    }

    public void Load()
    {
        // Set a default value
        int value = 0;

        // Check if there's any save with this name
        if (PlayerPrefs.HasKey(GetSaveKey(saveSlot, saveName)))
        {
            // Get the value
            value = PlayerPrefs.GetInt(GetSaveKey(saveSlot, saveName));
        }

        // Set the text to the value
        input.text = value + "";
        textNumber.text = value + "";
    }

    string GetSaveKey(int slotNumber, string key)
    {
        // Combine the number and key/name to create a new unique string
        return slotNumber + key;
    }
}
