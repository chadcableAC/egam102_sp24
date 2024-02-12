using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowElement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Color colorOn;
    public Color colorOff;

    public ArrowPlayer.Directions ourDirection;

    public void SetOn(bool isOn)
    {
        if (isOn)
        {
            spriteRenderer.color = colorOn;
        }
        else
        {
            spriteRenderer.color = colorOff;
        }
    }
}
