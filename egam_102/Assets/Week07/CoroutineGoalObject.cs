using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineGoalObject : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    Coroutine myRoutine;

    public Transform scaleHandle;
    public float scaleGoal;

    public float overlapDuration = 1f;

    bool isOverlapping;

    void OnTriggerEnter2D(Collider2D col)
    {
        isOverlapping = true;

        // Only start a coroutine if one isn't running
        if (myRoutine == null)
        {
            myRoutine = StartCoroutine(ExecuteFill());
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isOverlapping = false;
    }

    IEnumerator ExecuteFill()
    {
        float timer = 0;

        // Keep running as long as the timer is positive
        while (timer >= 0)
        {
            // Overlapping?  Increase the timer
            if (isOverlapping)
            {
                timer += Time.deltaTime;
                timer = Mathf.Min(timer, overlapDuration);
            }
            // Not overlapping - decrease the timer
            else
            {
                timer -= Time.deltaTime;
            }

            // This turns teh timer into values between 0 and 1
            float interp = timer / overlapDuration;

            Color color = Color.Lerp(Color.grey, Color.white, interp);
            myRenderer.color = color;

            float scale = Mathf.Lerp(1f, scaleGoal, interp);
            scaleHandle.localScale = Vector3.one * scale;

            yield return null;
        }

        myRoutine = null;
    }
}
