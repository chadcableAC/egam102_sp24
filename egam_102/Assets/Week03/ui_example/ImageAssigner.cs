using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAssigner : MonoBehaviour
{
    public Image image;
    public Sprite sprite;

    void Start()
    {
        // Set the image's sprite
        image.sprite = sprite;
    }
}
