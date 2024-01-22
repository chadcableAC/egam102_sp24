using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnAction : MonoBehaviour
{
    // Reference to the sprite
    public SpriteRenderer mySpriteRenderer;

    // Color to switch to when clicked
    public Color myClickColor;
    public Color myClickDownColor;
    public Color myClickUpColor;

    // Start is called before the first frame update
    void Start()
    {
        // Any code here will happen on script START
        // This will only happen ONCE

    }

    // Update is called once per frame
    void Update()
    {
        // This happens MULTIPLE times
        // Called every frame
        // 60fps = update is called 60 times per second

        // If, else if, else = only ONE can be true

        // On the DOWN event, do this
        if (Input.GetMouseButtonDown(0))
        {
            mySpriteRenderer.color = myClickDownColor;
            Debug.Log("Click DOWN!");
        }
        // OTHERWISE, on the UP event, do this
        else if (Input.GetMouseButtonUp(0))
        {
            mySpriteRenderer.color = myClickUpColor;
            Debug.Log("Click UP!");
        }
        // OTHERWISE, if the mouse is held do this code
        else if (Input.GetMouseButton(0))
        {
            // Switch to the click color
            mySpriteRenderer.color = myClickColor;
        }        
        // OTHERWISE, do this
        else
        {
            // Switch to the original color (white)
            mySpriteRenderer.color = Color.white;
        }
    }
}
