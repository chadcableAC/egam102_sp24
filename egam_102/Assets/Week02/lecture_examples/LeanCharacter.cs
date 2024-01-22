using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanCharacter : MonoBehaviour
{
    // Variables for changing scale
    public Transform scaleHandle;
    public Vector3 pressScale;

    // Variables for changing colors
    public SpriteRenderer myRenderer;
    public Color pressColor;

    public float colorDuration = 1;
    float colorTimer;

    // Update is called once per frame
    void Update()
    {
        UpdateButtonA();
        UpdateButtonB();
    }

    void UpdateButtonA()
    {        
        // If A is pressed, become small
        if (Input.GetKey(KeyCode.A))
        {
            scaleHandle.localScale = pressScale;
        }
        // OTHERWISE go back to (1, 1, 1)
        else
        {
            scaleHandle.localScale = Vector3.one;
        }
    }

    void UpdateButtonB()
    {
        // If B is pressed
        if (Input.GetKey(KeyCode.B))
        {
            // Add to the timer
            colorTimer += Time.deltaTime;

            // Don't let the timer become bigger than the duration
            if (colorTimer >= colorDuration)
            {
                colorTimer = colorDuration;
            }
        }
        // OTHERWISE
        else
        {
            // Subtract from the timer
            colorTimer -= Time.deltaTime;

            // Don't let the timer get too small
            if (colorTimer <= 0)
            {
                colorTimer = 0;
            }
        }

        // This turns the timer into a value between 0 and 1
        float interp = colorTimer / colorDuration;

        // This gets us a color between WHITE and PRESSCOLOR
        myRenderer.color = Color.Lerp(Color.white, pressColor, interp);
    }
}
