using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private SceneManager sceneManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(2); 
    }
}
