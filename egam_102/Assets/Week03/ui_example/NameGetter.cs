using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameGetter : MonoBehaviour
{
    public TMP_InputField inputField;

    public TextMeshProUGUI textField;

    void Start()
    {
        // Set the initial value
        inputField.text = "My name is Chad";
    }

    // Update is called once per frame
    void Update()
    {
        // On right click, print out the text field info
        if (Input.GetMouseButtonDown(1))
        {
            string textInField = inputField.text;
            Debug.Log(textInField);
        }

        textField.text = "Text entered: " + inputField.text;
    }
}
