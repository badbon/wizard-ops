using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButterflySpawner : MonoBehaviour
{
    public int initialSpawnCount = 200;
    public int currentSpawnCount = 0;
    public GameObject[] butterflyPrefabs;
    public float spawnRadius = 10f;
    public Image progressBar;
    public List<GameObject> butterflies;
    public static ButterflySpawner instance;
    public GameObject victoryText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnButterflies();
    }

    void GameComplete()
    {
        StartCoroutine(GameCompleteDelay());
        victoryText.gameObject.SetActive(true);
    }

    public void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            float progress = 1f - ((float)currentSpawnCount / initialSpawnCount);
            progressBar.fillAmount = progress;
        }

        if(butterflies.Count <= 0)
        {
            GameComplete();
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

    public IEnumerator GameCompleteDelay()
    {
        yield return new WaitForSeconds(3f);
        FindObjectOfType<CompactLoadToScene>().LoadScene(0);
    }
}
