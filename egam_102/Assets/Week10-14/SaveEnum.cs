using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveEnum : MonoBehaviour
{
    // Buttons for save/load
    public Button buttonSave;
    public Button buttonLoad;

    // Text display
    public TextMeshProUGUI textNumber;

    // PlayerPref values
    public int saveSlot = 0;
    string saveName = "enum";

    public enum EnumTest
    {
        First,
        Second,
        Third
    }

    public EnumTest currentEnum = EnumTest.First;

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
        // Turn the enum into an int
        int enumName = (int) currentEnum;
        PlayerPrefs.SetInt(GetSaveKey(saveSlot, saveName), enumName);

        // Set the text to the enum
        textNumber.text = currentEnum + "";
    }

    public void Load()
    {
        // Set a default value
        currentEnum = EnumTest.First;

        // Check if there's any save with this name
        if (PlayerPrefs.HasKey(GetSaveKey(saveSlot, saveName)))
        {
            // Get the value
            int enumName = PlayerPrefs.GetInt(GetSaveKey(saveSlot, saveName));

            // Switch from int to the enum
            currentEnum = (EnumTest) enumName;
        }

        // Set the text to the enum
        textNumber.text = currentEnum + "";
    }

    string GetSaveKey(int slotNumber, string key)
    {
        // Combine the number and key/name to create a new unique string
        return slotNumber + key;
    }
}
