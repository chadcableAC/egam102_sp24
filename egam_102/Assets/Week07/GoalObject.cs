using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    // Scale (size) controls
    public Transform scaleHandle;
    public float scaleGoal;

    // Duration controls
    public float overlapTimer = 0;
    public float overlapDuration = 1f;

    // Overlap variables
    public float overlapCheckRadius = 1f;

    // Remember that PHYSICS logic happens in FixedUpdate, not Update
    public void FixedUpdate()
    {
        // We want to find ALL objects in teh same position as us
        Vector3 origin = transform.position;
        Collider2D[] overlapColliders = Physics2D.OverlapCircleAll(origin, overlapCheckRadius);

        // Assume that NO ONE is overlapping
        bool isAnyoneOverlapping = false;

        // Go throuigh the list one by one
        foreach (Collider2D thisCollider in overlapColliders)
        {
            // Is this collider a player?
            PlayerObject player = thisCollider.transform.GetComponent<PlayerObject>();
            if (player != null)
            {
                // It's a player!  So we're currently overlapping
                isAnyoneOverlapping = true;
                break;
            }
        }

        // Based on whetehr we're overlapping, change the timer
        if (isAnyoneOverlapping)
        {
            overlapTimer += Time.fixedDeltaTime;
        }
        else
        {
            overlapTimer -= Time.fixedDeltaTime;
        }

        // We want to make sure the timer is in teh correct range / bounds
        overlapTimer = Mathf.Clamp(overlapTimer, 0, overlapDuration);

        // This converts the timer into a value between 0 and 1
        float interp = overlapTimer / overlapDuration;

        Color newColor = Color.Lerp(Color.grey, Color.white, interp);
        myRenderer.color = newColor;

        float newScale = Mathf.Lerp(1f, scaleGoal, interp);
        scaleHandle.localScale = Vector3.one * newScale;
    }
}
