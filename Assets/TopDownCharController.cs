using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharController : MonoBehaviour
{
    // 2D top down character controller
    public float speed = 5f;

    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }       

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        inputVector = inputVector.normalized;
        Vector2 movement = inputVector * speed * Time.deltaTime;

        transform.position += new Vector3(movement.x, movement.y, 0);
    }
}
