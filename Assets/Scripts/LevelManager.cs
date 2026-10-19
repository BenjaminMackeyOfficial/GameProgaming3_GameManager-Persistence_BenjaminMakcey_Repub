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
     
        if (Input.GetKeyDown(KeyCode.Alpha1)) LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) LoadScene(2);
        if(Input.GetKeyDown(KeyCode.Escape)) TogglePauseMenu();
    }

    
    private void TogglePauseMenu()
    {
        if (!isPaused)
        {
            if (!GameManager.Instance.gameStateManager.RequestEnterPaused()) return;
            audioSource.Play();
            LoadSceneOntop("PauseMenu");
            isPaused = true;
        }
        else
        {
            if (!GameManager.Instance.gameStateManager.RequestEnterPlay()) return;
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

    private void LoadScene(int load)
    {
        if(!GameManager.Instance.gameStateManager.RequestEnterLoading()) return;
        SceneManager.LoadScene(load);
        GameManager.Instance.gameStateManager.RequestEnterPlay();
    }
}
