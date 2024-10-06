using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricCollapse : MonoBehaviour
{
    // Collapse fabric into 0 size
    public float collapseSpeed = 1f;
    public float delay = 0.2f;

    void Start()
    {
        StartCoroutine(Collapse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Collapse()
    {
        yield return new WaitForSeconds(delay);
        // Smoothly shrink the fabric
        float currentSize = transform.localScale.x;
        while (currentSize > 0)
        {
            currentSize -= collapseSpeed * Time.deltaTime;
            transform.localScale = new Vector3(currentSize, currentSize, 1);
            yield return null;
        }
    }
}
