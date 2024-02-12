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
        allowedSpawnPoints = GetComponentsInChildren<SpawnPoint>();


        List<SpawnPoint> usedPoints = new List<SpawnPoint>();

        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = Random.Range(0, allowedSpawnPoints.Length);
            SpawnPoint spawnHandle = allowedSpawnPoints[randomIndex];

            while (usedPoints.Contains(spawnHandle))
            {
                randomIndex = Random.Range(0, allowedSpawnPoints.Length);
                spawnHandle = allowedSpawnPoints[randomIndex];
            }

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
                int randomPickupIndex = Random.Range(0, allowedPrefabs.Count);
                Pickup randomPrefab = allowedPrefabs[randomPickupIndex];

                Pickup newPickup = Instantiate(randomPrefab);
                newPickup.moveHandle.position = spawnHandle.transform.position;

                usedPoints.Add(spawnHandle);
            }
        }
    }
}
