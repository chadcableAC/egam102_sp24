using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    public Rigidbody2D rb;

    public SpriteRenderer myRenderer;

    public float tellDurationInSeconds;
    public float delayFallInSeconds;


    public void SetInTree()
    {
        // Freeze the orange in palce
        rb.gravityScale = 0;
    }

    public void Fall()
    {
        // Start falling
        StartCoroutine(ExecuteFall());
    }

    IEnumerator ExecuteFall()
    {
        // Remember the current color
        Color previousColor = myRenderer.color;

        // Flash white for X seconds
        myRenderer.color = Color.white;
        yield return new WaitForSeconds(tellDurationInSeconds);

        // Return to the original color and wait
        myRenderer.color = previousColor;
        yield return new WaitForSeconds(delayFallInSeconds);

        // Finally fall
        rb.gravityScale = 1;
    }
}