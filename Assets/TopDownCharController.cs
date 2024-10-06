using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharController : MonoBehaviour
{
    // 2D top down character controller
    public float speed = 5f;
    public bool isFacingRight = false;
    
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadScene loadScene = FindObjectOfType<LoadScene>();
        int currentWizard = loadScene.currentSelectedWizard;
        GetComponent<WizardSpells>().wizardType = (WizardTypes)currentWizard;
    }

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
            isFacingRight = false;
        }       

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
            isFacingRight = true;
        }

        inputVector = inputVector.normalized;
        Vector2 movement = inputVector * speed * Time.deltaTime;

        transform.position += new Vector3(movement.x, movement.y, 0);

        spriteRenderer.flipX = isFacingRight;
    }
}
