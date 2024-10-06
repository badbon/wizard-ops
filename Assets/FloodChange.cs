using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodChange : MonoBehaviour
{
    // Change sprite to flooded
    public Sprite floodedSprite;
    public float delay = 0.2f;
    
    void Start()
    {
        StartCoroutine(ChangeSprite());
    }

    IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<SpriteRenderer>().sprite = floodedSprite;
    }
}
