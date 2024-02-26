using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeTree : MonoBehaviour
{
    // Fall values
    public Vector2 secondsBetweenFallsRange = new Vector2(0.1f, 1f);
    public AnimationCurve curve = null;

    void Start()
    {
        // GEt all of the oranges underneath us
        Orange[] oranges = GetComponentsInChildren<Orange>();
        foreach (Orange orange in oranges)
        {
            // Freeze the orange in place
            orange.SetInTree();
        }

        // Kickoff the fall sequence
        StartCoroutine(ExecuteMakeAllOrangesFall());
    }

    IEnumerator ExecuteMakeAllOrangesFall()
    {
        // Get all of the oranges
        Orange[] oranges = GetComponentsInChildren<Orange>();

        foreach (Orange orange in oranges)
        {
            // Make THIS orange fall
            orange.Fall();

            // Randomize the fall duration (based on the curve)
            float randomInterp = Random.value;
            float curveInterp = curve.Evaluate(randomInterp);

            float thisDuration = Mathf.Lerp(secondsBetweenFallsRange.x, secondsBetweenFallsRange.y, curveInterp);

            Debug.Log($"Turn this random value {randomInterp} into the curve interp {curveInterp}");
            
            // Wait 1 second before movign onto the next orange
            yield return new WaitForSeconds(thisDuration);       
        }
    }
}
