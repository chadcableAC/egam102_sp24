using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;

    public Transform spawnOrigin;
    public Vector2 spawnArea;

    public int spawnAmount = 10;
    public float circleRadius = 1;

    void Start()
    {
        Vector2 originPoint = spawnOrigin.position;

        // Spawn this number of items
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 newPosition = Vector2.zero;

            int attempts = 100;

            // Keep picking a position until we find one that doesn't overlap
            bool isPositionOverlap = true;
            while (isPositionOverlap)
            {
                // Randomize between the area values
                Vector2 randomOffset = Vector2.zero;
                randomOffset.x = Random.Range(-spawnArea.x, spawnArea.x);
                randomOffset.y = Random.Range(-spawnArea.y, spawnArea.y);

                // Add the offset to the base position
                newPosition = originPoint + randomOffset;

                // Debug draw an "x" in the scene
                DebugDrawX(newPosition, circleRadius);

                //isPositionOverlap = Physics2D.CircleCast(newPosition, circleRadius, Vector2.zero);
                isPositionOverlap = Physics2D.OverlapCircle(newPosition, circleRadius);

                // This prevents an infinite loop incase we can't find a non-overlapping position
                attempts--;
                if (attempts <= 0)
                {
                    Debug.Log("Hey I coul;dn't find a valid position!");
                    break;
                }
            }

            // Finally place the object at tghis poistion
            GameObject newObject = Instantiate(spawnPrefab);
            newObject.transform.position = newPosition;
        }
    }

    void DebugDrawX(Vector2 origin, float radius)
    {
        // This draws an "x" at this position
        Debug.DrawRay(origin, Vector2.up * radius);
        Debug.DrawRay(origin, Vector2.right * radius);
        Debug.DrawRay(origin, Vector2.down * radius);
        Debug.DrawRay(origin, Vector2.left * radius);
    }
}
