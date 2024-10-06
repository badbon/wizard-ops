using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WizardSpells : MonoBehaviour
{
    public WizardTypes wizardType;
    public Sprite[] wizardSprites;

    public GameObject firePrefab;
    public float fireSpellSpawnDistance = 1f;

    public GameObject waterPrefab;
    public int numberOfStreams = 10;
    public float delayBetweenSpawns = 0.05f;

    public GameObject fabricPrefab;

    public TextMeshProUGUI characterTypeText;

    void Start()
    {
        characterTypeText.text = "Playing as " + wizardType.ToString() + " Wizard";
        GetComponent<SpriteRenderer>().sprite = wizardSprites[(int)wizardType];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        switch (wizardType)
        {
            case WizardTypes.Fire:
                FireSpell();
                break;
            case WizardTypes.Water:
                WaterSpell();
                break;
            case WizardTypes.Fabric:
                FabricSpell();
                break;
        }
    }

    void FireSpell()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = (mousePos - transform.position).normalized;
        Vector3 spawnPos = transform.position + direction * fireSpellSpawnDistance;
        Instantiate(firePrefab, spawnPos, Quaternion.identity);
        Debug.Log("Fire spell cast!");
    }

    void WaterSpell()
    {
        StartCoroutine(SpawnWaterStreams());
        Debug.Log("Water spell cast!");
    }

    void FabricSpell()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Instantiate(fabricPrefab, mousePos, Quaternion.identity);
        Debug.Log("Fabric spell cast!");
    }

    IEnumerator SpawnWaterStreams()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = (mousePos - transform.position).normalized;
        List<GameObject> waterObjects = new List<GameObject>();
        for (int i = 0; i < numberOfStreams; i++)
        {
            Vector3 spawnPos = transform.position + direction * (i + 1);
            GameObject waterObject = Instantiate(waterPrefab, spawnPos, Quaternion.identity);
            waterObjects.Add(waterObject);
            yield return new WaitForSeconds(delayBetweenSpawns);
        }

        yield return new WaitForSeconds(2f);

        // Destroy all water objects after delay
        foreach (GameObject waterObject in waterObjects)
        {
            Destroy(waterObject);
        }
    }
}

public enum WizardTypes
{
    Fire,
    Water,
    Fabric
}
