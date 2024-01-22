using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnAction : MonoBehaviour
{
    // Reference to the sprite
    public SpriteRenderer mySpriteRenderer;

    // Sprite to switch to when clicked
    Sprite myOriginalSprite;
    public Sprite myClickSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Any code here will happen on script START
        // This will only happen ONCE

        // Remember the starting / original sprite
        myOriginalSprite = mySpriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // This happens MULTIPLE times
        // Called every frame
        // 60fps = update is called 60 times per second

        // If the mouse is held, do this code
        if (Input.GetMouseButton(0))
        {
            // Switch to the click color
            mySpriteRenderer.sprite = myClickSprite;         
        }       
        // OTHERWISE, do this 
        else
        {
            // Switch to the original color (white)
            mySpriteRenderer.sprite = myOriginalSprite;
        }
    }
}
