using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;
    public int currentSelectedWizard;

    public AudioClip[] introClips;
    public AudioSource audioSource;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadSceneByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
        audioSource.clip = introClips[currentSelectedWizard];
        audioSource.Play();
    }

    public void SetCurrentSelectedWizard(int index)
    {
        currentSelectedWizard = index;
    }

}
