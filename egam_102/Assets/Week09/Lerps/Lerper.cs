using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    // Value between 0 and 1 to control movement
    public float lerpValue = 0f;
    public SpriteRenderer rendLerp;

    // Position, rotation, scale reference
    public Transform pointA;
    public Transform pointB;

    // Color reference
    public SpriteRenderer rendA;
    public SpriteRenderer rendB;

    // Whether to clamp or unclamp the lerp
    public bool isClamped = true;

    // Fine tune the movement
    public AnimationCurve curve = null;

    // Animate the lerp
    public float timer;
    public float duration = 1;

    void Update()
    {
        // Count up
        timer += Time.deltaTime;

        // This will return a value between 0 and 1
        lerpValue = timer / duration;

        // Turn the lerpValue into the curve value
        float curveInterp = curve.Evaluate(lerpValue);  

        // Clamped versions
        if (isClamped)
        {
            Vector3 newPosition = Vector3.Lerp(pointA.position, pointB.position, curveInterp);
            transform.position = newPosition;

            Vector3 newScale = Vector3.Lerp(pointA.localScale, pointB.localScale, curveInterp);
            transform.localScale = newScale;

            Quaternion newRotation = Quaternion.Lerp(pointA.localRotation, pointB.localRotation, curveInterp);
            transform.localRotation = newRotation;

            Color newColor = Color.Lerp(rendA.color, rendB.color, curveInterp);
            rendLerp.color = newColor;
        }
        // Unclamped versions
        else
        {
            Vector3 newPosition = Vector3.LerpUnclamped(pointA.position, pointB.position, curveInterp);
            transform.position = newPosition;

            Vector3 newScale = Vector3.LerpUnclamped(pointA.localScale, pointB.localScale, curveInterp);
            transform.localScale = newScale;

            Quaternion newRotation = Quaternion.LerpUnclamped(pointA.localRotation, pointB.localRotation, curveInterp);
            transform.localRotation = newRotation;

            Color newColor = Color.LerpUnclamped(rendA.color, rendB.color, curveInterp);
            rendLerp.color = newColor;
        }
    }
}
