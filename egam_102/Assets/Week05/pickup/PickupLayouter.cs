using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLayouter : MonoBehaviour
{
    public SpawnPoint[] allowedSpawnPoints;

    public Pickup pickupPrefabRed;
    public Pickup pickupPrefabOrange;
    public Pickup pickupPrefabGreen;

    public int spawnCount = 6;

    void Start()
    {
        // Get all of the Spawn Points from any/all children
        allowedSpawnPoints = GetComponentsInChildren<SpawnPoint>();

        // Track the points we've already used
        List<SpawnPoint> usedPoints = new List<SpawnPoint>();

        for (int i = 0; i < spawnCount; i++)
        {
            // Pick a random spawn point
            int randomIndex = Random.Range(0, allowedSpawnPoints.Length);
            SpawnPoint spawnHandle = allowedSpawnPoints[randomIndex];

            // Have we used this point?  Try finding a new one
            while (usedPoints.Contains(spawnHandle))
            {
                randomIndex = Random.Range(0, allowedSpawnPoints.Length);
                spawnHandle = allowedSpawnPoints[randomIndex];
            }

            // See which prefabs can be instantiated here
            List<Pickup> allowedPrefabs = new List<Pickup>();

            if (spawnHandle.canBeGreen)
            {
                allowedPrefabs.Add(pickupPrefabGreen);
            }
            if (spawnHandle.canBeOrange)
            {
                allowedPrefabs.Add(pickupPrefabOrange);
            }
            if (spawnHandle.canBeRed)
            {
                allowedPrefabs.Add(pickupPrefabRed);
            }

            if (allowedPrefabs.Count > 0)
            {
                // Pick a random prefab
                int randomPickupIndex = Random.Range(0, allowedPrefabs.Count);
                Pickup randomPrefab = allowedPrefabs[randomPickupIndex];

                // Place it at the handle position
                Pickup newPickup = Instantiate(randomPrefab);
                newPickup.moveHandle.position = spawnHandle.transform.position;

                // Keep track of this spawn point, so we don't re-use it
                usedPoints.Add(spawnHandle);
            }
        }
    }
}
