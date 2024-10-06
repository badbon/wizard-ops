using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButterflySpawner : MonoBehaviour
{
    public int initialSpawnCount = 200;
    public int currentSpawnCount = 0;
    public GameObject[] butterflyPrefabs;
    public float spawnRadius = 10f;
    public Image progressBar;
    public List<GameObject> butterflies;
    public static ButterflySpawner instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnButterflies();
    }

    public void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            float progress = 1f - ((float)currentSpawnCount / initialSpawnCount);
            progressBar.fillAmount = progress;
        }
    }

    void SpawnButterflies()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            GameObject butterflyPrefab = butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)];
            GameObject butterfly = Instantiate(butterflyPrefab, randomPosition, Quaternion.identity);
            butterflies.Add(butterfly);
            currentSpawnCount++;
        }
    }
}
