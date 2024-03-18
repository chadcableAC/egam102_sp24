using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float startSpeed = 1;
    public float endSpeed = 2f;

    public float speedDuration = 1f;

    float timer = 0;

    void Update()
    {
        // Count up
        timer += Time.deltaTime;

        // Turn the timer into an interp (between 0 and 1)
        float interp = timer / speedDuration;

        // Update the move speed over time (go from START to END in DURATION)
        moveSpeed = Mathf.Lerp(startSpeed, endSpeed, interp);

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
