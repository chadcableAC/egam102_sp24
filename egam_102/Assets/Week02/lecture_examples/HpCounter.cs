using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCounter : MonoBehaviour
{
    public SpriteRenderer mySprite;

    public Color colorMax;  // Lots of HP
    public Color colorMed;  // Mid HP
    public Color colorLow;  // Low HP

    public int hitPointsCounter;

    void Update()
    {
        // Each time we click, reduce the counter
        if (Input.GetMouseButtonDown(0))
        {
            // Take one health point away from this counter
            // (All of these examples do the same thing)
            hitPointsCounter = hitPointsCounter - 1;
            //hitPointsCounter -= 1;
            //hitPointsCounter--;

            // If we have MORE than 5, use max color
            if (hitPointsCounter > 5)
            {
                mySprite.color = colorMax;
            }
            // OTHERWISE, if we have MORE than 1, use mid color
            else if (hitPointsCounter > 2)
            {
                mySprite.color = colorMed;
            }
            // OTHERWISE, use low color
            else
            {
                mySprite.color = colorLow;
            }
        }
    }
}
