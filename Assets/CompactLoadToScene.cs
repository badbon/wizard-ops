using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompactLoadToScene : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        Destroy(FindObjectOfType<LoadScene>().gameObject);
        SceneManager.LoadScene(sceneIndex);
    }
}