using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    void Update()
    {
        // Turn the mouse position into a "world" position
        // This means going from SCREEN to WORLD
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Draw a ray in the scene
        Debug.DrawRay(worldPosition, Vector3.forward);

        // Get the first object that overlaps with this point
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        // Remembver this might be empty (in the case we're not overlapping anything)
        if (hitCollider != null)
        {
            // Then try to see if there's any ClickableObject.cs on the transform / parent
            ClickableObject clickable = hitCollider.GetComponentInParent<ClickableObject>();
            if (clickable != null)
            {                
                clickable.SetIsClicked(true);
            }
        }
    }
}
