using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public SpriteRenderer rend;

    public void SetIsClicked(bool isClicked)
    {
        // Switch colors based on the state
        rend.color = Color.red;
        if (isClicked)
        {
            rend.color = Color.yellow;
        }
    }
}
