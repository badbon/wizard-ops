using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflySpawner : MonoBehaviour
{
    public int initialSpawnCount = 100;
    public GameObject[] butterflyPrefabs;
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnButterflies();
    }

    void SpawnButterflies()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            GameObject butterflyPrefab = butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)];
            Instantiate(butterflyPrefab, randomPosition, Quaternion.identity);
        }
    }
}
