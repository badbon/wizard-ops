using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public int sceneIndex;

    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
