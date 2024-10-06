using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    private Vector2 direction;

    public float spinSpeed = 100f;

    public float lifeTime = 5f;
    private float lifeTimer;

    void Start()
    {
        if (rb == null) 
        {
            rb = GetComponent<Rigidbody2D>();
        }

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
        direction = (targetPosition - transform.position).normalized;
    }

    void Update()
    {
        rb.velocity = direction * speed;

        lifeTimer += Time.deltaTime;
        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }

        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
