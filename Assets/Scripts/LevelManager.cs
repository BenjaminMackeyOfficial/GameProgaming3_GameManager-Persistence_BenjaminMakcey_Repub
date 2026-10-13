using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    //not serious do not put code like this in the level manager for a larger project, im js being funny
    private AudioSource audioSource;
    //
    private SceneManager sceneManager;

    private bool isPaused;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(2);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) TogglePauseMenu();
    }

    private void TogglePauseMenu()
    {
        if (!isPaused)
        {
            audioSource.Play();
            LoadSceneOntop("PauseMenu");
            isPaused = true;
        }
        else
        {
            UnLoadSceneOntop("PauseMenu");
            isPaused = false;
        }

        
    }

    private void LoadSceneOntop(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    private void UnLoadSceneOntop(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
