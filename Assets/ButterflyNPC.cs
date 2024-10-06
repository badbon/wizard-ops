using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyNPC : MonoBehaviour
{
    public float speed = 2f;
    public float stoppingDistance = 1f;
    public float wanderingRadius = 5f;
    public float wanderingTimer = 2f;

    public float tiltDegrees = 10f; // Slightly tilt towards movement direction

    private Vector2 targetPosition;
    private float wanderTimer;

    public bool aggro = false;

    public GameObject deathEffect;

    void Start()
    {
        wanderingTimer = wanderingTimer * Random.Range(0.8f, 3f);
    }

    void Update()
    {
        if (!aggro)
        {
            RandomMove();
        }
    }

    public void RandomMove()
    {
        if (wanderTimer <= 0)
        {
            targetPosition = (Vector2)transform.position + Random.insideUnitCircle * wanderingRadius;
            wanderTimer = wanderingTimer;
        }
        else
        {
            wanderTimer -= Time.deltaTime;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Tilt butterflies
        Vector2 direction = targetPosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }   


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            ButterflySpawner.instance.currentSpawnCount--;
            ButterflySpawner.instance.butterflies.Remove(gameObject);
            ButterflySpawner.instance.UpdateProgressBar();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
