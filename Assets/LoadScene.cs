using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;
    public int currentSelectedWizard;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SetCurrentSelectedWizard(int index)
    {
        currentSelectedWizard = index;
    }

}
